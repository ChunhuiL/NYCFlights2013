using NUnit.Framework;
using NYCFlights2013.Controllers;
using NYCFlights2013.Models;
using System;
using System.Collections.Generic;

namespace TestNYCFlights2013.ControllerTest
{
	class AirlineControllerTest
	{
		private AirlineController controller = new AirlineController();
		[SetUp]
		public void Setup()
		{
		}
		[Test]
		public void TestOneGetAllAirlines()
		{
			var airlinesTest = controller.GetAllAirlines();

			int counter = 0;

			foreach (var airTest in airlinesTest)
			{
				string nameTest = airTest.name;
				string carrierTest = airTest.carrier;
				// Check to see if value number 12 contains US Airways Inc with carrier value "US".
				if (counter == 12)
				{
					if (nameTest == "US Airways Inc." && carrierTest == "US")
					{
						// Console.WriteLine(nameTest);
						// Console.WriteLine(carrierTest);
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}
		}
}
