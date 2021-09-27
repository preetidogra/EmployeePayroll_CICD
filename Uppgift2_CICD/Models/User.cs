using System;
namespace Uppgift1_CICD.Models
{
    public class User
    {

        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPassword { get; set; }
        public string EmpRole { get; set; }
        public int EmpSalary { get; set; }
        public int EmpAccountBalance { get; set; }

        // all emp details
        public User(int empID, string empName, string empEmail, string empPassword, string empRole, int empSalary, int empAccountBalance)
        {
            this.EmpID = empID;
            this.EmpName = empName;
            this.EmpEmail = empEmail;
            this.EmpPassword = empPassword;
            this.EmpRole = empRole;
            this.EmpSalary = empSalary;
            this.EmpAccountBalance = empAccountBalance;

        }
    }
}
