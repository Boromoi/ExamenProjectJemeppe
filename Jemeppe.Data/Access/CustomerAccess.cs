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
        public async Task<Result> AddCustomer(Customer customer, string password)
        {
            //check if cusomter exists
            var exisits = await _userManager.FindByEmailAsync(customer.Email);
            if(exisits != null)
            {
                return Result.Failed("Cannot create new customer, customer email already exists");
            }

            //Create account
            var result = await _userManager.CreateAsync(customer, password);
            if (result != IdentityResult.Success)
                throw new InvalidOperationException("Could not Add new user");

            //Add customer role to the account
            var fqUser = await _userManager.FindByEmailAsync(customer.Email);
            result = await _userManager.AddToRoleAsync(fqUser, "Customer");
            if (!result.Succeeded)
                throw new InvalidOperationException("Adding admin role to admin user failed:");
            
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
            return customer;
        }
    }
}
