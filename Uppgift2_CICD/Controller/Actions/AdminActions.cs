using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uppgift1_CICD.Controller.Actions
{
    public class AdminActions
    {
        public void SeeUserDemands(VariableObject obj)
        {
           
            var newDemans = new List<Models.UserAccount>();
            foreach (var item in obj.UserList)
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
                        Console.WriteLine($"{item.EmpName} | Company role: {obj.RoleList[item.EmpRoleID - 1].RoleName} | New company role: {obj.RoleList[item.EmpNewRole - 1].RoleName}\n");
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
                obj.ConsoleMessage.ShowMessageAndClear("There are no new demands.");
            }

        }
        public void CreateNewUser(VariableObject obj)
        {
            var ConsoleMessage = new View.ConsoleMessages();
            Console.WriteLine("Enter username for new obj.User:");
            var newUsername = Console.ReadLine();
            var newUsernameValid = IsUserNameValid(newUsername);
            if (newUsername != obj.User.Username)
                if (newUsernameValid)
                {
                    foreach (var item in obj.UserList)
                    {
                        if (item.Username == newUsername)
                        {
                            ConsoleMessage.ShowMessageAndClear("Username already exists, please try another");
                            newUsernameValid = false;
                        }
                    }
                    if (newUsernameValid)
                    {
                        Console.WriteLine($"Enter password for new obj.User {newUsername}:");
                        var newPassword = Console.ReadLine();
                        var newPasswordValid = newPassword.Any(char.IsDigit);
                        if (newPasswordValid)
                            newPasswordValid = newPassword.Any(char.IsLetter);
                        if (newPasswordValid)
                        {
                            obj.UserList.Add(new Models.UserAccount("New obj.User", newUsername, newPassword, 4, 0, 0));
                            ConsoleMessage.ShowMessageAndClear($"User {newUsername} has successfully been created");
                        }
                        else
                        {
                            ConsoleMessage.ShowMessageAndClear("Password must contain at least 1 letter and 1 digit");
                        }
                    }
                }
                else
                {
                    ConsoleMessage.ShowMessageAndClear("Username must contain at least 1 letter and 1 digit");
                }

            else
            {
                ConsoleMessage.ShowMessageAndClear($"Username {obj.User.Username} already exists, please try another");
            }
        }
        public void AdvanceOneMonth(VariableObject obj)
        {
            var ConsoleMessage = new View.ConsoleMessages();
            foreach (var item in obj.UserList)
            {
                item.EmpBalance += item.EmpSalary;
            }
            obj.User.EmpBalance += obj.User.EmpSalary;
            ConsoleMessage.ShowMessageAndClear("One month has passed and everyone is richer");
        }
        public void DeleteUser(VariableObject obj)
        {
            var ConsoleMessage = new View.ConsoleMessages();
            Models.UserAccount userToDelete = null;
            Console.WriteLine("Please enter username to delete user:");
            var usernameToDelete = Console.ReadLine();
            for (var i = 0; i < obj.UserList.Count; i++)
            {
                if (obj.UserList[i].Username == usernameToDelete)
                {
                    userToDelete = obj.UserList[i];
                    obj.UserIndex = i;
                }
            }
            if (userToDelete != null)
            {
                Console.WriteLine("Please enter password:");
                if (Console.ReadLine() == userToDelete.Password)
                {
                    ConsoleMessage.ShowMessageAndClear($"User {userToDelete.Username} har been deleted.");
                    obj.UserList.RemoveAt(obj.UserIndex);
                }
                else
                {
                    ConsoleMessage.ShowMessageAndClear("Password not correct");
                }
            }
            else
            {
                ConsoleMessage.ShowMessageAndClear("Username does not exist");
            }
        }
        public bool IsUserNameValid(string username)
        {
            if (username.Any(char.IsDigit))
            {
                return username.Any(char.IsLetter);
            }
            else
                return false;
        }
    }
}
