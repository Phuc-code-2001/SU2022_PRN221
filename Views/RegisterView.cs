using ShinyTeeth.Models;
using System.ComponentModel.DataAnnotations;

namespace ShinyTeeth.Views
{
    public class RegisterView : AppUser
    {
        [Required]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 6)]
        public string FirstPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("FirstPassword")]
        public string SecondPassword { get; set; }

        [Required]
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        [Required]
        [EmailAddress]
        public override string Email { get => base.Email; set => base.Email = value; }
    
        
    }
}
