using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlights2013.Models
{
	public class Airlines
	{
		[Key]
		public string carrier { get; set; }
		public string name { get; set; }

	}
}
