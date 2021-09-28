using System;
namespace Uppgift1_CICD.Models
{
    public class User //: Models.UserAdmin
    {

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int EmpRoleID { get; set; }
        public int EmpSalary { get; set; }

        // all emp details
        public User(int empID, string empName, string username, string password, int empRoleID, int empSalary)
        {
            this.EmpID = empID;
            this.EmpName = empName;
            this.Username = username;
            this.Password = password;
            this.EmpRoleID = empRoleID;
            this.EmpSalary = empSalary;
        }
    }
}
