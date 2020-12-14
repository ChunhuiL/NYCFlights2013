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
    public class AirportController : Controller
    {
        ConnectionDB connDB = new ConnectionDB();
        public IActionResult Index()
        {
            var airports = GetAllAirports();

            ViewData["airports"] = airports;
            return View("~/Views/Home/Airport.cshtml");

        }

        public List<Airports> GetAllAirports()
        {
            var airports = new List<Airports>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "SELECT * FROM airports";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        airports.Add(new Airports
                        {
                            faa =   rdr[0].ToString(),
                            name =  rdr[1].ToString(),
                            lat =   rdr[2].ToString(),
                            lon =   rdr[3].ToString(),
                            alt =   rdr[4].ToString(),
                            tz =    rdr[5].ToString(),
                            dst =   rdr[6].ToString(),
                            tzone = rdr[7].ToString()
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
            return airports;
        }
    }
}
