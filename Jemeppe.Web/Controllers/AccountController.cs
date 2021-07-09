using Jemeppe.Data.Access;
using Jemeppe.Data.Model;
using Jemeppe.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<Customer> _signInManager;
        private CustomerAccess _customerAccess;

        public AccountController(SignInManager<Customer> signInManager, CustomerAccess customerAccess)
        {
            _signInManager = signInManager;
            _customerAccess = customerAccess;
        }

        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.UserName, 
                    model.Password, 
                    model.RememberMe, false);

                if(result.Succeeded)
                {
                    //The user came from an Authorize Action
                    if(Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    //The user navigated directly to the login page
                    return RedirectToAction("Index", "Home");
                }
            }

            //login failed
            ModelState.AddModelError("", "Failed to login");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //No need for a get/post structure when user gets this method just logout and return to home page
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer();
                customer.Email = model.UserName;
                customer.UserName = model.UserName;
                customer.Firstname = model.Firstname;
                customer.Lastname = model.Lastname;
                customer.PhoneNumber = model.Phonenumber;

                var result = await _customerAccess.AddCustomer(customer, model.Password);
                //User was created successfully
                //ToDo: should redirect to a nice success page
                if (result.Successful)
                    return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
