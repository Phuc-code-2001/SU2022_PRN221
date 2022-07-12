using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages
{
    [Authorize]
    public class LogoutModel : IdentityPage
    {
        public LogoutModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {
        }

        public new IActionResult OnGet()
        {
            base.OnGet();

            return Page();
        }

        public IActionResult OnPost()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToPage("/Index");
        }
    }
}
