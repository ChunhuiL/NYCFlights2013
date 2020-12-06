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
    public class PlaneController : Controller
    {
        private string CONNECTION_STRING = "server=localhost;user=root;database=flightdb;port=3306;password=12345";
        public IActionResult Index()
        {
            var planes = GetAllPlanes();

            ViewData["planes"] = planes;
            return View("~/Views/Home/Plane.cshtml");

        }

        public List<Planes> GetAllPlanes()
        {
            var planes = new List<Planes>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {

                    conn.Open();

                    string sql = "SELECT * FROM planes";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        planes.Add(new Planes
                        {
                            tailnum =       rdr[0].ToString(),
                            year =          rdr[1].ToString(),
                            type =          rdr[2].ToString(),
                            manufacturer =  rdr[3].ToString(),
                            model =         rdr[4].ToString(),
                            engines =       rdr[5].ToString(),
                            seats =         rdr[6].ToString(),
                            speed =         rdr[7].ToString(),
                            engine =        rdr[8].ToString()
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
            return planes;
        }
    }
}
