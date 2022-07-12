using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string FullName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDay { get; set; }

        public string ImageURL { get; set; } = "/media/images/users/default.png";
    }
}
