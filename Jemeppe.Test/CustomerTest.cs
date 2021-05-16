using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jemeppe.Test
{
    [TestClass]
    public class CustomerTest
    {
        public static Domain.Model.Customer CreateDummyCustomer1()
        {
            var customer = new Domain.Model.Customer
            {
                Address = "Kerkstraat 23, Amsterdam",
                Email = "Piet.Klaasen@hotmail.com",
                Name = "Piet Klaasen",
                PasswordHash = "ToBeEncrypted",
                PhoneNumber = "1234567890"
            };
            return customer;
        }

        [TestMethod]
        public void AddNewCustomer()
        {
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryDatabase("Customers");
            using (var context = new Jemeppe.Data.JemeppeContext(builder.Options))
            {
                var customer = CreateDummyCustomer1();
                context.Customers.Add(customer);
                Assert.AreEqual(EntityState.Added, context.Entry(customer).State);
            }
        }
    }
}
