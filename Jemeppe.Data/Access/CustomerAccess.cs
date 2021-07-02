using Jemeppe.Data;
using Jemeppe.Data.Model;
using Microsoft.AspNetCore.Identity;
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
        UserManager<Customer> _userManager;

        public CustomerAccess(JemeppeContext context, UserManager<Customer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Add a new customer to the database
        /// </summary>
        /// <param name="customer"></param>
        public async Task<Result> Add(Customer customer, string password)
        {
            var exisits = await GetCustomer(customer.Email);
            if(exisits != null)
            {
                return Result.Failed("Cannot create new customer, customer email already exists");
            }
            customer.Email = customer.Email.ToLowerInvariant();
            var result = await _userManager.CreateAsync(customer,password);
            if(result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create new user");
            }
            
            return Result.Success();
        }

        /// <summary>
        /// Get the customer data by it's email address
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Customer> GetCustomer(string email)
        {
            email = email.ToLowerInvariant();
            Customer customer = await _userManager.FindByEmailAsync(email);
            //return _context.Customers.SingleOrDefault(c => c.Email==email);
            return customer;
        }
    }
}
