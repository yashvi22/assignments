using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using SourceControl.Custom_Validations;

namespace SourceControl.Models
{
    public class RegistrationModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "it should not be more than 15 characters and less than 3 characters", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15,ErrorMessage ="Last name should not be more than 15 characters and less than 3 charachters")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]       
        public DateTime DateOfBirth { get; set; }

        [Range(18,65)]
        public int Age { get; set; }

        [Required]
        [CustomQualification(ErrorMessage ="Qualification must be BE")]
        public string Qualification { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",ErrorMessage ="Enter a valid number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string Email { get; set;}

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password" )]
        [Compare("Password",ErrorMessage ="pasword don't match")]
        public string ConfirmPassword { get; set; }
    }
}