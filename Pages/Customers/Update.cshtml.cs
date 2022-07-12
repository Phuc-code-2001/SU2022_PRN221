using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ShinyTeeth.Pages.Customers
{
    public class UpdateModel : CustomerPage
    {
        public UpdateModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
        {

        }


        [BindProperty]
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string FullName { get; set; }
        [BindProperty]
        [Phone]
        public string PhoneNumber { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }
        [BindProperty]
        public string Address { get; set; }

        public Customer Customer { get; set; }

        public IActionResult OnGet(string Id)
        {
            Customer = _context.Customers.Include(c => c.User).FirstOrDefault(c => c.UserId == Id);
            if(Customer == null)
            {
                Messages.Add(new Utils.Message
                {
                    Content = "Customer not found!"
                }
                .ToDanger());

                return Page();
            }

            if(!IsAdmin && !IsOwner(Id))
            {
                PushMessageBeforeRedirect(new Utils.Message
                {
                    Content = "Method not allowed!"
                }
                .ToDanger());
                return RedirectToPage("/DenyRequest");
            }

            FullName = Customer.User.FullName;
            Address = Customer.Address;
            PhoneNumber = Customer.User.PhoneNumber;
            BirthDay = Customer.User.BirthDay;

            return Page();
        }

        public IActionResult OnPost(string Id)
        {
            if(ModelState.IsValid)
            {

                Customer Customer = _context.Customers.Include(c => c.User).FirstOrDefault(c => c.UserId == Id);
                if (Customer == null)
                {
                    Messages.Add(new Utils.Message
                    {
                        Content = "Customer not found!"
                    }
                    .ToDanger());
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

                Customer.User.FullName = FullName;
                Customer.Address = Address;
                Customer.User.PhoneNumber = PhoneNumber;
                Customer.User.BirthDay = BirthDay;

                _context.Customers.Update(Customer);
                _context.SaveChanges();

                PushMessageBeforeRedirect(new Utils.Message
                {
                    Content = "Update info success!"
                }
                .ToSuccess());

                return RedirectToPage("./Info", new { Id = Id });
            }

            return Page();
        }
    }
}
