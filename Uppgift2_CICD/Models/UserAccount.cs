using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Models
{
    public class UserAccount : Account
    {
        public int EmpNewRole { get; set; }
        public int EmpNewSalary { get; set; }
        public UserAccount(string empName, string username, string password, int empRoleID, int empSalary, int empBalance)
        {           
            this.EmpName = empName;
            this.Username = username;
            this.Password = password;
            this.EmpRoleID = empRoleID;
            this.EmpSalary = empSalary;
            this.EmpBalance = empBalance;

            this.EmpNewRole = 0;
            this.EmpNewSalary = 0;
        }
    }
}
