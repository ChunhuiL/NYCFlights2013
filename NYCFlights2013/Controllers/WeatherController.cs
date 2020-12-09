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
        private string CONNECTION_STRING = "server=localhost;user=root;database=flight;port=3305;password=123456";

        public IActionResult Index()
        {
            var weather = GetAllWeather();

            ViewData["weather"] = weather;
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
    }
}
