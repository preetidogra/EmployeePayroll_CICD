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
                                UserMenu(userList, roleList, userIndex, consoleMessage, user); 
                            else 
                                AdminMenu(userList, roleList, userIndex, consoleMessage, user);
                        }
                        else consoleMessage.ShowMessageAndClear("Password not correct");
                    }
                    else  consoleMessage.ShowMessageAndClear("Username does not exist");
                }
                else
                    runProgram = false;
            }
        }
        public static void UserMenu(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList, int userIndex, View.ConsoleMessages consoleMessage, Models.Account user)
        {
            var userMenuChoice = -1;
            var userActions = new Controller.Actions.UserActions();
            while (userMenuChoice != 0)
            {            
                Console.Clear();
                consoleMessage.UserInformation(user, roleList);
                Console.WriteLine();
                consoleMessage.UserMenu();
                userMenuChoice = Controller.UserInput.IsInputInterger(0, 3);
                switch (userMenuChoice)
                {
                    case 1: userActions.DemandNewCompanyRole(userList, roleList, user, userIndex);  break;
                    case 2: userActions.DemandNewSalay(userList, user, userIndex);  break;
                    case 3: userMenuChoice = userActions.DeleteAccount(userList, user, userIndex, userMenuChoice); break;
                    case 0: Console.Clear();  break;
                }
            }
        }
            public static void AdminMenu(List<Models.UserAccount> userList, List<Models.CompanyRole> roleList, int userIndex, View.ConsoleMessages consoleMessage, Models.Account user)
            {
            var adminActions = new Controller.Actions.AdminActions();
            var adminMenuChoice = -1;
            while (adminMenuChoice != 0)
            {
                Console.Clear();
                consoleMessage.UserInformation(user, roleList);
                Console.WriteLine();
                consoleMessage.AdminMenu();
                Console.WriteLine();
                adminMenuChoice = Controller.UserInput.IsInputInterger(0, 5);

                switch (adminMenuChoice)
                {
                    case 1:
                        Console.Clear();
                        foreach (var item in userList)
                        {
                            consoleMessage.UserInformationInAdminMenu(item);
                        }
                        consoleMessage.ShowMessageAndClear("");
                        break;

                    case 2: adminActions.SeeUserDemands(userList, roleList); break;

                    case 3:
                        adminActions.MoveForwardOneMonth(userList, user); break;
                    case 4: adminActions.CreateNewUser(userList, user); break;
                    case 5: adminActions.DeleteUser(userList, userIndex); break;
                    default:
                        break;
                }
            }
        }
    }
}
