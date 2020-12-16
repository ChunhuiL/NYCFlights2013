using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlights2013.Models
{
	public class Weather
	{
		[Key]
		public string origin { get; set; }
		public string year { get; set; }
		public string month { get; set; }
		public string day { get; set; }
		public string hour { get; set; }
		public string temp { get; set; }
		public string dewp { get; set; }
		public string humid { get; set; }
		public string wind_dir { get; set; }
		public string wind_speed { get; set; }
		public string wind_gust { get; set; }
		public string precip { get; set; }
		public string pressure { get; set; }
		public string visib { get; set; }
		public string time_hour { get; set; }
		public string mean { get; set; }
		public string observations { get; set; }

	}
}
