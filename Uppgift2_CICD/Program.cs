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
            var invalidSignIn = new View.ErrorMessages();
            var runProgram = true;

            var userList = new List<Models.UserAccount>();
            userList = CreateDatabase.CreateListOfUsers(userList);

            var roleList = new List<Models.CompanyRole>();
            roleList = CreateDatabase.CreateListOCompanyRoles(roleList);

            while (runProgram)
            {

            menu.SignInMenu();

            var userInput = Controller.UserInput.IsInputInterger(0, 1);

                if (userInput == 1)
                {
                    var usernameValid = false;
                    Console.WriteLine("Please enter username:");
                    var username = Console.ReadLine();
                    var admin = CreateDatabase.admin1;
                    
                    var userIndex = -1;

                    for (int i = 0; i < userList.Count; i++)
                    {                    
                        if(username == userList[i].Username)
                        {
                            usernameValid = true;
                            userIndex = i;
                        }
                }
                    if (usernameValid)
                    {
                        Console.WriteLine("Please enter password:");
                        var password = Console.ReadLine();
                        if(userList[userIndex].Password == password)
                        {
                            if (username != "admin1")
                            {
                                Console.Clear();
                                menu.UserInformation(userList[userIndex]);
                                Console.WriteLine();
                                menu.UserMenu();
                                var userMenuChoice = Controller.UserInput.IsInputInterger(0, 3);

                                switch (userMenuChoice)
                                {
                                    case 1: {
                                            Console.WriteLine($"Case: {userMenuChoice}");
                                        }
                                        break;
                                    case 2: {
                                            Console.WriteLine($"Case: {userMenuChoice}");
                                        }
                                        break;
                                    case 3: {
                                            Console.WriteLine("Please enter username:");
                                           if(Console.ReadLine() == username)
                                            {
                                                Console.WriteLine("Please enter password:");
                                                if (Console.ReadLine() == password)
                                                {
                                                    userList.RemoveAt(userIndex);
                                                    invalidSignIn.ShowMessageAndClear($"User {userList[userIndex].Username} har been deleted.");
                                                }
                                                else
                                                {
                                                    invalidSignIn.ShowMessageAndClear("Password not correct");
                                                }
                                            }
                                            else
                                            {
                                                invalidSignIn.ShowMessageAndClear("Username does not exist");
                                            }
                                        }
                                        break;
                                    case 0: {
                                            Console.Clear();
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                Console.Clear();
                                menu.AdminMenu();
                            }
                        }
                        else
                        {
                            invalidSignIn.ShowMessageAndClear("Password not correct");
                        }
                    }
                    else
                    {
                        invalidSignIn.ShowMessageAndClear("Username does not exist");
                    }
                }
                else
                    runProgram = false;
            }
        }
    }
}
