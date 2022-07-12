using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages.Services
{
    [Authorize(Roles = "admin")]
    public class CreateModel : IdentityPage
    {
        public CreateModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        [BindProperty]
        public Service Service { get; set; }

        [BindProperty]
        public List<int> DeviceListId { get; set; }

        public new IActionResult OnGet()
        {

            ViewData["DeviceListId"] = new SelectList(_context.Devices, "Id", "DeviceCode");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["DeviceListId"] = new SelectList(_context.Devices, "Id", "DeviceCode");
                return Page();
            }

            List<Device> devices = _context.Devices.Where(d => DeviceListId.Contains(d.Id)).ToList();
            foreach(Device device in devices)
            {
                Service.Devices.Add(device);
            }
                
            _context.Services.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
