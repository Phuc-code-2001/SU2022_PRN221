using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ShinyTeeth.Pages.Notifications
{
    public class CreateModel : IdentityPage
    {
        private IHubContext<SignalRServerHub> _serverHubContext;

        public CreateModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IHubContext<SignalRServerHub> serverHubContext) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _serverHubContext = serverHubContext;
        }

        public new IActionResult OnGet()
        {
        ViewData["ReceiverId"] = new SelectList(_context.Users, "Id", "UserName");
            return Page();
        }

        [BindProperty]
        public Notification Notification { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notifications.Add(Notification);
            await _context.SaveChangesAsync();
            await SignalRServerHub.SendNotification(_serverHubContext, Notification);
            return RedirectToPage("./Index");
        }

        
    }
}
