using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using NYCFlights2013.Models;
using Microsoft.AspNetCore.Mvc;

namespace NYCFlights2013.Controllers
{
    public class WeatherController : Controller
    {
        private string CONNECTION_STRING = "server=localhost;user=root;database=flightdb;port=3306;password=12345";
        public IActionResult Index()
        {
            var weather = GetAllWeather();
            var temp_attribute_celcius = GetWeatherTemp();

            ViewData["weather"] = weather;
            ViewData["temp_attribute_celcius"] = temp_attribute_celcius;
            return View("~/Views/Home/Weather.cshtml");

        }

        public List<Weather> GetAllWeather()
        {
            var all_weather = new List<Weather>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {

                    conn.Open();

                    string sql = "SELECT * FROM weather";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        all_weather.Add(new Weather
                        {
                            origin =        rdr[0].ToString(),
                            year =          rdr[1].ToString(),
                            month =         rdr[2].ToString(),
                            day =           rdr[3].ToString(),
                            hour =          rdr[4].ToString(),
                            temp =          rdr[5].ToString(),
                            dewp =          rdr[6].ToString(),
                            humid =         rdr[7].ToString(),
                            wind_dir =      rdr[8].ToString(),
                            wind_speed =    rdr[9].ToString(),
                            wind_gust =     rdr[10].ToString(),
                            precip =        rdr[11].ToString(),
                            pressure =      rdr[12].ToString(),
                            visib =         rdr[13].ToString(),
                            time_hour =     rdr[14].ToString()
                        });
                    }
                    rdr.Close();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return all_weather;
        }
        public List<Weather> GetWeatherTemp()
        {
            List<Weather> temp_attribute_celcius = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {
                    conn.Open();

                    string sql = "SELECT origin, ROUND(((temp - 32) * 5.0 / 9), 2) AS celsius, day, month, year FROM weather";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_celcius.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            temp = rdr[1].ToString(),
                            day = rdr[2].ToString(),
                            month = rdr[3].ToString(),
                            month_letters = MonthToString(rdr[3].ToString()),  // Might not use.
                            year = rdr[4].ToString()
                        }) ;
                    }

                    rdr.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return temp_attribute_celcius;
        }
        public string MonthToString(string month)
		{

            string l_month = null;

            if (month == "1")
                l_month = "Jan";
            if (month == "2")
                l_month = "Feb";
            if (month == "3")
                l_month = "Mar";
            if (month == "4")
                l_month = "Apr";
            if (month == "5")
                l_month = "May";
            if (month == "6")
                l_month = "Jun";
            if (month == "7")
                l_month = "Jul";
            if (month == "8")
                l_month = "Aug";
            if (month == "9")
                l_month = "Sep";
            if (month == "10")
                l_month = "Oct";
            if (month == "11")
                l_month = "Nov";
            if (month == "12")
                l_month = "Dec";
            if (month == null)
                throw new Exception(this.GetType().FullName);

                return l_month;
		}
    }
}
