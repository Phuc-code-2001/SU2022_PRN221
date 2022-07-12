using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System.Linq;

namespace ShinyTeeth.Pages.Notifications
{
    public class GoToLinkModel : IdentityPage
    {
        public GoToLinkModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        public IActionResult OnGet(int Id)
        {
            Notification notification = _context.Notifications.FirstOrDefault(n => n.Id == Id);
            if(notification == null)
            {
                return NotFound();
            }

            if(!IsOwner(notification.ReceiverId))
            {
                return RedirectToPage("/DenyRequest");
            }

            notification.Status = 1;
            _context.Notifications.Update(notification);
            _context.SaveChanges();

            return Redirect(notification.LinkTo);

        }
    }
}
