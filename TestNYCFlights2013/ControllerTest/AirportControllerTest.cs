using NUnit.Framework;
using NYCFlights2013.Controllers;
using NYCFlights2013.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNYCFlights2013.ControllerTest
{
	class AirportControllerTest
	{
		private AirportController controller = new AirportController();
		[SetUp]
		public void Setup()
		{
		}
		//TODO: Write test assertions for each method.
		[Test]
		public void TestGetAllAirports()
		{
			var airportsTest = controller.GetAllAirports();

			int counter = 0;

			foreach (var airTest in airportsTest)
			{
				string faaTest = airTest.faa;
				string nameTest = airTest.name;
				string latTest = airTest.lat;
				string lonTest = airTest.lon;
				string altTest = airTest.alt;
				string tzTest = airTest.tz;
				string dstTest = airTest.dst;
				string tzoneTest = airTest.tzone;
				// Check to see if value number 12 contains US Airways Inc with carrier value "US".
				if (counter == 12)
				{
					if (faaTest == "17G" && nameTest == "Port Bucyrus-Crawford County Airport" && latTest == "41" && lonTest == "-83" 
						&& altTest == "1003" && tzTest == "-5" && dstTest == "A" && tzoneTest == "America/New_York")
					{
						 Console.WriteLine(faaTest);
						 Console.WriteLine(nameTest);
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}
	}
}
