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
            var admin = CreateDatabase.admin1;

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
                                            var userRole = "";
                                            var newRole = 0;
                                            Console.Clear();
                                            Console.WriteLine("These are our company roles:\n");
                                            foreach (var item in roleList)
                                            {
                                                if (userList[userIndex].EmpRoleID == item.RoleID) 
                                                {
                                                    userRole = item.RoleName;
                                                }
                                                Console.WriteLine($"[{item.RoleID}]{item.RoleName}");
                                            }
                                            Console.WriteLine($"Your role is: {userRole}\n");
                                            Console.WriteLine("Please select you new company role:\n");
                                            newRole = Controller.UserInput.IsInputInterger(1, 4);

                                            Console.WriteLine($"Your new demanded role is: {roleList[newRole-1].RoleName}\n");
                                            Console.WriteLine($"Is this correct?");
                                            Console.WriteLine($"[1]Yes\n[0]No");
                                            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
                                            {
                                                userList[userIndex].EmpNewRole = newRole;
                                                invalidSignIn.ShowMessageAndClear("You new demand has been registered.");
                                            }
                                            else
                                            {
                                                invalidSignIn.ShowMessageAndClear("You have aborted this action.");
                                            }
                                            Console.ReadKey();
                                        }
                                        break;
                                    case 2: {
                                            Console.WriteLine($"Your salary is: {userList[userIndex].EmpSalary}");
                                            Console.WriteLine("We only allow a pay raise of 1 - 100%.\nNo decrease in salary allowed!");
                                            Console.WriteLine("Please enter your demanded salary:");
                                            var demandedSalary = Controller.UserInput.IsInputInterger(userList[userIndex].EmpSalary+1, userList[userIndex].EmpSalary * 2);
                                            Console.Clear();
                                            Console.WriteLine($"Your new demanded salary is: {demandedSalary}");
                                            Console.WriteLine($"Is this correct?");
                                            Console.WriteLine($"[1]Yes\n[0]No");
                                            if (Controller.UserInput.IsInputInterger(0, 1) == 1)
                                            {
                                                userList[userIndex].EmpNewSalary = demandedSalary;
                                                invalidSignIn.ShowMessageAndClear("You new demand has been registered.");
                                            }
                                            else 
                                            {
                                                invalidSignIn.ShowMessageAndClear("You have aborted this action.");
                                            }                                            
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
