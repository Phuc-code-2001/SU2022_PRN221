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
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public string Content { get; set; }
        public Types Type { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        public enum Types
        {
            Sender,
            Receiver
        }

    }
}
