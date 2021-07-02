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
        public List<Booking> Bookings { get; set; }
    }
}