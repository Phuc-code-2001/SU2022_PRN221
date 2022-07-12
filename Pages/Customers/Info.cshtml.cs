using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Utils;
using System.Linq;

namespace ShinyTeeth.Pages.Customers
{
    [Authorize]
    public class InfoModel : CustomerPage
    {
        public InfoModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {
        }

        public Customer Customer { get; set; }

        public IActionResult OnGet(string Id)
        {
            base.OnGet();

            if(!IsOwner(Id) && !IsAdmin)
            {
                PushMessageBeforeRedirect(new Message
                {
                    Content = "Not allowed!"
                }
                .ToDanger());
                return RedirectToPage("/DenyRequest");
            }
            
            AppUser User = _context.Users.FirstOrDefault(u => u.Id == Id);
            Customer = _context.Customers.Include(c => c.User).FirstOrDefault(c => c.UserId == Id);

            if(User == null)
            {
                Messages.Add(new Message
                {
                    Content = "User not found!"
                }
                .ToDanger());
            }
            else if(Customer == null)
            {
                Customer = CreateCustomer(User);
            }

            return Page();
        }
    
    
    }
}
