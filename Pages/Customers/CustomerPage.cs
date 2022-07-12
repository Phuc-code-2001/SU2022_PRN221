using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using ShinyTeeth.Utils;

namespace ShinyTeeth.Pages.Customers
{
    public class CustomerPage : IdentityPage
    {
        public CustomerPage(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }

        public Customer CreateCustomer(AppUser user)
        {
            Customer customer = new Customer()
            {
                UserId = user.Id,
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            _userManager.AddToRoleAsync(user, AppRoles.Customer).Wait();

            return customer;
        }
    }
}
