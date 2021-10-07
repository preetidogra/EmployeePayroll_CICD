using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Controller.Actions
{
    public class UserActions
    {
        public void DemandNewCompanyRole(List<Models.UserAccount> UserList, List<Models.CompanyRole> RoleList, Models.Account user, int userIndex)
        {
            var ConsoleMessage = new View.ConsoleMessages();
            Console.Clear();
            Console.WriteLine("These are our company roles:\n");
            foreach (var item in RoleList)
            {
                Console.WriteLine($"[{item.RoleID}]{item.RoleName}");
            }
            Console.WriteLine($"\nYour role is: {RoleList[user.EmpRoleID - 1].RoleName}\n\nPlease select you new company role:\n");
            var newRole = Controller.UserInput.IsInputInterger(1, 4);

            Console.WriteLine($"Your new demanded role is: {RoleList[newRole - 1].RoleName}\n\nIs this correct?\n[1]Yes\n[0]No");
            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
            {
                UserList[userIndex].EmpNewRole = newRole;
                ConsoleMessage.ShowMessageAndClear("You new demand has been registered.");
            }
            else ConsoleMessage.ShowMessageAndClear("You have aborted this action.");
        }
        public void DemandNewSalay(List<Models.UserAccount> UserList, Models.Account user, int userIndex)
        {
            var ConsoleMessage = new View.ConsoleMessages();

            Console.WriteLine($"Your salary is: {user.EmpSalary}");
            Console.WriteLine("We only allow a pay raise of 1 - 100%.\nNo decrease in salary allowed!\n\nPlease enter your demanded salary:");
            var demandedSalary = Controller.UserInput.IsInputInterger(user.EmpSalary + 1, user.EmpSalary * 2);
            Console.Clear();
            Console.WriteLine($"Your new demanded salary is: {demandedSalary}\n\nIs this correct?\n[1]Yes\n[0]No");

            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
            {
                UserList[userIndex].EmpNewSalary = demandedSalary;
                ConsoleMessage.ShowMessageAndClear("You new demand has been registered.");
            }
            else ConsoleMessage.ShowMessageAndClear("You have aborted this action.");
        }
        public int DeleteAccount(List<Models.UserAccount> UserList, Models.Account user, int userIndex, int userMenuChoice)
        {
            var ConsoleMessage = new View.ConsoleMessages();

            Console.WriteLine("Please enter username:");
            if (Console.ReadLine() == user.Username)
            {
                Console.WriteLine("Please enter password:");
                if (Console.ReadLine() == user.Password)
                {
                    ConsoleMessage.ShowMessageAndClear($"User {user.Username} har been deleted.");
                    UserList.RemoveAt(userIndex);
                    userMenuChoice = 0;
                }
                else
                {
                    ConsoleMessage.ShowMessageAndClear("Password not correct");
                }
            }
            else
            {
                ConsoleMessage.ShowMessageAndClear("Wrong username");
            }
            return userMenuChoice;
        }
    }
}
