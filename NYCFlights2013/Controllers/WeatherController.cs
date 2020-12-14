using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;
using NYCFlights2013.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NYCFlights2013.Controllers
{
    public class WeatherController : Controller
    {

    ConnectionDB connDB = new ConnectionDB();
        public IActionResult Index()
        {
            var weather = GetAllWeather();
            var temp_attribute_celcius = GetWeatherTemp();
            var temp_attribute_celciusJSON = GetWeatherTemp();
            var temp_attribute_celciusJFK = GetWeatherTempAtJFK();
            var temp_attribute_dailyMeanTempJFK = GetDailyMeanTempJFK();

            ViewData["weather"] = weather;
            ViewData["temp_attribute_celcius"] = temp_attribute_celcius;
            ViewData["temp_attribute_celciusJSON"] = JsonSerializer.Serialize(temp_attribute_celciusJSON);
            ViewData["temp_attribute_celciusJFK"] = temp_attribute_celciusJFK;
            ViewData["temp_attribute_dailyMeanTempJFK"] = temp_attribute_dailyMeanTempJFK;
            return View("~/Views/Home/Weather.cshtml");

        }

        public List<Weather> GetAllWeather()
        {
            var all_weather = new List<Weather>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
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
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
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

        public List<Weather> GetWeatherTempAtJFK()
        {
            List<Weather> temp_attribute_celciusJFK = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin, ROUND(((temp - 32) * 5.0 / 9), 2) AS celsius, day, month, year FROM weather WHERE origin LIKE '%JFK%'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_celciusJFK.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            temp = rdr[1].ToString(),
                            day = rdr[2].ToString(),
                            month = rdr[3].ToString(),
                            year = rdr[4].ToString()
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

            return temp_attribute_celciusJFK;
        }

        public List<Weather> GetDailyMeanTempJFK()
        {
            List<Weather> temp_attribute_dailyMeanTempJFK = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "?";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_dailyMeanTempJFK.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            temp = rdr[1].ToString(),
                            day = rdr[2].ToString(),
                            month = rdr[3].ToString(),
                            year = rdr[4].ToString()
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

            return temp_attribute_dailyMeanTempJFK;
        }

    }
}
