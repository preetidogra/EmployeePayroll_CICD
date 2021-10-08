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

        public static void RunProgram()
        {
            var runProgram = true;
            var obj = new Controller.VariableObject();

            CreateDatabase.CreateListOfUsers(obj);
            CreateDatabase.CreateListOCompanyRoles(obj);
            obj.Admin = CreateDatabase.admin1;

            while (runProgram)
            {
                Console.Clear();
                obj.ConsoleMessage.SignInMenu();
                var userInput = Controller.UserInput.IsInputInterger(0, 1);
                if (userInput == 1)
                {
                    Console.WriteLine("Please enter username:");
                    var username = Console.ReadLine();
                    Console.WriteLine("Please enter password:");
                    var password = Console.ReadLine();

                    var usernameValid = SignIn(username, password, obj);

                    var userType = obj.User.GetType();
                    if (obj.User.Password == password)
                    {
                        usernameValid = true;
                        if (userType == typeof(Models.UserAccount))
                            Controller.Menus.UserMenu(obj);
                        else
                            Controller.Menus.AdminMenu(obj);
                    }
                    if (!usernameValid) obj.ConsoleMessage.ShowMessageAndClear("Username and password does not match");
                }
                else
                    runProgram = false;
            }
        }
            public static bool SignIn(string username, string password, Controller.VariableObject obj)
        {
            obj.UserIndex = -1;
            for (int i = 0; i < obj.UserList.Count; i++)
            {
                if (username == obj.Admin.Username)
                {
                    obj.User = obj.Admin;
                    return true;
                }
                else
                {
                    if (username == obj.UserList[i].Username)
                    {                        
                        obj.UserIndex = i;
                        obj.User = obj.UserList[i];
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
