using System;
using System.Collections.Generic;

namespace Uppgift1_CICD
{
    public class CreateDatabase
    {
        public CreateDatabase()
        {
            var list = new List<Models.User>();

            list.Add(new Models.User(0, "Philip Rasmusson", "phiras001", "qasw12!", 0, 48000, 0));
            //User(int empID, string empName, string username, string password, int empRoleID, int empSalary, int empAccountID)
        }
    }
}
