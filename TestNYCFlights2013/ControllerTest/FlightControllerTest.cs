using NUnit.Framework;
using NYCFlights2013.Controllers;
using NYCFlights2013.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNYCFlights2013.ControllerTest
{
	class FlightControllerTest
	{
		private FlightController controller = new FlightController();
		[SetUp]
		public void Setup()
		{
		}
		[Test]
		public void TestGetNumOfFlightsM()
		{
			var numOfFlightsMTest = controller.GetNumOfFlightsM();

			int counter = 0;

			foreach (var numTest in numOfFlightsMTest)
			{
				string monthTest = numTest.month;
				string numberTest = numTest.number;
				if (counter == 4)
				{
					if (monthTest == "5" && numberTest == "13692")
					{
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}

		[Test]
		public void TestGetMeantimeO()
		{
			var meantimeOTest = controller.GetMeantimeO();

			int counter = 0;

			foreach (var meanOTest in meantimeOTest)
			{
				string originTest = meanOTest.origin;
				string meantimeTest = meanOTest.meantime;
				// Check to see if value number 12 contains US Airways Inc with carrier value "US".
				if (counter == 1)
				{
					if (originTest == "JFK" && meantimeTest == "235.3726")
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
		[Test]
		public void TestGetNumOfFlightsO()
		{
			var numOfFlightsMTest = controller.GetNumOfFlightsO();

			int counter = 0;

			foreach (var numMTest in numOfFlightsMTest)
			{
				string originTest = numMTest.origin;
				string monthTest = numMTest.month;
				string numberOTest = numMTest.numberO;
				// Check to see if value number 12 contains US Airways Inc with carrier value "US".
				if (counter == 11)
				{
					if (originTest == "EWR" && monthTest == "12" && numberOTest == "5084")
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
		[Test]
		public void TestGetTopdestM()
		{
			var topdestTest = controller.GetTopdest();

			int counter = 0;

			foreach (var topTest in topdestTest)
			{
				string destTest = topTest.dest;
				string top10Test = topTest.top10;
				// Check to see if value number 12 contains US Airways Inc with carrier value "US".
				if (counter == 3)
				{
					if (destTest == "ATL" && top10Test == "10674")
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
		[Test]
		public void TestGetMeandelay()
		{
			var meandelayTest = controller.GetMeandelay();

			int counter = 0;

			foreach (var meanTest in meandelayTest)
			{
				string originTest = meanTest.origin;
				string delayDTest = meanTest.delayD;
				string delayATest = meanTest.delayA;
				// Check to see if value number 12 contains US Airways Inc with carrier value "US".
				if (counter == 2)
				{
					if (originTest == "LGA" && delayDTest == "7.8196" && delayATest == "2.3666")
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