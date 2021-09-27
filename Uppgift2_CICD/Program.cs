using System;
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
        }
    }
}
