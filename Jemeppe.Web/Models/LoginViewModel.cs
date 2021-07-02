using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Provide valid Email address")]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [MinLength(5, ErrorMessage ="Provide a complex password.")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
