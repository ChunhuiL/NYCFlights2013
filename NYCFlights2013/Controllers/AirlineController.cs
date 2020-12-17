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
    public class AirlineController : Controller
    {
		ConnectionDB connDB = new ConnectionDB();
        public IActionResult Index()
        {
            var airlines = GetAllAirlines();
            ViewData["airlines"] = airlines;
            return View("~/Views/Home/Airline.cshtml");
        }
        public List<Airlines> GetAllAirlines()
        {
            var airlines = new List<Airlines>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "SELECT * FROM airlines";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        airlines.Add(new Airlines
                        {
                            carrier = rdr[0].ToString(),
                            name = rdr[1].ToString()
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
            return airlines;
        }
    }
}
