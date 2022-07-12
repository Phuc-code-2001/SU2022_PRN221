using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages.Appointments
{
    public class DetailsModel : IdentityPage
    {
        public DetailsModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        public Appointment Appointment { get; set; }

        [BindProperty]
        public FeedBack FeedBack { get; set; }

        public bool FeedBackAvailable { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Customer.User)
                .Include(a => a.Doctor)
                .Include(a => a.Doctor.User)
                .Include(a => a.Room)
                .Include(a => a.Services).FirstOrDefaultAsync(m => m.Id == id);

            if (Appointment == null)
            {
                return NotFound();
            }

            Customer customer = Appointment.Customer;

            FeedBack = _context.FeedBacks.FirstOrDefault(f => f.AppointmentId == Appointment.Id);
            if(FeedBack == null)
            {
                FeedBackAvailable = Appointment.Status == AppointmentStatus.Complete 
                    && IsOwner(customer.UserId);
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if(ModelState.IsValid)
            {
                _context.FeedBacks.Add(FeedBack);
                _context.SaveChanges();

                PushMessageBeforeRedirect(new Utils.Message
                {
                    Content = "Feedback success"
                }
                .ToSuccess());

                return RedirectToPage("", new { id = id });
            }

            return Page();
        }
    }
}
