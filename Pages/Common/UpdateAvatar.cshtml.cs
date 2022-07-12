using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Extensions;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.Pages.Common
{
    public class UpdateAvatarModel : IdentityPage
    {

        IWebHostEnvironment _env;

        public UpdateAvatarModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _env = env;
        }

        public async Task<IActionResult> OnPost(IFormFile file, string userId)
        {
            if(!IsAdmin && !IsOwner(userId))
            {
                return RedirectToPage("/DenyRequest");
            }

            AppUser User = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (User == null)
            {
                Messages.Add(new Utils.Message
                {
                    Content = "User not found!"
                }
                .ToDanger());
                return Page();
            }

            string saveImagePath = await ImageProcessor.SaveToAsync(_env, file, "users");
            if(saveImagePath == null)
            {
                Messages.Add(new Utils.Message
                {
                    Content = "File must be an image!"
                }
                .ToDanger());
                return Page();
            }

            User.ImageURL = saveImagePath;
            _context.Users.Update(User);
            _context.SaveChanges();

            PushMessageBeforeRedirect(new Utils.Message
            {
                Content = "Update your image success!"
            }
            .ToSuccess());

            return RedirectToPage("/Customers/Info", new { Id=userId });

        }
    }
}
