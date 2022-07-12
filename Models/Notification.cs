using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("Notifications")]
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("AppUser")]
        public string ReceiverId { get; set; }
        [ForeignKey("ReceiverId")]
        public AppUser Receiver { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string LinkTo { get; set; }

        public int Status { get; set; }

    }
}
