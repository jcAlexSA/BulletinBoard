using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulletinBoard.Models.Users
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public byte Age { get; set; }
        public string Gender { get; set; }
    }
}