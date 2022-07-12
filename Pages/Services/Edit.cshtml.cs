using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages.Services
{
    [Authorize(Roles = "admin")]
    public class EditModel : IdentityPage
    {
        public EditModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        [BindProperty]
        public Service Service { get; set; }

        [BindProperty]
        public List<int> DeviceListId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Service = await _context.Services.Include(s => s.Devices).FirstOrDefaultAsync(m => m.Id == Id);

            if (Service == null)
            {
                return NotFound();
            }

            DeviceListId = Service.Devices.Select(d => d.Id).ToList();
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


            Service serviceToUpdate = _context.Services.Include(s => s.Devices).FirstOrDefault(s => s.Id == Service.Id);
            serviceToUpdate.ServiceCode = Service.ServiceCode;
            serviceToUpdate.Description = Service.Description;
            serviceToUpdate.Price = Service.Price;

            List<Device> devicesSelected = _context.Devices.Where(d => DeviceListId.Contains(d.Id)).ToList();

            serviceToUpdate = UpdateServiceDevices(devicesSelected, serviceToUpdate);

            _context.Services.Update(serviceToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(Service.Id))
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToPage("/DenyRequest");
                }
            }

            return RedirectToPage("./Index");
        }

        private Service UpdateServiceDevices(List<Device> newDeviceList, Service service)
        {
            service.Devices.Clear();
            foreach(Device device in newDeviceList)
            {
                if(!service.Devices.Contains(device))
                {
                    service.Devices.Add(device);
                }
            }

            return service;
        }

        private bool ServiceExists(int Id)
        {
            return _context.Services.Any(e => e.Id == Id);
        }
    }
}
