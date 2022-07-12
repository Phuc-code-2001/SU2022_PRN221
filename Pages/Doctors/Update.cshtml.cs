using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Extensions;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Views;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.Pages.Doctors
{
    [Authorize]
    public class UpdateModel : IdentityPage
    {
        private IWebHostEnvironment _env;

        public UpdateModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _env = env;
        }

        [BindProperty]
        public DoctorUpdateView View { get; set; } = new DoctorUpdateView();

        public Doctor Doctor { get; set; }

        public IActionResult OnGet(string Id)
        {
            Doctor = _context.Doctors.Include(d => d.User).FirstOrDefault(d => d.UserId == Id);
            if (Doctor == null)
            {
                Messages.Add(new Utils.Message
                {
                    Content = "Doctor not found!"
                }
                .ToDanger());

                return Page();
            }

            if (!IsAdmin && !IsOwner(Id))
            {
                PushMessageBeforeRedirect(new Utils.Message
                {
                    Content = "Method not allowed!"
                }
                .ToDanger());
                return RedirectToPage("/DenyRequest");
            }

            View.Major = Doctor.Major;

            return Page();

        }

        public async Task<IActionResult> OnPost(string Id)
        {
            Doctor = _context.Doctors.Include(d => d.User).FirstOrDefault(d => d.UserId == Id);
            if(ModelState.IsValid)
            {
                if (Doctor == null)
                {
                    Messages.Add(new Utils.Message
                    {
                        Content = "Doctor not found!"
                    }
                    .ToDanger());

                    return Page();
                }

                if (!IsAdmin && !IsOwner(Id))
                {
                    PushMessageBeforeRedirect(new Utils.Message
                    {
                        Content = "Method not allowed!"
                    }
                    .ToDanger());
                    return RedirectToPage("/DenyRequest");
                }

                if(View.QualificationImage != null)
                {
                    Doctor.QualificationURL = await ImageProcessor.SaveToAsync(_env, View.QualificationImage, "qualifications");
                    if (Doctor.QualificationURL == null)
                    {
                        Messages.Add(new Utils.Message
                        {
                            Content = "File must be an image!"
                        }
                        .ToDanger());

                        return Page();
                    }
                }

                Doctor.Major = View.Major;

                _context.Doctors.Update(Doctor);
                _context.SaveChanges();
                return RedirectToPage("./Info", new { Id=Id });
                
            }

            return Page();

        }

    }
}
