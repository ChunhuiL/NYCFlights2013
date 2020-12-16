using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlights2013.Models
{
	public class Planes
	{
		[Key]
		public string tailnum { get; set; }
		public string year { get; set; }
		public string type { get; set; }
		public string manufacturer { get; set; }
		public string model { get; set; }
		public string engines { get; set; }
		public string seats { get; set; }
		public string speed { get; set; }
		public string engine { get; set; }
		public string numberOfPlanes { get; set; }
		public string numberOfM { get; set; }
		public string numberOfF { get; set; }
	}
}
