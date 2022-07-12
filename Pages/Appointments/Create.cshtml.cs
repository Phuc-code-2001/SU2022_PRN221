using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Extensions;
using ShinyTeeth.Hubs;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Utils;

namespace ShinyTeeth.Pages.Appointments
{
    [Authorize]
    public class CreateModel : IdentityPage
    {
        private IWebHostEnvironment _env;
        private IHubContext<SignalRServerHub> _hubContext;

        public CreateModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IWebHostEnvironment env, IHubContext<SignalRServerHub> hubContext) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _env = env;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        [BindProperty]
        [DataType(DataType.Upload)]
        public IFormFile MedicalRecordFile { get; set; }

        [BindProperty]
        public List<int> Services { get; set; }

        public new IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers.Include(cus => cus.User), "UserId", "User");

            var doctors = _context.Doctors.Include(d => d.User).ToList();

                
            ViewData["DoctorId"] = new SelectList(doctors.Where(d => GetUserRoles(d.User).Contains(AppRoles.Doctor)), "UserId", "User");
            ViewData["RoomCode"] = new SelectList(_context.Rooms, "RoomCode", "RoomCode");

            ViewData["ServiceList"] = new SelectList(_context.Services, "Id", "Summary");

            return Page();
        }

        

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                if(MedicalRecordFile != null)
                {
                    string savePath = await FileProcessor.SaveToAsync(_env, MedicalRecordFile, "medical_records");
                    if(savePath != null)
                    {
                        Appointment.MedicalProfileURL = savePath;
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

                string RoomCode = FindRoomEmpty(Appointment.Time, TimeSpan.FromHours(Appointment.Duration));
                if(RoomCode != null)
                {
                    Appointment.RoomCode = RoomCode;

                    var services = _context.Services.Where(s => Services.Contains(s.Id)).ToList();
                    Appointment.Services = new HashSet<Service>();
                    foreach (var service in services)
                    {
                        Appointment.Services.Add(service);
                    }

                    _context.Appointments.Add(Appointment);
                    _context.SaveChanges();


                    Notification notification = new Notification()
                    {
                        ReceiverId = Appointment.DoctorId,
                        Content = $"Have a appointment from {LoginUser.UserName}",
                        LinkTo = $"https://{HttpContext.Request.Host}/Appointments/Details?id={Appointment.Id}",

                    };

                    _context.Notifications.Add(notification);
                    _context.SaveChanges();
                    
                    await _hubContext.Clients.User(Appointment.DoctorId).SendAsync("receiveNotification", notification);
                    return RedirectToPage("./Details", new { Id=Appointment.Id});
                }
                else
                {
                    Messages.Add(new Utils.Message
                    {
                        Content = "No have any room is free!"
                    }
                    .ToDanger());
                }
            }


            ViewData["CustomerId"] = new SelectList(_context.Customers.Include(cus => cus.User), "UserId", "User");
            ViewData["DoctorId"] = new SelectList(_context.Doctors.Include(d => d.User), "UserId", "User");
            ViewData["RoomCode"] = new SelectList(_context.Rooms, "RoomCode", "RoomCode");

            ViewData["ServiceList"] = new SelectList(_context.Services, "Id", "Summary");

            return Page();
        }

        private string FindRoomEmpty(DateTime start, TimeSpan duration)
        {
            DateTime endTime = start + duration;
            List<Room> rooms = _context.Rooms.Include(r => r.Appointments).ToList();
            foreach(Room room in rooms)
            {
                bool isFree = true;
                foreach (Appointment appointment in room.Appointments)
                {
                    DateTime appEndTime = appointment.Time + TimeSpan.FromHours(appointment.Duration);
                    if(start < appointment.Time && appointment.Time < endTime
                        || start < appEndTime && appEndTime < endTime)
                    {
                        isFree = false;
                        break;
                    }

                }

                if(isFree) return room.RoomCode;
            }

            return null;
        }


    }
}
