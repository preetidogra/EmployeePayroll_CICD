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
                consoleMessage.SignInMenu();

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
                               Controller.Menus.UserMenu(userList, roleList, userIndex, consoleMessage, user); 
                            else 
                               Controller.Menus.AdminMenu(userList, roleList, userIndex, consoleMessage, user);
                        }
                        else consoleMessage.ShowMessageAndClear("Password not correct");
                    }
                    else  consoleMessage.ShowMessageAndClear("Username does not exist");
                }
                else
                    runProgram = false;
            }
        }
        
    }
}
