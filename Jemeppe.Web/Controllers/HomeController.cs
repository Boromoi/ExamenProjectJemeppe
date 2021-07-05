using Jemeppe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //De main page waar je op begint.
        public IActionResult Index()
        {
            return View();
        }

        //Waar je alle kamers kan zien page.
        public IActionResult Rooms()
        {
            return View();
        }

        //Login-Register Page.
        public IActionResult SignIn()
        {
            return RedirectToAction("Login", "Account");
        }

        //De page waar je al het contact info vind van het hotel.
        public IActionResult Contact()
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
