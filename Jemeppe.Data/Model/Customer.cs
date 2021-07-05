using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jemeppe.Data.Model
{
    /// <summary>
    /// Customer information
    /// </summary>
    public class Customer: IdentityUser
    {
        /// <summary>
        /// Fist name
        /// </summary>
        public string Firstname { get; set; }
        //Last name
        public string Lastname { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}