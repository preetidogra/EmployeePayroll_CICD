using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.View
{
    public class ConsoleMessages
    {
        public ConsoleMessages() {}

        public void ShowMessageAndClear(string message) 
            {
                Console.WriteLine(message);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        public void SignInMenu()
        {
            Console.WriteLine("[1] Sign in\n[0] Quit");
        }
        public void AdminMenu()
        {
            Console.WriteLine("" +
            "[1] List all users\n" +
            "[2] See user demands\n" +
            "[3] Move forward one month\n" +
            "[4] Create new user\n" +
            "[5] Delete accounts\n" +
            "[0] Log out\n");
        }
        public void UserMenu()
        {
            Console.WriteLine("" +
            "[1] Demand new company role\n" +
            "[2] Demand change in salay\n" +
            "[3] Delete account\n" +
            "[0] Log out\n");
        }
        public void UserInformation(Models.Account user, List<Models.CompanyRole> roleList)
        {
            Console.WriteLine("" +
                $"Employee name: {user.EmpName}\n" +
                $"Employee salary: {user.EmpSalary} SEK\n" +
                $"Employee balance: {user.EmpBalance} SEK\n" +
                $"Employee role: {roleList[user.EmpRoleID - 1].RoleName}");
        }
        public void UserInformationInAdminMenu(Models.Account user)
        {
            Console.WriteLine("" +
                $"Employee name: {user.EmpName,17} | " +
                $"Account username: {user.Username,10} | " +
                $"Account password: {user.Password,8}");
        }

    }
}
