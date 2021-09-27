using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD
{

    public class Admin
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Admin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

    }
}
