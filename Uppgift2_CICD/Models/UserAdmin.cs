using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Models
{
    public class UserAdmin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserAdmin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
