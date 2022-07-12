using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Utils;
using System.Collections.Generic;
using System.Linq;

namespace ShinyTeeth.Pages.Roles
{
    [Authorize(Roles = "admin")]
    public class SettingsModel : IdentityPage
    {
		public SettingsModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
		{
		}

        public List<string> AddRoles { get; set; } = new List<string>();
        public List<string> UserRoles { get; set; } = new List<string>();

        public string UserId { get; set; }

		public IActionResult OnGet(string userId)
        {
            base.OnGet();

            AppUser user = _userManager.FindByIdAsync(userId).Result;
            if(user == null)
			{
                Messages.Add(new Utils.Message
                {
                    Content = "User not found!"
                }

                .ToDanger());

                return Page();
			}

            var userRoles = GetUserRoles(user);
            UserId = userId;
            
            AddRoles = AppRoles.Items.Where(roleName => !userRoles.Contains(roleName)).ToList();
            UserRoles = userRoles;

            return Page();
        }

        public IActionResult OnPost(string userId, string roleName, string operation)
		{
            if (operation == "add") return AddRole(userId, roleName);
            if (operation == "remove") return RemoveRole(userId, roleName);

            PushMessageBeforeRedirect(new Message
            {
                Content = "Data invalid!"
            }
            .ToDanger());
            return RedirectToPage("/DenyRequest");
        }

        private IActionResult AddRole(string userId, string roleName)
		{
            AppUser user = _userManager.FindByIdAsync(userId).Result;
            if (user == null)
            {
                Messages.Add(new Message
                {
                    Content = "User not found!"
                }
                .ToDanger());

                return Page();
            }

            if (AppRoles.Items.Contains(roleName) && !GetUserRoles(user).Contains(roleName))
            {
                _userManager.AddToRoleAsync(user, roleName).Wait();
                PushMessageBeforeRedirect(new Message
                {
                    Content = "Add role success!"
                }
                .ToSuccess());

                return RedirectToPage("", new { userId = userId });
            }

            Messages.Add(new Message
            {
                Content = "Invalid!"
            }
            .ToWarning());

            return Page();
        }

        private IActionResult RemoveRole(string userId, string roleName)
		{
            AppUser user = _userManager.FindByIdAsync(userId).Result;
            if (user == null)
            {
                Messages.Add(new Message
                {
                    Content = "User not found!"
                }
                .ToDanger());

                return Page();
            }

            if (GetUserRoles(user).Contains(roleName))
            {
                _userManager.RemoveFromRoleAsync(user, roleName).Wait();
                PushMessageBeforeRedirect(new Message
                {
                    Content = "Remove role success!"
                }
                .ToSuccess());

                return RedirectToPage("", new { userId = userId });
            }

            Messages.Add(new Message
            {
                Content = "Invalid!"
            }
            .ToWarning());

            return Page();
        }
    }
}
