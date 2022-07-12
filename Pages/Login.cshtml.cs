using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.Pages
{
    public class LoginModel : IdentityPage
    {
        public LoginModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {
        }

        [BindProperty]
        [Required]
        public string UserName { get; set; }
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        
        public IActionResult OnGet(string ReturnUrl = null)
        {
            base.OnGet();

            if(IsAuthenticated)
            {

                if(ReturnUrl != null) return Redirect(ReturnUrl);

                if (IsAdmin)
                {
                    return RedirectToPage("/Administrator/ControlPanel");
                }

                return RedirectToPage("/Index");

            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string ReturnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(UserName, Password, RememberMe, false);
                if(result.Succeeded)
                {
                    return RedirectToPage("/Login", new { ReturnUrl=ReturnUrl });
                }
                else
				{
                    Messages.Add(new Message
                    {
                        Content = "UserName or Password incorrect!"
                    }
                    .ToDanger());
				}
                
            }

            return Page();
        }
    }
}
