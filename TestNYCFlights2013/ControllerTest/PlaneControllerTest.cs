using NUnit.Framework;
using NYCFlights2013.Controllers;
using NYCFlights2013.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNYCFlights2013.ControllerTest
{
	class PlaneControllerTest
	{
		private PlaneController controller = new PlaneController();
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void TestGetNumOfManufacture()
        {
			var numOfManu = controller.GetNumberOfManufactures();
			int counter = 0;
			foreach(var item in numOfManu)
            {
				string manu = item.manufacturer;
				string model = item.model;
				if(counter == 4)
                {
					Assert.Pass();
                }
				counter++;
			} 
			Assert.Fail();
		}
		[Test]
		public void TestGetNumOfManuFlights()
		{
			var numOfManuF = controller.GetManFlights();
			int counter = 0;
			foreach (var item in numOfManuF)
			{
				string manu = item.manufacturer;
				string numOfFlights = item.numberOfF;
				if (counter == 3)
				{
					Assert.Pass();
				}
				counter++;
			}
			Assert.Fail();
		}

		[Test]
		public void TestGetNumOfAirbus()
		{
			var numOfModel = controller.GetPlanesNumM();
			int counter = 0;
			foreach (var item in numOfModel)
			{
				string manu = item.manufacturer;
				string numOfPlanes = item.numberOfPlanes;
				if (counter == 1)
				{
					Assert.Pass();
				}
				counter++;
			}
			Assert.Fail();
		}
		//Tests passed
	}
}