using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dataannotationsandvalidations.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(15, ErrorMessage = "It should be more than 3 charcters and less than 15 charachters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(15, ErrorMessage = "It should be more than 3 charcters and less than 15 charachters", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 50, ErrorMessage = "Enter valid age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(40)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "INvalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MaxLength(10)]
        public string Password { get; set; }

        [Required(ErrorMessage = " Please Rewrite your password")]
        [DataType(DataType.Password)]
        [MaxLength(10)]
        [System.ComponentModel.DataAnnotations.Compare("Password",ErrorMessage ="Password don't match")]
        [Display(Name ="Confirm Password")]
        public String ConfirmPassword { get; set; }
    }
        
}