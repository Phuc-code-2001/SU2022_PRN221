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

namespace ShinyTeeth.Pages.Rooms
{
    public class DeleteModel : IdentityPage
    {
		public DeleteModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, signInManager, userManager, context, roleManager)
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

        public async Task<IActionResult> OnPostAsync(string roomCode)
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

            Room = await _context.Rooms.FindAsync(roomCode);

            if (Room != null)
            {
                _context.Rooms.Remove(Room);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
