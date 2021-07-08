using Jemeppe.Data.Access;
using Jemeppe.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Controllers
{
    public class BookingController : Controller
    {
        BookingAccess _bookingAccess;
        public BookingController(BookingAccess bookingAccess)
        {
            _bookingAccess = bookingAccess;
        }
        /// <summary>
        /// Shows all bookings
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            string CalculatePrice(Data.Model.Booking booking)
            {
                var numOfDays = booking.Enddate.Subtract(booking.Startdate).Days;
                var totalPrice = numOfDays * booking.Room.Price;
                //Verwijder de nullen en display als Currency in Nederlands formaat
                return (Math.Truncate(totalPrice *100)/100).ToString("C",CultureInfo.CreateSpecificCulture("nl-Nl"));
            }
            var bookings = _bookingAccess.GetAllBookings();
            List<BookingViewModel> resultModelCollection = new List<BookingViewModel>();
            foreach(var booking in bookings)
            {
                var model = new BookingViewModel();
                model.FirstName = booking.Customer.Firstname;
                model.LastName = booking.Customer.Lastname;
                model.Kamer = booking.Room.Name;
                model.Prijs = CalculatePrice(booking);
                model.StartDatum = booking.Startdate.ToShortDateString();
                model.EindDatum = booking.Enddate.ToShortDateString();
                resultModelCollection.Add(model);
            }
            
            return View(resultModelCollection.ToArray());
        }
    }
}
