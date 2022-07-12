using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System.Collections.Generic;
using System.Linq;

namespace ShinyTeeth.Pages.Customers
{
	[Authorize(Roles = "admin")]
    public class IndexModel : IdentityPage
    {
		public IndexModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
		{

		}

        [BindProperty]
        public List<AppUser> Users { get; set; } = new List<AppUser>();

		public new IActionResult OnGet()
        {

            Users = _context.Users.ToList();

            return Page();
        }
    }
}
