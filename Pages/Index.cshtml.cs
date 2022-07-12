﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.Pages
{
    public class IndexModel : IdentityPage
    {

        public IndexModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }


        public new IActionResult OnGet()
        {
            base.OnGet();

            if(IsAuthenticated)
            {
                ViewData["Notifications"] = _context.Notifications.Where(n => n.ReceiverId == LoginUser.Id)
                    .OrderBy(n => n.Status)
                    .ThenByDescending(n => n.Created).Take(10).ToList();
                ViewData["NotificationsMaxCount"] = _context.Notifications.Where(n => n.ReceiverId == LoginUser.Id).Count();

                ViewData["Appointments"] = _context.Appointments.Where(a => a.CustomerId == LoginUser.Id || a.DoctorId == LoginUser.Id).ToList();
            
            }

            ViewData["Services"] = _context.Services.ToList();

            return Page();
        }

        

    }
}
