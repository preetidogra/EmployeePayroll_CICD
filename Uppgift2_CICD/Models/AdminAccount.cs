using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Models
{
    public class AdminAccount : Account
    {
        public AdminAccount(int empID, string empName, string username, string password, int empRoleID, int empSalary, int empBalance)
        {
            this.EmpID = empID;
            this.EmpName = empName;
            this.Username = username;
            this.Password = password;
            this.EmpRoleID = empRoleID;
            this.EmpSalary = empSalary;
            this.EmpBalance = empBalance;
        }

    }
}


