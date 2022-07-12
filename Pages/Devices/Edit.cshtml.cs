using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages.Devices
{
    public class EditModel : IdentityPage
    {
		public EditModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
		{

		}

		[BindProperty]
        public Device Device { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Device = await _context.Devices
                .Include(d => d.Room).FirstOrDefaultAsync(m => m.Id == Id);

            if (Device == null)
            {
                return NotFound();
            }
           ViewData["RoomCode"] = new SelectList(_context.Rooms, "RoomCode", "RoomCode");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(Device.Id))
                {
                    return NotFound();
                }

                return RedirectToPage("/DenyRequest");
            }

            return RedirectToPage("./Index");
        }

        private bool DeviceExists(int Id)
        {
            return _context.Devices.Any(e => e.Id == Id);
        }
    }
}
