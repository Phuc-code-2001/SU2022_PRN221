using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
	[Table("Devices")]
	public class Device
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[StringLength(6)]
		public string DeviceCode { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Description { get; set; }
		[Range(0, double.MaxValue)]
		public double Value { get; set; }

		[ForeignKey("Room")]
		public string RoomCode { get; set; }
		public Room Room { get; set; }

		public bool Status { get; set; } = true;
		
		[DataType(DataType.Date)]
		public DateTime ImportDate { get; set; } = DateTime.Now;

		public ICollection<Service> Services { get; set; }

		public Device()
        {
			Services = new HashSet<Service>();
		}
		
	}
}
