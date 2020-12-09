using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NYCFlights2013.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NYCFlights2013.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Flight()
		{
			return View();
		}
		
		public IActionResult Plane()
		{
			return View();
		}

		public IActionResult Weather()
		{
			return View();
		}

		public IActionResult Airline()
		{
			return View();
		}

		public IActionResult Airport()
		{
			return View();
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
