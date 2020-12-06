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
        private string CONNECTION_STRING = "server=localhost;user=root;database=flightdb;port=3306;password=12345";
        public IActionResult Index()
        {
            var flights = GetAllFlights();

            ViewData["flights"] = flights;
            return View("~/Views/Home/Flight.cshtml");

        }

        public List<Flights> GetAllFlights()
        {
            var flights = new List<Flights>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {

                    conn.Open();

                    string sql = "SELECT * FROM flights";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        flights.Add(new Flights
                        {
                            year =      rdr[0].ToString(),
                            month =     rdr[1].ToString(),
                            day =       rdr[2].ToString(),
                            dep_time =  rdr[3].ToString(),
                            dep_delay = rdr[4].ToString(),
                            arr_time =  rdr[5].ToString(),
                            arr_delay = rdr[6].ToString(),
                            carrier =   rdr[7].ToString(),
                            tailnum =   rdr[8].ToString(),
                            flight =    rdr[9].ToString(),
                            origin =    rdr[10].ToString(),
                            dest =      rdr[11].ToString(),
                            air_time =  rdr[12].ToString(),
                            distance =  rdr[13].ToString(),
                            hour =      rdr[14].ToString(),
                            minute =    rdr[15].ToString()
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
    }
}
