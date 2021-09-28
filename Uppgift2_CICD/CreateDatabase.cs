using System;
using System.Collections.Generic;

namespace Uppgift1_CICD
{
    public class CreateDatabase
    {
        public CreateDatabase()
        {
            var userList = new List<Models.UserAdmin>();
            var roleList = new List<Models.CompanyRole>();
            var accountList = new List<Models.Account>();
            var admin = new Models.UserAdmin("", "");

           // userList.Add(new Models.User(0, "Philip Rasmusson", "phiras001", "qasw12!", 0, 48000, 0));
            //User(int empID, string empName, string username, string password, int empRoleID, int empSalary, int empAccountID)
        }
    }
}
