using System;
using System.Collections.Generic;


namespace Uppgift1_CICD
{
    class Program
    {
        static void Main(string[] args)
        {
            RunProgram();
        }

        static void RunProgram()
        {
            var menu = new View.ConsoleMenus();
            var runProgram = true;

            var userList = new List<Models.User>();
            userList = CreateDatabase.CreateListOfUsers(userList);

            var roleList = new List<Models.CompanyRole>();
            roleList = CreateDatabase.CreateListOCompanyRoles(roleList);

            var admin = new Models.UserAdmin("admin1", "admin1234");
            while (runProgram)
            {

            menu.SignInMenu();

            var userInput = Controller.UserInput.IsInputInterger(0, 1);

                if (userInput == 1)
                {
                    var usernameValid = false;
                    Console.WriteLine("Please enter username:");
                    var username = Console.ReadLine();

                    
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
                            var user = new Models.User(userList[userIndex].EmpID, userList[userIndex].EmpName, userList[userIndex].Username, userList[userIndex].Password, userList[userIndex].EmpRoleID, userList[userIndex].EmpSalary, userList[userIndex].EmpBalance);

                            if (username != "admin1")
                            {
                                Console.Clear();
                                menu.UserInformation(user);
                                Console.WriteLine();
                                menu.UserMenu();
                                var userMenuChoice = Controller.UserInput.IsInputInterger(1, 4);
                            }
                            else
                            {
                                Console.Clear();
                                menu.AdminMenu();
                            }


                        }
                        else
                        {
                            Console.WriteLine("Password not correct\nPress any key to continue");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Username does not exist\nPress any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                else
                    runProgram = false;
            }
          


        }
    }
}
