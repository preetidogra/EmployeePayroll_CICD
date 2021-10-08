using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Controller.Actions
{
    public class UserActions
    {
        public void DemandNewCompanyRole(VariableObject obj)
        {
            Console.Clear();
            Console.WriteLine("These are our company roles:\n");
            foreach (var item in obj.RoleList)
            {
                Console.WriteLine($"[{item.RoleID}]{item.RoleName}");
            }
            Console.WriteLine($"\nYour role is: {obj.RoleList[obj.User.EmpRoleID - 1].RoleName}\n\nPlease select you new company role:\n");
            var newRole = Controller.UserInput.IsInputInterger(1, 4);

            Console.WriteLine($"Your new demanded role is: {obj.RoleList[newRole - 1].RoleName}\n\nIs this correct?\n[1]Yes\n[0]No");
            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
            {
                obj.UserList[obj.UserIndex].EmpNewRole = newRole;
                obj.ConsoleMessage.ShowMessageAndClear("You new demand has been registered.");
            }
            else obj.ConsoleMessage.ShowMessageAndClear("You have aborted this action.");
        }
        public void DemandNewSalay(VariableObject obj)
        {

            Console.WriteLine($"Your salary is: {obj.User.EmpSalary}");
            Console.WriteLine("We only allow a pay raise of 1 - 100%.\nNo decrease in salary allowed!\n\nPlease enter your demanded salary:");
            var demandedSalary = Controller.UserInput.IsInputInterger(obj.User.EmpSalary + 1, obj.User.EmpSalary * 2);
            Console.Clear();
            Console.WriteLine($"Your new demanded salary is: {demandedSalary}\n\nIs this correct?\n[1]Yes\n[0]No");

            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
            {
                obj.UserList[obj.UserIndex].EmpNewSalary = demandedSalary;
                obj.ConsoleMessage.ShowMessageAndClear("You new demand has been registered.");
            }
            else obj.ConsoleMessage.ShowMessageAndClear("You have aborted this action.");
        }
        public int DeleteAccount(int userMenuChoice, VariableObject obj)
        {

            Console.WriteLine("Please enter username:");
            if (Console.ReadLine() == obj.User.Username)
            {
                Console.WriteLine("Please enter password:");
                if (Console.ReadLine() == obj.User.Password)
                {
                    obj.ConsoleMessage.ShowMessageAndClear($"User {obj.User.Username} har been deleted.");
                    obj.UserList.RemoveAt(obj.UserIndex);
                    obj.User = new Models.Account();
                    
                    userMenuChoice = 0;
                }
                else
                {
                    obj.ConsoleMessage.ShowMessageAndClear("Password not correct");
                }
            }
            else
            {
                obj.ConsoleMessage.ShowMessageAndClear("Wrong username");
            }
            return userMenuChoice;
        }
    }
}
