using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShinyTeeth.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShinyTeeth.Pages.Messages
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("LoadUsers")]
        public IActionResult LoadUsers()
        {
            var userMessages = _context.ChatMessages.Include(cm => cm.User).AsEnumerable().GroupBy(c => c.UserId);
            List<AppUser> userList = new List<AppUser>();
            foreach(var userMessage in userMessages)
            {
                userList.Add(_context.Users.Find(userMessage.Key));
            }

            return Ok(userList.Select(user => new
            {
                img=user.ImageURL,
                username=user.UserName,
                userId=user.Id,
            }));

        }

    }
}
