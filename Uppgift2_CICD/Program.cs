using System;
using System.Collections.Generic;
using System.Linq;

namespace Uppgift1_CICD
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        private static void RunProgram()
        {
            var menu = new View.ConsoleMenus();
            var consoleMessage = new View.ConsoleMessages();
            var runProgram = true;

            var userList = new List<Models.UserAccount>();
            userList = CreateDatabase.CreateListOfUsers(userList);
            var roleList = new List<Models.CompanyRole>();
            roleList = CreateDatabase.CreateListOCompanyRoles(roleList);
            var admin = CreateDatabase.admin1;
            var user = new Models.Account();

            while (runProgram)
            {
                Console.Clear();
                menu.SignInMenu();

                var userInput = Controller.UserInput.IsInputInterger(0, 1);

                if (userInput == 1)
                {
                    var usernameValid = false;
                    var userIndex = -1;

                    Console.WriteLine("Please enter username:");
                    var username = Console.ReadLine();
                    for (int i = 0; i < userList.Count; i++)
                    {
                        if (username == admin.Username)
                        {
                            user = admin;
                            usernameValid = true;
                        }
                        else 
                        {
                            if(username == userList[i].Username)
                                {
                                    usernameValid = true;
                                    userIndex = i;
                                    user = userList[i];
                                }
                        }
                    }
                    if (usernameValid)
                    {
                        Console.WriteLine("Please enter password:");
                        var password = Console.ReadLine();
                        var userType = user.GetType();
                        if(user.Password == password)
                        {
                            if (userType == typeof(Models.UserAccount))
                                UserMenu(userList, roleList, userIndex, menu, consoleMessage, user); 
                            else 
                                AdminMenu(userList, roleList, userIndex, menu, consoleMessage, user);
                        }
                        else consoleMessage.ShowMessageAndClear("Password not correct");
                    }
                    else  consoleMessage.ShowMessageAndClear("Username does not exist");
                }
                else
                    runProgram = false;
            }
        }
        public static void UserMenu(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList, int userIndex, View.ConsoleMenus menu, View.ConsoleMessages consoleMessage, Models.Account user)
        {
            var userMenuChoice = -1;
            while (userMenuChoice != 0)
            {            
                Console.Clear();
                menu.UserInformation(user, roleList);
                Console.WriteLine();
                menu.UserMenu();
                userMenuChoice = Controller.UserInput.IsInputInterger(0, 3);

                switch (userMenuChoice)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("These are our company roles:\n");
                            foreach (var item in roleList)
                            {
                                Console.WriteLine($"[{item.RoleID}]{item.RoleName}");
                            }
                            Console.WriteLine($"\nYour role is: {roleList[user.EmpRoleID - 1].RoleName}\n");
                            Console.WriteLine("Please select you new company role:\n");
                            var newRole = Controller.UserInput.IsInputInterger(1, 4);

                            Console.WriteLine($"Your new demanded role is: {roleList[newRole - 1].RoleName}\n");
                            Console.WriteLine($"Is this correct?");
                            Console.WriteLine($"[1]Yes\n[0]No");
                            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
                            {
                                userList[userIndex].EmpNewRole = newRole;
                                consoleMessage.ShowMessageAndClear("You new demand has been registered.");
                            }
                            else
                            {
                                consoleMessage.ShowMessageAndClear("You have aborted this action.");
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine($"Your salary is: {user.EmpSalary}");
                            Console.WriteLine("We only allow a pay raise of 1 - 100%.\nNo decrease in salary allowed!");
                            Console.WriteLine("Please enter your demanded salary:");
                            var demandedSalary = Controller.UserInput.IsInputInterger(user.EmpSalary + 1, user.EmpSalary * 2);
                            Console.Clear();
                            Console.WriteLine($"Your new demanded salary is: {demandedSalary}");
                            Console.WriteLine($"Is this correct?\n[1]Yes\n[0]No");
                            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
                            {
                                userList[userIndex].EmpNewSalary = demandedSalary;
                                consoleMessage.ShowMessageAndClear("You new demand has been registered.");
                            }
                            else
                            {
                                consoleMessage.ShowMessageAndClear("You have aborted this action.");
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Please enter username:");
                            if (Console.ReadLine() == user.Username)
                            {
                                Console.WriteLine("Please enter password:");
                                if (Console.ReadLine() == user.Password)
                                {
                                    consoleMessage.ShowMessageAndClear($"User {user.Username} har been deleted.");
                                    userList.RemoveAt(userIndex);
                                    userMenuChoice = 0;
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
                        break;
                    case 0:
                        {
                            Console.Clear();
                        }
                        break;
                }
            }
        }
            public static void AdminMenu(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList, int userIndex, View.ConsoleMenus menu, View.ConsoleMessages consoleMessage, Models.Account user)
            {
            var adminMenuChoice = -1;
            while (adminMenuChoice != 0)
            {
                Console.Clear();
                menu.UserInformation(user, roleList);
                Console.WriteLine();
                menu.AdminMenu();
                Console.WriteLine();
                adminMenuChoice = Controller.UserInput.IsInputInterger(0, 5);

                switch (adminMenuChoice)
                {
                    case 1:
                        foreach (var item in userList)
                        {
                            menu.UserInformationInAdminMenu(item);
                        }
                        consoleMessage.ShowMessageAndClear("");
                        break;
                    case 2:
                        var newDemans = new List<Models.UserAccount>();
                        foreach (var item in userList)
                        {
                            if (item.EmpNewRole > 0 || item.EmpNewSalary > 0)
                                newDemans.Add(item);
                        }
                        if (newDemans.Count > 0)
                        {
                            //Console.WriteLine("These users have new demands:");
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
                        break;
                    case 3:
                        foreach (var item in userList)
                        {
                            item.EmpBalance += item.EmpSalary;
                        }
                        user.EmpBalance += user.EmpSalary;
                        consoleMessage.ShowMessageAndClear("One month has passed and everyone is richer");
                        break;
                    case 4:
                        Console.WriteLine("Enter username for new user:");
                        var newUsername = Console.ReadLine();
                        var newUsernameValid = true;
                        foreach (var item in userList)
                        {
                            if(item.Username == newUsername)
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
                        break;
                    case 5:
                        {
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
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
