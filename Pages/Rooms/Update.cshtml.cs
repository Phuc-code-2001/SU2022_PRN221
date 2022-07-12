using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;

namespace ShinyTeeth.Pages.Rooms
{
    public class UpdateModel : IdentityPage
    {
		public UpdateModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
		{

		}

		[BindProperty]
        public Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(string roomCode)
        {
            if (roomCode == null)
            {
                Messages.Add(new Utils.Message
                {
                    Content = "Room not found!"
                }
                .ToDanger());
                return Page();
            }

            Room = await _context.Rooms.FirstOrDefaultAsync(m => m.RoomCode == roomCode);

            if (Room == null)
            {
                Messages.Add(new Utils.Message
                {
                    Content = "Room not found!"
                }
                .ToDanger());
                return Page();
            }

            return Page();
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Room.RoomCode))
                {
                    Messages.Add(new Utils.Message
                    {
                        Content = "Room not found!"
                    }
                    .ToDanger());
                    return Page();
                }
                else
                {
                    return RedirectToPage("/DenyRequest");
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RoomExists(string roomCode)
        {
            return _context.Rooms.Any(e => e.RoomCode == roomCode);
        }
    }
}
