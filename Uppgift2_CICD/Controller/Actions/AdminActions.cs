using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uppgift1_CICD.Controller.Actions
{
    public class AdminActions
    {
        public void SeeUserDemands(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList)
        {
            var consoleMessage = new View.ConsoleMessages();
            var newDemans = new List<Models.UserAccount>();
            foreach (var item in userList)
            {
                if (item.EmpNewRole > 0 || item.EmpNewSalary > 0)
                    newDemans.Add(item);
            }
            if (newDemans.Count > 0)
            {
                foreach (var item in newDemans)
                {
                    if (item.EmpNewRole > 0)
                    {
                        Console.WriteLine($"{item.EmpName} | Company role: {roleList[item.EmpRoleID - 1].RoleName} | New company role: {roleList[item.EmpNewRole - 1].RoleName}\n");
                        Console.WriteLine("Do you accept this new demand?\n[1]Yes\n[0]No");
                        var acceptNewDemand = Controller.UserInput.IsInputInterger(0, 1);
                        if (acceptNewDemand == 1)
                        {
                            item.EmpRoleID = item.EmpNewRole;
                        }

                    }
                    if (item.EmpNewSalary > 0)
                    {
                        Console.WriteLine($"{item.EmpName} | Current salary: {item.EmpSalary} | New salary demand: {item.EmpNewSalary}\n");
                        Console.WriteLine("Do you accept this new demand?\n[1]Yes\n[0]No");
                        var acceptNewDemand = Controller.UserInput.IsInputInterger(0, 1);
                        if (acceptNewDemand == 1)
                        {
                            item.EmpSalary = item.EmpNewSalary;
                        }
                    }
                }
            }
            else
            {
                consoleMessage.ShowMessageAndClear("There are no new demands.");
            }

        }
        public void CreateNewUser(List<Models.UserAccount> userList, Models.Account user)
        {
            var consoleMessage = new View.ConsoleMessages();
            Console.WriteLine("Enter username for new user:");
            var newUsername = Console.ReadLine();
            var newUsernameValid = true;
            foreach (var item in userList)
            {
                if (item.Username == newUsername)
                {
                    consoleMessage.ShowMessageAndClear("Username already exists, please try another");
                    newUsernameValid = false;
                }
            }
            newUsernameValid = (newUsername != user.Username);
            if (newUsernameValid)
            {
                Console.WriteLine($"Enter password for new user {newUsername}:");
                var newPassword = Console.ReadLine();
                var newPasswordValid = newPassword.Any(char.IsDigit);
                if (newPasswordValid)
                    newPasswordValid = newPassword.Any(char.IsLetter);
                if (newPasswordValid)
                {
                    userList.Add(new Models.UserAccount("New user", newUsername, newPassword, 4, 0, 0));
                    consoleMessage.ShowMessageAndClear($"User {newUsername} has successfully been created");
                }
                else
                {
                    consoleMessage.ShowMessageAndClear("Password must contain at least 1 letter and 1 digit");
                }
            }
        }
        public void MoveForwardOneMonth(List<Models.UserAccount> userList, Models.Account user)
        {
            var consoleMessage = new View.ConsoleMessages();
            foreach (var item in userList)
            {
                item.EmpBalance += item.EmpSalary;
            }
            user.EmpBalance += user.EmpSalary;
            consoleMessage.ShowMessageAndClear("One month has passed and everyone is richer");
        }
        public void DeleteUser(List<Models.UserAccount> userList, int userIndex)
        {
            var consoleMessage = new View.ConsoleMessages();
            Models.UserAccount userToDelete = null;
            Console.WriteLine("Please enter username to delete user:");
            var usernameToDelete = Console.ReadLine();
            for (var i = 0; i < userList.Count; i++)
            {
                if (userList[i].Username == usernameToDelete)
                {
                    userToDelete = userList[i];
                    userIndex = i;
                }
            }
            if (userToDelete != null)
            {
                Console.WriteLine("Please enter password:");
                if (Console.ReadLine() == userToDelete.Password)
                {
                    consoleMessage.ShowMessageAndClear($"User {userToDelete.Username} har been deleted.");
                    userList.RemoveAt(userIndex);
                }
                else
                {
                    consoleMessage.ShowMessageAndClear("Password not correct");
                }
            }
            else
            {
                consoleMessage.ShowMessageAndClear("Username does not exist");
            }
        }
    }
}
