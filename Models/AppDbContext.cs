using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShinyTeeth.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Device> Devices { get; set; }

        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<FeedBack> FeedBacks { get; set; }

        public DbSet<ChatMessage> ChatMessages { get; set; }

    }

    public class Initializer
    {
        public static void CreateSuperUser(AppDbContext context, UserManager<AppUser> userManager) 
        {
            if (context.Admins.Any()) return;

            AppUser adminUser = new AppUser()
            {
                UserName = "Admin",
                Email = "Admin@example.com",
                FullName = "Admin",
            };

            string password = "123456";

            userManager.CreateAsync(adminUser, password);
            userManager.AddToRoleAsync(adminUser, AppRoles.Admin);

            Admin admin = new Admin()
            {
                UserId = adminUser.Id,
            };
            context.Admins.Add(admin);
            context.SaveChanges();

        }

        public static async Task CreateRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            List<string> roles = AppRoles.Items;
            foreach(string roleName in roles)
            {
                if (await roleManager.RoleExistsAsync(roleName)) continue;
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
    }
}
