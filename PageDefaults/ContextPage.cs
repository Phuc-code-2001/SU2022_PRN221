using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShinyTeeth.Models;
using ShinyTeeth.Utils;

namespace ShinyTeeth.PageDefaults
{
    public class ContextPage : PageModel
    {
        protected AppDbContext _context;
        protected IConfiguration _configuration;

        public ContextPage(IConfiguration configuration, AppDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        protected virtual void OnGet()
        {
            LoadMessage();
        }

        [BindProperty] 
        public MessageList Messages { get; set; } = new MessageList();

        public void LoadMessage()
        {
            
            // Tải message từ trang khác gửi qua thông qua TempData, thông thường chỉ có 1 message
            if(TempData.ContainsKey("Message"))
            {
                Message message = JsonConvert.DeserializeObject<Message>(TempData["Message"].ToString());
                Messages.Add(message);
            }
        }

        public void PushMessageBeforeRedirect(Message message)
        {
            TempData["Message"] = JsonConvert.SerializeObject(message);
        }

    }
}
