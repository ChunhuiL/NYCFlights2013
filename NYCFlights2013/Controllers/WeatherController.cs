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
            var temp_attribute_celcius_date = GetWeatherTempDate();
            var temp_attribute_celciusJFK = GetWeatherTempAtJFK();

            var temp_attribute_daily_mean = GetDailyMeanTemp();
            var temp_attribute_daily_mean_JFK = GetDailyMeanTempJFK();
            var weatherObs = GetWeatherOb();

            ViewData["weather"] = weather;
            ViewData["temp_attribute_celcius"] = temp_attribute_celcius;
            ViewData["temp_attribute_celcius_date"] = temp_attribute_celcius_date;
            ViewData["temp_attribute_celciusJFK"] = temp_attribute_celciusJFK;

            ViewData["temp_attribute_daily_mean"] = temp_attribute_daily_mean;
            ViewData["temp_attribute_daily_mean_JFK"] = temp_attribute_daily_mean_JFK;
            ViewData["weatherObs"] = weatherObs;

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
                            origin = rdr[0].ToString(),
                            year = rdr[1].ToString(),
                            month = rdr[2].ToString(),
                            day = rdr[3].ToString(),
                            hour = rdr[4].ToString(),
                            temp = rdr[5].ToString(),
                            dewp = rdr[6].ToString(),
                            humid = rdr[7].ToString(),
                            wind_dir = rdr[8].ToString(),
                            wind_speed = rdr[9].ToString(),
                            wind_gust = rdr[10].ToString(),
                            precip = rdr[11].ToString(),
                            pressure = rdr[12].ToString(),
                            visib = rdr[13].ToString(),
                            time_hour = rdr[14].ToString()
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
        public List<Weather> GetWeatherOb()
        {
            var weatherOb = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "select weather.origin,count(*) AS `Weather Observations` from weather group by origin;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        weatherOb.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            observations = rdr[1].ToString()

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
            return weatherOb;
        }
        public List<Weather> GetWeatherTemp()
        {
            List<Weather> temp_attribute_celcius = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin, ROUND(((temp - 32) * 5.0 / 9), 2) AS temp FROM weather WHERE temp IS NOT NULL";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_celcius.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            temp = rdr[1].ToString()
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

            return temp_attribute_celcius;
        }

        public List<Weather> GetWeatherTempDate()
        {
            List<Weather> temp_attribute_celcius_date = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT day, month, year FROM weather";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_celcius_date.Add(new Weather
                        {
                            day = rdr[0].ToString(),
                            month = rdr[1].ToString(),
                            year = rdr[2].ToString()
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

            return temp_attribute_celcius_date;
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
        public List<Weather> GetDailyMeanTemp()
        {
            List<Weather> temp_attribute_daily_mean = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin, year, month, day, ROUND((SUM((temp - 32) * 5.0 / 9) /24), 2) AS mean FROM weather GROUP BY origin,year,month,day";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_daily_mean.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            year = rdr[1].ToString(),
                            month = rdr[2].ToString(),
                            day = rdr[3].ToString(),
                            mean = rdr[4].ToString()
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

            return temp_attribute_daily_mean;
        }

        public List<Weather> GetDailyMeanTempJFK()
        {
            List<Weather> temp_attribute_daily_mean_JFK = new List<Weather>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin, year, month, day, ROUND((SUM((temp - 32) * 5.0 / 9) /24), 2) AS mean FROM weather WHERE origin LIKE '%JFK%' GROUP BY origin,year,month,day";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        temp_attribute_daily_mean_JFK.Add(new Weather
                        {
                            origin = rdr[0].ToString(),
                            year = rdr[1].ToString(),
                            month = rdr[2].ToString(),
                            day = rdr[3].ToString(),
                            mean = rdr[4].ToString()
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

            return temp_attribute_daily_mean_JFK;
        }
    }
}