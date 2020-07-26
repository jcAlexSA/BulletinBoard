using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulletinBoard.Models.Users
{
    public class CreateUserRequest
    {
        [DisplayName("First Name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the First Name")]
        public string LastName { get; set; }
                
        [EmailAddress]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email address is incorrect")]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the Password")]
        public string Password { get; set; }

        [DisplayName("Repeat Password")]
        [Compare("Password", ErrorMessage = "Passwords are not equals.")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the Confirmation Password")]
        public string RepeatPassword { get; set; }

        [Range(1, 100)]
        public byte Age { get; set; }

        [Phone]
        [MaxLength(10)]
        public string Phone { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }
    }
}