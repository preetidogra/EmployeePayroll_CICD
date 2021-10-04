using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Controller
{
    public static class Menus
    {
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
                    case 1: userActions.DemandNewCompanyRole(userList, roleList, user, userIndex); break;
                    case 2: userActions.DemandNewSalay(userList, user, userIndex); break;
                    case 3: userMenuChoice = userActions.DeleteAccount(userList, user, userIndex, userMenuChoice); break;
                    case 0: Console.Clear(); break;
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
                        Console.WriteLine("\nAdmin:");
                        consoleMessage.UserInformationInAdminMenu(user);
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
