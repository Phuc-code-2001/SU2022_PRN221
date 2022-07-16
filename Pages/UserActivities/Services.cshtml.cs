using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System.Collections.Generic;
using System.Linq;

namespace ShinyTeeth.Pages.UserActivities
{
    public class ServicesModel : IdentityPage
    {
        public ServicesModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        public List<Service> Services { get; set; } = new List<Service>();

        public new IActionResult OnGet()
        {
            Services = _context.Services.ToList();

            return Page();
        }
    }
}
