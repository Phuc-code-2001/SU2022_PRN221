using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("Customers")]
    public class Customer : IUser
    {
        [Key]
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public string Address { get; set; }

        
        public DateTime Created { get; set; } = DateTime.Now;
        

    }
}
