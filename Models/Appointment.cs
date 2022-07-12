using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        public string Content { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        [Required]
        public double Duration { get; set; }

        public string MedicalProfileURL { get; set; }
        
        [ForeignKey("Room")]
        public string RoomCode { get; set; }
        public Room Room { get; set; }

        public AppointmentStatus Status { get; set; } = AppointmentStatus.NotYet;

        public ICollection<Service> Services { get; set; }

    }

    public enum AppointmentStatus
    {
        NotYet,
        Cancel,
        Complete,
    }
}
