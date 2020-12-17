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
    public class FlightController : Controller
    {

    ConnectionDB connDB = new ConnectionDB();
        public IActionResult Index()
        {

            var flights = GetAllFlights();
            var numOfFlightsM = GetNumOfFlightsM();
            var meantimeO = GetMeantimeO();
            var numOfFlightsO = GetNumOfFlightsO();
            var flightsToTop10Dest = GetFlightsToTop10Dest();
            var meandelay = GetMeandelay();
            var topdest = GetTopdest();
            ViewData["meandelay"] = meandelay;
            ViewData["topdest"] = topdest;
            ViewData["numOfFlightsO"] = numOfFlightsO;
            ViewData["flights"] = flights;
            ViewData["numOfFlightsM"] = numOfFlightsM;
            ViewData["flightsToTop10Dest"] = flightsToTop10Dest;
            ViewData["meantimeO"] = meantimeO;
            return View("~/Views/Home/Flight.cshtml");

        }
        public List<Flights> GetAllFlights()
        {
            var flights = new List<Flights>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "SELECT * FROM flights";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        flights.Add(new Flights
                        {
                            year = rdr[0].ToString(),
                            month = rdr[1].ToString(),
                            day = rdr[2].ToString(),
                            dep_time = rdr[3].ToString(),
                            dep_delay = rdr[4].ToString(),
                            arr_time = rdr[5].ToString(),
                            arr_delay = rdr[6].ToString(),
                            carrier = rdr[7].ToString(),
                            tailnum = rdr[8].ToString(),
                            flight = rdr[9].ToString(),
                            origin = rdr[10].ToString(),
                            dest = rdr[11].ToString(),
                            air_time = rdr[12].ToString(),
                            distance = rdr[13].ToString(),
                            hour = rdr[14].ToString(),
                            minute = rdr[15].ToString()
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
            return flights;
        }
        public List<Flights> GetNumOfFlightsM()
        {
            List<Flights> numOfFlightsM = new List<Flights>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "select month,count(month) AS number from flights where YEAR = 2013 group by month order BY MONTH asc  ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        numOfFlightsM.Add(new Flights
                        {
                            month = rdr[0].ToString(),
                            number = rdr[1].ToString()
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

            return numOfFlightsM;
        }
        public List<Flights> GetMeantimeO()
        {
            List<Flights> meantimeO = new List<Flights>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin,  AVG(air_time) AS meantime FROM flights GROUP BY origin";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        meantimeO.Add(new Flights
                        {
                            origin = rdr[0].ToString(),
                            meantime = rdr[1].ToString()
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

            return meantimeO;
        }
        public List<Flights> GetNumOfFlightsO()
        {
            List<Flights> numOfFlightsO = new List<Flights>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin , MONTH , COUNT(origin) AS numberO FROM `flights` GROUP BY origin , month ORDER BY origin , month ASC";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        numOfFlightsO.Add(new Flights
                        {
                            origin = rdr[0].ToString(),
                            month = rdr[1].ToString(),
                            numberO = rdr[2].ToString()
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

            return numOfFlightsO;
        }
        public List<Flights> GetTopdest()
        {
            List<Flights> topdest = new List<Flights>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT dest, COUNT(dest) AS top10 FROM `flights` GROUP BY dest ORDER BY COUNT(dest) DESC LIMIT 10";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        topdest.Add(new Flights
                        {
                            dest = rdr[0].ToString(),
                            top10 = rdr[1].ToString()
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

            return topdest;
        }

        public List<Flights> GetFlightsToTop10Dest()
        {
            List<Flights> flightsToTop10 = new List<Flights>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin, dest, COUNT(dest) AS top10 FROM `flights` GROUP BY origin, dest ORDER BY origin, top10 DESC";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        flightsToTop10.Add(new Flights
                        {
                            origin = rdr[0].ToString(),
                            dest = rdr[1].ToString(),
                            top10 = rdr[2].ToString()
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
            return flightsToTop10;
        }

        public List<Flights> GetMeandelay()
        {
            List<Flights> meandelay = new List<Flights>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {
                    conn.Open();

                    string sql = "SELECT origin,  AVG(dep_delay) AS delayD, AVG(arr_delay) AS delayA FROM flights GROUP BY origin";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        meandelay.Add(new Flights
                        {
                            origin = rdr[0].ToString(),
                            delayD = rdr[1].ToString(),
                            delayA = rdr[2].ToString()
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
            return meandelay;
        }
    }
}
          
