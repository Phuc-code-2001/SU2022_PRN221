using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Extensions;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.Pages.Appointments
{
    [Authorize(Roles="admin")]
    public class EditModel : IdentityPage
    {

        private IWebHostEnvironment _env;

        public EditModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _env = env;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        [BindProperty]
        [DataType(DataType.Upload)]
        public IFormFile MedicalRecordFile { get; set; }

        [BindProperty]
        public List<int> Services { get; set; }

        public IActionResult OnGet(int Id)
        {

            Appointment = _context.Appointments.Include(a => a.Services).FirstOrDefault(a => a.Id == Id);
            if(Appointment == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers.Include(cus => cus.User), "UserId", "User");
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "UserId", "User");
            ViewData["RoomCode"] = new SelectList(_context.Rooms, "RoomCode", "RoomCode");

            ViewData["ServiceList"] = new SelectList(_context.Services, "Id", "Summary");
            Services = Appointment.Services.Select(s => s.Id).ToList();

            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(AppointmentStatus)));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int Id)
        {
            var updateObj = _context.Appointments.Include(a => a.Services).FirstOrDefault(a => a.Id == Id);
            
            if(ModelState.IsValid)
            {
                if (MedicalRecordFile != null)
                {
                    string savePath = await FileProcessor.SaveToAsync(_env, MedicalRecordFile, "medical_records");
                    if (savePath != null)
                    {
                        updateObj.MedicalProfileURL = savePath;
                    }
                    else
                    {
                        Messages.Add(new Utils.Message
                        {
                            Content = "File only accept pdf file"
                        }
                        .ToDanger());
                    }
                }

                updateObj.CustomerId = Appointment.CustomerId;
                updateObj.DoctorId = Appointment.DoctorId;
                updateObj.Status = Appointment.Status;
                updateObj.Time = Appointment.Time;
                updateObj.Duration = Appointment.Duration;
                updateObj.Content = Appointment.Content;
                updateObj.RoomCode = Appointment.RoomCode;


                List<Service> newServiceList = _context.Services.Where(s => Services.Contains(s.Id)).ToList();
                updateObj = UpdateServices(newServiceList, updateObj);

                _context.Appointments.Update(updateObj);

                try
                {
                    _context.SaveChanges();

                    return RedirectToPage("./Index");
                }
                catch(Exception ex)
                {
                    Messages.Add(new Utils.Message
                    {
                        Content = ex.Message
                    }
                    .ToDanger());
                }
            }


            if (Appointment == null)
            {
                return NotFound();
            }

            ViewData["CustomerId"] = new SelectList(_context.Customers.Include(cus => cus.User), "UserId", "User");
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "UserId", "User");
            ViewData["RoomCode"] = new SelectList(_context.Rooms, "RoomCode", "RoomCode");

            ViewData["ServiceList"] = new SelectList(_context.Services, "Id", "Summary");
            ViewData["StatusList"] = new SelectList(Enum.GetValues(typeof(AppointmentStatus)));

            return Page();
        }


        private Appointment UpdateServices(List<Service> newServiceList, Appointment appointment)
        {
            appointment.Services.Clear();
            foreach (Service service in newServiceList)
            {
                if (!appointment.Services.Contains(service))
                {
                    appointment.Services.Add(service);
                }
            }

            return appointment;
        }
    }
}
