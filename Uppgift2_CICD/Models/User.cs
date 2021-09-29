using System;
namespace Uppgift1_CICD.Models
{
    public class User : Models.UserAdmin
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int EmpRoleID { get; set; }
        public int EmpSalary { get; set; }
        public int EmpBalance { get; set; }

        // all emp details
        public User(int empID, string empName, string username, string password, int empRoleID, int empSalary, int empBalance) : base(username, password)
        {
            this.EmpID = empID;
            this.EmpName = empName;
            this.EmpRoleID = empRoleID;
            this.EmpSalary = empSalary;
            this.EmpBalance = empBalance;
        }
    }
}
