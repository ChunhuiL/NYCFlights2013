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
            var airlines = GetAllAirlines();

            ViewData["airlines"] = airlines;
            return View("~/Views/Home/Flight.cshtml");

        }

        public List<Airlines> GetAllAirlines()
        {
            var airlines = new List<Airlines>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {

                    conn.Open();

                    string sql = "SELECT * FROM airlines";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        airlines.Add(new Airlines { carrier = rdr[0].ToString(), name = rdr[1].ToString() });

                    }
                    rdr.Close();
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return airlines;
        }
    }
}
