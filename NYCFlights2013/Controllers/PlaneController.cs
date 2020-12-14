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
        private string CONNECTION_STRING = "server=localhost;user=root;database=flight;port=3306;password=12345";
        public IActionResult Index()
        {
            var planesNumM = GetPlanesNumM();

            ViewData["planesNumM"] = planesNumM;
            return View("~/Views/Home/Plane.cshtml");

        }

        public List<Planes> GetPlanesNumM()
        {
            var planesNumM = new List<Planes>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(CONNECTION_STRING))
                {

                    conn.Open();

                    string sql = "select model,count(model) AS number from planes group by model order BY model asc ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        planesNumM.Add(new Planes
                        {
                            model =         rdr[0].ToString(),
                            number =       rdr[1].ToString(),

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
            return planesNumM;
        }
    }
}
