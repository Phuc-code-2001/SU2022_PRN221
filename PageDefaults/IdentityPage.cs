using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShinyTeeth.Models;
using ShinyTeeth.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTeeth.PageDefaults
{
    public class IdentityPage : ContextPage
    {
        protected UserManager<AppUser> _userManager;
        protected SignInManager<AppUser> _signInManager;
        protected RoleManager<IdentityRole> _roleManager;

        public IdentityPage(IConfiguration configuration, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, AppDbContext context, RoleManager<IdentityRole> roleManager) : base(configuration, context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected override void OnGet()
        {
            base.OnGet();
        }

        // 1. Xác thực người dùng
        public bool IsAuthenticated => User.Identity.IsAuthenticated;

        // 2. Lấy thông tin về tài khoản xác thực
        public AppUser LoginUser => GetLoginUser();
        private AppUser GetLoginUser()
        {
            if(IsAuthenticated)
            {
                string username = User.Identity.Name;
                AppUser loginUser = _context.Users.FirstOrDefault(u => u.UserName == username);
                return loginUser;
            }

            return null;
        }

        // 3. Kiểm tra quyền hạn của user
        public List<string> GetUserRoles(AppUser User)
        {
            List<string> roles = new List<string>();
            if(User != null)
            {
                var userRoles = _context.UserRoles.Where(item => item.UserId == User.Id).ToList();
                foreach(var userRole in userRoles)
                {
                    var role = _context.Roles.Find(userRole.RoleId);
                    roles.Add(role.Name);
                }
            }
            return roles;
        }

        public bool IsAdmin => GetUserRoles(LoginUser).Contains(AppRoles.Admin);
        
        public bool IsOwner(string UserId)
        {
            return LoginUser?.Id == UserId;
        }
    }
}
