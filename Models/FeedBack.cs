using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("FeedBacks")]
    public class FeedBack
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Appointment")]
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public int Point { get; set; }

        public string Content { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

    }
}
