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

namespace ShinyTeeth.Pages.Doctors
{
    [Authorize]
    public class InfoModel : IdentityPage
    {
        public InfoModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        public Doctor Doctor { get; set; }

        public IActionResult OnGet(string Id)
        {
            base.OnGet();

            if (!IsOwner(Id) && !IsAdmin)
            {
                PushMessageBeforeRedirect(new Message
                {
                    Content = "Not allowed!"
                }
                .ToDanger());
                return RedirectToPage("/DenyRequest");
            }

            AppUser User = _context.Users.FirstOrDefault(u => u.Id == Id);
            Doctor = _context.Doctors.Include(c => c.User).FirstOrDefault(c => c.UserId == Id);

            if (User == null)
            {
                Messages.Add(new Message
                {
                    Content = "User not found!"
                }
                .ToDanger());
            }
            else if(!GetUserRoles(User).Contains(AppRoles.Doctor)) 
            {
                PushMessageBeforeRedirect(new Message
                {
                    Content = "Don't have permission!"
                }
                .ToDanger());
                return RedirectToPage("/DenyRequest");
            }
            else if(Doctor == null)
            {
                Doctor = CreateDoctor(User);
            }

            return Page();
        }

        public Doctor CreateDoctor(AppUser user)
        {
            Doctor doctor = new Doctor()
            {
                UserId = user.Id
            };

            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return doctor;
        }
    }
}
