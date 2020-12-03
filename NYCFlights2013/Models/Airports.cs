using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlight2013.Model
{
	public class Airports
	{
		[Key]
		public string faa { get; set; }
		public string name { get; set; }
		public string lat { get; set; }
		public string lon { get; set; }
		public string alt { get; set; }
		public string tz { get; set; }
		public string dst { get; set; }
		public string tzone { get; set; }
	}
}
