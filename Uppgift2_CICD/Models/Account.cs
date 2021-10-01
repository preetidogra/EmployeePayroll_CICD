using System;
namespace Uppgift1_CICD.Models
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmpName { get; set; }
        public int EmpRoleID { get; set; }
        public int EmpSalary { get; set; }
        public int EmpBalance { get; set; }
    public Account() { }
    }
}
