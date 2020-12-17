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

			List<string> carrierList = new List<string>() {
				"9E", "AA", "AS", "B6",
				"DL", "EV", "F9", "FL",
				"HA", "MQ", "OO", "UA",
				"US", "VX", "WN", "YV" };

			List<string> nameList = new List<string>() {
				"Endeavor Air Inc.",
				"American Airlines Inc.",
				"Alaska Airlines Inc.",
				"JetBlue Airways",
				"Delta Air Lines Inc.",
				"ExpressJet Airlines Inc.",
				"Frontier Airlines Inc.",
				"AirTran Airways Corporation",
				"Hawaiian Airlines Inc.",
				"Envoy Air",
				"SkyWest Airlines Inc.",
				"United Air Lines Inc.",
				"US Airways Inc.",
				"Virgin America",
				"Southwest Airlines Co.",
				"Mesa Airlines Inc."
			};

			int counter;

			Random rnd = new Random();

			foreach (var airTest in airlinesTest)
			{
				counter = rnd.Next(0, 15);
				string nameTest = airTest.name;
				string carrierTest = airTest.carrier;
				if (nameTest == nameList[counter] && carrierTest == carrierList[counter])
				{
					Assert.Pass();
				}
			}
			Assert.Fail();
		}
	}
}