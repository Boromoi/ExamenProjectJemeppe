using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Jemeppe.Web.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Provide valid Email address")]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Provide a complex password, of at least 5 characters long.")]
        [DataType(DataType.Password)]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Enter the same password as in the previous field")]
        public string PasswordValidation { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phonenumber { get; set; }

        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(30)]
        public string Lastname { get; set; }
    }
}
