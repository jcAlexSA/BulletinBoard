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
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [DisplayName("Repeat Password")]
        public string RepeatPassword { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
    }
}