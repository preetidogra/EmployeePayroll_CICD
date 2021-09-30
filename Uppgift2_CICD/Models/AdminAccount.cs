using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Models
{
    public class AdminAccount : Account
    {
        public AdminAccount(string empName, string username, string password, int empRoleID, int empSalary, int empBalance)
        {
            this.EmpName = empName;
            this.Username = username;
            this.Password = password;
            this.EmpRoleID = empRoleID;
            this.EmpSalary = empSalary;
            this.EmpBalance = empBalance;
        }

    }
}


