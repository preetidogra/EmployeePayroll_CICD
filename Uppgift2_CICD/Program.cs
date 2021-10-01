using System;
using System.Collections.Generic;


namespace Uppgift1_CICD
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        public static void RunProgram()
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
                        if(user.Password == password)
                        {
                            var userType = user.GetType();
                            if (userType == typeof (Models.UserAccount))
                            {
                                UserMenu(userList, roleList, userIndex, menu, consoleMessage, user);
                            }
                            else
                            {                                
                                AdminMenu(userList, roleList, userIndex, menu, consoleMessage, user);
                            }
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
                else
                    runProgram = false;
            }
        }
            public static void UserMenu(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList, int userIndex, View.ConsoleMenus menu, View.ConsoleMessages consoleMessage, Models.Account user )
            {
            Console.Clear();
            menu.UserInformation(user, roleList);
            Console.WriteLine();
            menu.UserMenu();
            var userMenuChoice = Controller.UserInput.IsInputInterger(0, 3);

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
                        Console.WriteLine($"Your salary is: {userList[userIndex].EmpSalary}");
                        Console.WriteLine("We only allow a pay raise of 1 - 100%.\nNo decrease in salary allowed!");
                        Console.WriteLine("Please enter your demanded salary:");
                        var demandedSalary = Controller.UserInput.IsInputInterger(userList[userIndex].EmpSalary + 1, userList[userIndex].EmpSalary * 2);
                        Console.Clear();
                        Console.WriteLine($"Your new demanded salary is: {demandedSalary}");
                        Console.WriteLine($"Is this correct?");
                        Console.WriteLine($"[1]Yes\n[0]No");
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
                                userList.RemoveAt(userIndex);
                                consoleMessage.ShowMessageAndClear($"User {userList[userIndex].Username} har been deleted.");
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
            public static void AdminMenu(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList, int userIndex, View.ConsoleMenus menu, View.ConsoleMessages consoleMessage, Models.Account user)
            { 
            Console.Clear();
            menu.AdminMenu();
            Console.WriteLine();
            var adminMenuChoice = Controller.UserInput.IsInputInterger(0, 5);

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
                        Console.WriteLine("These users have new demands:");
                        foreach (var item in newDemans)
                        {
                            if (item.EmpNewRole > 0)
                            {
                                Console.WriteLine($"{item.EmpName} | Company role: {roleList[item.EmpRoleID-1].RoleName} | New company role: {roleList[item.EmpNewRole-1].RoleName}");
                                Console.WriteLine("Do you accept this new demand?\n[1]Yes\n[0]No");
                                var acceptNewDemand = Controller.UserInput.IsInputInterger(0, 1);
                                if(acceptNewDemand == 1) 
                                {
                                    item.EmpRoleID = item.EmpNewRole;
                                }

                            }
                            if(item.EmpNewSalary > 0)
                            {
                                Console.WriteLine($"{item.EmpName} | Current salary: {item.EmpSalary} | New salary demand: {item.EmpNewSalary}");
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
            break;
                case 4:
            break;
                case 5:
            break;




                default:
                    break;
            
            }
        }
    }
}
