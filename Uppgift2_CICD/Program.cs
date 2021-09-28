using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace Uppgift1_CICD
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleMenu = new View.ConsoleMenus();

            consoleMenu.SignInMenu();
            consoleMenu.AdminMenu();

            var list = new List<Models.User>();

            list.Add(new Models.User(0, "Philip Rasmusson", "phiras001", "qasw12!", 0, 48000, 0));
            //public User(int empID, string empName, string usename, string password, int empRoleID, int empSalary, int empAccountID)
        }
    }
}
