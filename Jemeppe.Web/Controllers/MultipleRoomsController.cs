using Jemeppe.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Controllers
{
    public class MultipleRoomsController : Controller
    {
        private readonly ILogger<MultipleRoomsController> _logger;

        public MultipleRoomsController(ILogger<MultipleRoomsController> logger)
        {
            _logger = logger;
        }

        public IActionResult DeRodeKamer()
        {
            return View();
        }

        public IActionResult DeAvondenKamer()
        {
            return View();
        }

        public IActionResult DeDonkereKamer()
        {
            return View();
        }

        public IActionResult DeDriestuiversKamer()
        {
            return View();
        }

        public IActionResult DeGeheimeKamer()
        {
            return View();
        }

        public IActionResult DeOpperlandseKamer()
        {
            return View();
        }

        public IActionResult DeVersierdeKamer()
        {
            return View();
        }

        [Authorize]
        public IActionResult DeDerdeKamer()
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
