using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Utils;
using ShinyTeeth.Views;
using System;
using System.Threading.Tasks;

namespace ShinyTeeth.Pages
{
    public class RegisterModel : IdentityPage
    {
        public RegisterModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        [BindProperty]
        public RegisterView ViewModel { get; set; } 

        public new IActionResult OnGet()
        {
            base.OnGet();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                try
                {
                    IdentityResult result = await _userManager.CreateAsync(ViewModel, ViewModel.FirstPassword);
                    if(result.Succeeded)
                    {

                        PushMessageBeforeRedirect(new Message()
                        {
                            Content = "Register success!"
                        }
                        .ToSuccess());
                        
                        return RedirectToPage("/Login");
                    }

                    foreach(var error in result.Errors)
                    {
                        Messages.Add(new Message
                        {
                            Content = error.Description
                        }
                        .ToDanger());
                    }
                }
                catch(Exception ex)
                {
                    
                    Messages.Add(new Message()
                    {
                        Content = ex.Message,
                    }
                    .ToDanger());
                }

            }
            
            return Page();
        }

    }
}
