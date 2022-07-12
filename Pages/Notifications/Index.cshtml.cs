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

namespace ShinyTeeth.Pages.Notifications
{
    public class IndexModel : IdentityPage
    {
        public IndexModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {
        }

        public IList<Notification> Notification { get;set; }

        public async Task OnGetAsync()
        {
            Notification = await _context.Notifications
                .Include(n => n.Receiver).ToListAsync();
        }
    }
}
