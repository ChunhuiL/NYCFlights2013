using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlights2013.Models
{
	public class ConnectionDB
	{
		//private string CONNECTION_STRING = "server=localhost;user=root;database=flightDB;port=3306;password=12345";
		private string CONNECTION_STRING = "server=34.76.189.231;user=root;database=NYCFlight2013;port=3306;password=12345";

		public string GetConnectionString()
		{
			//test
			return CONNECTION_STRING;
		}

	}
}
