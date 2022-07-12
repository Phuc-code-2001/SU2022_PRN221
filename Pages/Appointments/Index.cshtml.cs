using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages.Appointments
{
    public class IndexModel : IdentityPage
    {
        public IndexModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        public List<Appointment> Appointment { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!IsAdmin)
            {
                return RedirectToPage("/Index");
            }

            Appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Customer.User)
                .Include(a => a.Doctor)
                .Include(a => a.Doctor.User)
                .Include(a => a.Room)
                .Include(a => a.Services).ToListAsync();

            return Page();
        }
    }
}
