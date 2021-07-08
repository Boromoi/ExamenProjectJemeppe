using Jemeppe.Data.Access;
using Jemeppe.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private BookingAccess _bookingAccess;
        private RoomAccess _roomAccess;

        public MultipleRoomsController(ILogger<MultipleRoomsController> logger, BookingAccess bookingAccess, RoomAccess roomAccess)
        {
            _logger = logger;
            _bookingAccess = bookingAccess;
            _roomAccess = roomAccess;
        }

        [HttpGet]
        public IActionResult DeDerdeKamer()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeDerdeKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 4, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeRodeKamer()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeRodeKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 1, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeAvondenKamer()
        {
            var room = _roomAccess.GetRoomById(2);
            var viewModel = new BookingViewModel();
            RoomController.FillRoomViewModelWithRoom(viewModel, room);
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeAvondenKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 2, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeDonkereKamer()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeDonkereKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 5, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeDriestuiversKamer()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeDriestuiversKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 7, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeGeheimeKamer()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult DeGeheimeKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 8, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeOpperlandseKamer()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeOpperlandseKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 6, startDate, endDate);
            return View();
        }

        [HttpGet]
        public IActionResult DeVersierdeKamer()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult DeVersierdeKamer(BookingViewModel model)
        {
            var email = User.Identity.Name;
            var startDate = DateTime.Parse(model.StartDatum);
            var endDate = DateTime.Parse(model.EindDatum);
            _bookingAccess.CreateBooking(email, 3, startDate, endDate);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
