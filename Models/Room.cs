using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShinyTeeth.Models
{
	[Table("Rooms")]
	public class Room
	{
		[Key]
		[Required]
		[StringLength(15)]
		public string RoomCode { get; set; }
		[Required]
		[StringLength(150)]
		public string Description { get; set; }

		public ICollection<Appointment> Appointments { get; set; }
	}
}
