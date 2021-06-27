using Jemeppe.Data;
using Jemeppe.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Data.Access
{
    /// <summary>
    /// Contains all data access methods needed for Create Read Update and Delete of Customers
    /// </summary>
    public class CustomerAccess
    {
        JemeppeContext _context;
        public CustomerAccess(JemeppeContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(string email)
        {
            return _context.Customers.Single(c => string.Equals(c.Email, email, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
