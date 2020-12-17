using NUnit.Framework;
using NYCFlights2013.Controllers;
using NYCFlights2013.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNYCFlights2013.ControllerTest
{
	class WeatherControllerTest
	{
		private WeatherController controller = new WeatherController();
		[SetUp]
		public void Setup()
		{
		}
		[Test]
		public void TestGetWeatherTemp()
		{
			var temp_attribute_celciusTest = controller.GetWeatherTemp();

			int counter = 0;

			foreach (var tacTest in temp_attribute_celciusTest)
			{
				string originTest = tacTest.origin;
				string tempTest = tacTest.temp;
				if (counter == 5)
				{
					if (originTest == "EWR" && tempTest == "3.89")
					{
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}
		[Test]
		public void TestGetWeatherTempDate()
		{
			var temp_attribute_celcius_dateTest = controller.GetWeatherTempDate();

			int counter = 0;

			foreach (var tacdTest in temp_attribute_celcius_dateTest)
			{
				string dayTest = tacdTest.day;
				string monthTest = tacdTest.month;
				string yearTest = tacdTest.year;
				if (counter == 12)
				{
					if (dayTest == "1" && monthTest == "1" && yearTest == "2013")
					{
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}
		[Test]
		public void TestGetWeatherTempAtJFK()
		{
			var temp_attribute_celciusJFKTest = controller.GetWeatherTempAtJFK();

			int counter = 0;

			foreach (var tacjTest in temp_attribute_celciusJFKTest)
			{
				string originTest = tacjTest.origin;
				string tempTest = tacjTest.temp;
				string dayTest = tacjTest.day;
				string monthTest = tacjTest.month;
				string yearTest = tacjTest.year;
				
				if (counter == 5)
				{
					if (originTest == "JFK" && tempTest == "3.89" && dayTest == "1"
						&& monthTest == "1" && yearTest == "2013")
					{
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}
		[Test]
		public void TestGetDailyMeanTemp()
		{
			var temp_attribute_daily_meanTest = controller.GetDailyMeanTemp();

			int counter = 0;

			foreach (var tadmTest in temp_attribute_daily_meanTest)
			{
				string originTest = tadmTest.origin;
				string dayTest = tadmTest.day;
				string monthTest = tadmTest.month;
				string yearTest = tadmTest.year;
				string meanTest = tadmTest.mean;
				if (counter == 5)
				{
					if (originTest == "EWR" && meanTest == "3.33" && dayTest == "6"
						&& monthTest == "1" && yearTest == "2013")
					{
						Assert.Pass();
					}
				}
				counter++;
			}
			Assert.Fail();
		}
		[Test]
		public void TestGetDailyMeanTempJFK()
		{
			var temp_attribute_daily_mean_JFKTest = controller.GetDailyMeanTempJFK();

			int counter = 0;

			foreach (var tadmjTest in temp_attribute_daily_mean_JFKTest)
			{
				string originTest = tadmjTest.origin;
				string dayTest = tadmjTest.day;
				string monthTest = tadmjTest.month;
				string yearTest = tadmjTest.year;
				string meanTest = tadmjTest.mean;
				if (counter == 5)
				{
					if (originTest == "JFK" && meanTest == "3.06" && dayTest == "6"
						&& monthTest == "1" && yearTest == "2013")
					{
						
						Assert.Pass();
					}
				}Console.WriteLine(originTest);
						Console.WriteLine(meanTest);
				counter++;
			}
			Assert.Fail();
		}
	}
}