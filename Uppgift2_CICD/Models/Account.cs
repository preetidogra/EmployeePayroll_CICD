using System;
namespace Uppgift1_CICD.Models
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Account(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
