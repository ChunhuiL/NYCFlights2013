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

    ConnectionDB connDB = new ConnectionDB();
        public IActionResult Index()
        {
            var planesNumM = GetPlanesNumM();
            var numberOfManufactures = GetNumberOfManufactures();
            var numberOfFlights1 = GetManFlights();
            ViewData["planesNumM"] = planesNumM;
            ViewData["numberOfM"] = numberOfManufactures;
            ViewData["numberOfF1"] = numberOfFlights1;
            return View("~/Views/Home/Plane.cshtml");

        }
        public List<Planes> GetPlanesNumM()
        {
            var planesNumM = new List<Planes>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "SELECT planes.manufacturer, COUNT(*) AS nrPlanes FROM planes GROUP BY planes.manufacturer HAVING planes.manufacturer = 'AIRBUS' OR planes.manufacturer = 'AIRBUS INDUSTRIE'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        planesNumM.Add(new Planes
                        {
                            manufacturer =         rdr[0].ToString(),
                            numberOfPlanes =       rdr[1].ToString(),

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
        public List<Planes> GetNumberOfManufactures()
        {
            var numberOfMa = new List<Planes>();


            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "SELECT planes.manufacturer, COUNT(planes.model) as numM FROM planes GROUP BY manufacturer HAVING COUNT(planes.manufacturer) > 200; ";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        numberOfMa.Add(new Planes
                        {
                            manufacturer = rdr[0].ToString(),
                            numberOfM = rdr[1].ToString(),


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
            return numberOfMa;
        }
        public List<Planes> GetManFlights()
        {
            var numberOfFlMan = new List<Planes>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connDB.GetConnectionString()))
                {

                    conn.Open();

                    string sql = "SELECT planes.manufacturer, COUNT(flights.flight) AS flightNR  FROM planes JOIN flights ON planes.tailnum = flights.tailnum JOIN manu200 ON planes.manufacturer = manu200.manufacture GROUP BY planes.manufacturer HAVING COUNT(planes.manufacturer) >= 200";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.CommandTimeout = 200;
                    MySqlDataReader rdr = cmd.ExecuteReader();


                    while (rdr.Read())
                    {
                        numberOfFlMan.Add(new Planes
                        {
                            manufacturer = rdr[0].ToString(),
                            numberOfF = rdr[1].ToString(),


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
            return numberOfFlMan;
        }
        
    }
}
