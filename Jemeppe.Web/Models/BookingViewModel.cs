using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Models
{
    public class BookingViewModel:RoomViewModel
    {
        public string StartDatum { get; set; }
        public string EindDatum { get; set; }

        public string Kamer { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Prijs { get; set; }
    }
}
