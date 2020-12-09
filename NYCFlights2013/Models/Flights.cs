using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlights2013.Models
{
	public class Flights
	{
		[Key]
		public string year { get; set; }
		public string month { get; set; }
		public string day { get; set; }
		public string dep_time { get; set; }
		public string dep_delay { get; set; }
		public string arr_time { get; set; }
		public string arr_delay { get; set; }
		public string carrier { get; set; }
		public string tailnum { get; set; }
		public string flight { get; set; }
		public string origin { get; set; }
		public string dest { get; set; }
		public string air_time { get; set; }
		public string distance { get; set; }
		public string hour { get; set; }
		public string minute { get; set; }
		public string number { get; set; }
		public string meantime { get; set; }
		public string numberO { get; set; }
		public string top10 { get; set; }
		public string delayD { get; set; }
		public string delayA { get; set; }
	}
}
