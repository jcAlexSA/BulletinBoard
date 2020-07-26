using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BulletinBoard.Models.Users
{
    public class SignInUserRequest
    {
        [EmailAddress]
        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email address is incorrect")]
        public string Email { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Please enter the Password")]
        public string Password { get; set; }
    }
}