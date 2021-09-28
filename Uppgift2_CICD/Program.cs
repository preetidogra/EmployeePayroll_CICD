using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace Uppgift1_CICD
{
    class Program
    {
        static void Main(string[] args)
        {

            var userList = new List<Models.User>();
            userList = CreateDatabase.CreateListOfUsers(userList);
            var roleList = new List<Models.CompanyRole>();
            roleList = CreateDatabase.CreateListOCompanyRoles(roleList);
            var accountList = new List<Models.Account>();
            accountList = CreateDatabase.CreateListOAccounts(accountList);

            var admin = new Models.UserAdmin("admin1", "admin1234");

            var consoleMenu = new View.ConsoleMenus();

            foreach (var item in userList)
            {
                Console.WriteLine(item.EmpName + " is making " + item.EmpSalary + " SEK each month");
            }

           
        }
    }
}
