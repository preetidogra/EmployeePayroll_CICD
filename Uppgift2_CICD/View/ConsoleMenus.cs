using System;
namespace Uppgift1_CICD.View
{
    public class ConsoleMenus
    {
        public ConsoleMenus()
        {
        }
        public void SignInMenu()
            {
                Console.WriteLine("[1] Sign in\n[0] Quit");
            }
        public void AdminMenu()
        {
            Console.WriteLine(""+
            "[1] List all users\n"+
            "[2] See user demands\n"+
            "[3] Move forward one month\n" +
            "[4] Create new user\n" +
            "[5] Delete accounts\n" +
            "[6] Log out\n");
        }
        public void UserMenu()
        {
            Console.WriteLine("" +
            "[1] Demand new company role\n" +
            "[2] Demand change in salay\n" +
            "[3] Delete account\n" +
            "[4] Log out\n");
        }
        public void UserInformation(Models.User user)
        {
            Console.WriteLine("" +
                $"Employee name: {user.EmpName}\n"+
                $"Employee salary: {user.EmpSalary} SEK\n" +
                $"Employee balance: {user.EmpBalance} SEK\n" +
                $"Employee role: {user.EmpRoleID}");
        }
    }
}
