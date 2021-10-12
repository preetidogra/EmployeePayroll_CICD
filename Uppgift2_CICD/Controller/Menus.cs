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
                    case 4:
                        var newUserSuccessfullyCreated = false;
                        Console.WriteLine($"Enter username for new user. \nUsername must contain both letters and numbers:");

                        var newUsername = Console.ReadLine();
                        if (adminActions.IsUserNameValid(newUsername))
                        {
                            Console.WriteLine($"Enter password for new user. \nPassword must contain both letters and numbers:");
                            var newPassword = Console.ReadLine();
                            if (adminActions.IsUserNameValid(newPassword))
                            {
                               newUserSuccessfullyCreated = adminActions.CreateNewUser(obj, newUsername, newPassword);
                            }
                            else
                            {
                                obj.ConsoleMessage.ShowMessageAndClear("Password not valid. \nPassword must contain both letters and numbers");
                            }
                        }
                        else
                        {
                            obj.ConsoleMessage.ShowMessageAndClear("Username not valid. \nUsername must contain both letters and numbers");
                        }
                        if (newUserSuccessfullyCreated)
                        {
                            obj.ConsoleMessage.ShowMessageAndClear($"{newUsername} was successfully created.");
                        }

                        break;
                    case 5:

                        Console.WriteLine("Please enter username to delete user:");
                        var usernameToDelete = Console.ReadLine();
                        Console.WriteLine("Please enter password to delete user:");
                        var passwordToDelete = Console.ReadLine();
                        if (adminActions.DeleteUser(obj, usernameToDelete, passwordToDelete))
                        {
                            obj.ConsoleMessage.ShowMessageAndClear($"User {usernameToDelete} har been deleted.");
                        }
                        else
                        {
                            obj.ConsoleMessage.ShowMessageAndClear("Password not correct");
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
