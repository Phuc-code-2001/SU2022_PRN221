using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
    [Table("Doctors")]
    public class Doctor : IUser
    {
        [Key]
        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser User { get; set; }

        public string QualificationURL { get; set; }
        public string Major { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

    }
}
