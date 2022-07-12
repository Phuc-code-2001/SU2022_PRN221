using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
	[Table("Services")]
	public class Service
	{
        [Key]
		public int Id { get; set; }
        [Required]
        [StringLength(10)]		
		public string ServiceCode { get; set; }
		[Required]
        [StringLength(500)]
		public string Description { get; set; }

        [Required]
        [Range(0, double.MaxValue)]		
		public double Price { get; set; }

		public ICollection<Device> Devices { get; set; }

		public ICollection<Appointment> Appointments { get; set; }

		public Service()
        {
			Devices = new HashSet<Device>();
			Appointments = new HashSet<Appointment>();
        }

		[NotMapped]
		public string Summary => $"{ServiceCode}: {Description}";
	}
}
