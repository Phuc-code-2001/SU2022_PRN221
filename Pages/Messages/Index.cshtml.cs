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
    [Authorize(Roles = "customer")]
    public class IndexModel : IdentityPage
    {

        IHubContext<ChatHub> _chatHubContext;

        public IndexModel(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager, IHubContext<ChatHub> chatHubContext) : base(configuration, signInManager, userManager, context, roleManager)
        {
            _chatHubContext = chatHubContext;
        }

        public List<ChatMessage> chatMessages { get; set; } = new List<ChatMessage>();

        public new IActionResult OnGet()
        {
            AppUser user = LoginUser;
            chatMessages = _context.ChatMessages.Include(cm => cm.User).Where(cm => cm.UserId == user.Id)
                .OrderByDescending(cm => cm.Created)
                .Take(20).OrderBy(cm => cm.Created).ToList();


            return Page();
        }

        public IActionResult OnPost([FromBody] string content) 
        {
            AppUser user = LoginUser;

            ChatMessage chatMessage = new ChatMessage()
            {
                Type = ChatMessage.Types.Sender,
                UserId = user.Id,
                Content = content,
            };

            _context.ChatMessages.Add(chatMessage);
            _context.SaveChanges();

            _chatHubContext.Clients.All.SendAsync($"administratorListenMessages-{user.Id}", new
            {
                img=chatMessage.User.ImageURL,
                content=chatMessage.Content,
                time=chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });
            _chatHubContext.Clients.User(user.Id).SendAsync("receiveMessage", new
            {
                img = chatMessage.User.ImageURL,
                content = chatMessage.Content,
                time = chatMessage.Created.ToLocalTime().ToString(),
                type = chatMessage.Type
            });

            _chatHubContext.Clients.All.SendAsync("newUserComming", new { userId=user.Id, img=user.ImageURL, username=user.UserName });

            return new OkResult();
        }
    }
}
