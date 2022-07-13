using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("ChatMessages")]
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AppUser")]
        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public AppUser Sender { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

    }
}
