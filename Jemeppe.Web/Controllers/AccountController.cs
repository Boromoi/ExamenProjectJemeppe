using Jemeppe.Data.Model;
using Jemeppe.Web.Models;
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

        public AccountController(SignInManager<Customer> signInManager)
        {
            _signInManager = signInManager;
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
                    RedirectToAction("Index", "Home");
                }
            }

            //login failed
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
    }
}
