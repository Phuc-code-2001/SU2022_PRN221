using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("Admins")]
    public class Admin : IUser
    {
        [Key]
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
