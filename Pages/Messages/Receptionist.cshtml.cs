using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Hubs;
using ShinyTeeth.Models;
using ShinyTeeth.PageDefaults;
using System.Collections.Generic;
using System.Linq;

namespace ShinyTeeth.Pages.Messages
{
    [Authorize(Roles = "receptionist,admin")]
    public class ReceptionistModel : IdentityPage
    {

        IHubContext<ChatHub> _chatHubContext;

        public ReceptionistModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IHubContext<ChatHub> chatHubContext) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _chatHubContext = chatHubContext;
        }

        public List<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();
        public string validatedUserId;

        public IActionResult OnGet(string userId)
        {

            if(userId != null)
            {
                AppUser user = _context.Users.Find(userId);
                if(user != null)
                {
                    ChatMessages = _context.ChatMessages.Include(cm => cm.User).Where(cm => cm.UserId == userId).ToList();
                    validatedUserId = userId;
                }
            }

            return Page();
        }

        public IActionResult OnPost(string userId, [FromBody] string content)
        {
            AppUser user = _context.Users.Find(userId);
            if (user == null) return NotFound("User not found!");

            ChatMessage chatMessage = new ChatMessage()
            {
                Type = ChatMessage.Types.Receiver,
                UserId = user.Id,
                Content = content,
            };

            

            _context.ChatMessages.Add(chatMessage);
            _context.SaveChanges();

            _chatHubContext.Clients.All.SendAsync($"administratorListenMessages-{userId}", new
            {
                img = chatMessage.User.ImageURL,
                content = chatMessage.Content,
                time = chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });
            _chatHubContext.Clients.User(user.Id).SendAsync("receiveMessage", new
            {
                img = chatMessage.User.ImageURL,
                content = chatMessage.Content,
                time = chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });

            return new OkResult();
        }

        
        
    }
}
