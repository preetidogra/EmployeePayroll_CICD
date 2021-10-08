using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Controller
{
    public static class Menus
    {
        public static void UserMenu(VariableObject obj)
        {
            var userMenuChoice = -1;
            var userActions = new Controller.Actions.UserActions();
            while (userMenuChoice != 0)
            {
                Console.Clear();
                obj.ConsoleMessage.UserInformation(obj.User, obj.RoleList);
                Console.WriteLine();
                obj.ConsoleMessage.UserMenu();
                userMenuChoice = Controller.UserInput.IsInputInterger(0, 3);
                switch (userMenuChoice)
                {
                    case 1: userActions.DemandNewCompanyRole(obj); break;
                    case 2: userActions.DemandNewSalay(obj); break;
                    case 3: userMenuChoice = userActions.DeleteAccount(userMenuChoice, obj); break;
                    case 0: Console.Clear(); break;
                }
            }
        }
        public static void AdminMenu(VariableObject obj)
        {
            var adminActions = new Controller.Actions.AdminActions();
            var adminMenuChoice = -1;
            while (adminMenuChoice != 0)
            {
                Console.Clear();
                obj.ConsoleMessage.UserInformation(obj.User, obj.RoleList);
                Console.WriteLine();
                obj.ConsoleMessage.AdminMenu();
                Console.WriteLine();
                adminMenuChoice = Controller.UserInput.IsInputInterger(0, 5);

                switch (adminMenuChoice)
                {
                    case 1:
                        Console.Clear();
                        foreach (var item in obj.UserList)
                        {
                            obj.ConsoleMessage.UserInformationInAdminMenu(item);
                        }
                        Console.WriteLine("\nAdmin:");
                        obj.ConsoleMessage.UserInformationInAdminMenu(obj.User);
                        obj.ConsoleMessage.ShowMessageAndClear("");
                        break;

                    case 2: adminActions.SeeUserDemands(obj); break;
                    case 3: adminActions.AdvanceOneMonth(obj); break;
                    case 4: adminActions.CreateNewUser(obj); break;
                    case 5: adminActions.DeleteUser(obj); break;
                    default:
                        break;
                }
            }
        }
    }
}
