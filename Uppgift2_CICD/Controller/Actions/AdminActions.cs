using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Uppgift1_CICD.Controller.Actions
{
    public class AdminActions
    {
        public void SeeUserDemands(VariableObject obj)
        {

            var newDemans = new List<Models.UserAccount>();
            foreach (var item in obj.UserList)
            {
                if (item.EmpNewRole > 0 || item.EmpNewSalary > 0)
                    newDemans.Add(item);
            }
            if (newDemans.Count > 0)
            {
                foreach (var item in newDemans)
                {
                    if (item.EmpNewRole > 0)
                    {
                        Console.WriteLine($"{item.EmpName} | Company role: {obj.RoleList[item.EmpRoleID - 1].RoleName} | New company role: {obj.RoleList[item.EmpNewRole - 1].RoleName}\n");
                        Console.WriteLine("Do you accept this new demand?\n[1]Yes\n[0]No");
                        var acceptNewDemand = Controller.UserInput.IsInputInterger(0, 1);
                        if (acceptNewDemand == 1)
                        {
                            item.EmpRoleID = item.EmpNewRole;
                        }

                    }
                    if (item.EmpNewSalary > 0)
                    {
                        Console.WriteLine($"{item.EmpName} | Current salary: {item.EmpSalary} | New salary demand: {item.EmpNewSalary}\n");
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
                obj.ConsoleMessage.ShowMessageAndClear("There are no new demands.");
            }

        }
        public bool CreateNewUser(VariableObject obj, string username, string password)
        {
            var newUsernameValid = true;

            if (username != obj.User.Username)
                foreach (var item in obj.UserList)
                {
                    if (item.Username == username)
                    {
                        newUsernameValid = false;
                    }
                }
            if (newUsernameValid)
            {
                obj.UserList.Add(new Models.UserAccount("New user", username, password, 4, 0, 0));
            }

            else
            {
                newUsernameValid = false;
            }

            return newUsernameValid;
        }
        public void AdvanceOneMonth(VariableObject obj)
        {
            var ConsoleMessage = new View.ConsoleMessages();
            foreach (var item in obj.UserList)
            {
                item.EmpBalance += item.EmpSalary;
            }
            obj.User.EmpBalance += obj.User.EmpSalary;
            ConsoleMessage.ShowMessageAndClear("One month has passed and everyone is richer");
        }
        public bool DeleteUser(VariableObject obj, string username, string password)
        {
            Models.UserAccount userToDelete = null;
            var usernameToDelete = username;
            for (var i = 0; i < obj.UserList.Count; i++)
            {
                if (obj.UserList[i].Username == usernameToDelete)
                {
                    userToDelete = obj.UserList[i];
                    obj.UserIndex = i;
                }
            }
            if (userToDelete != null)
            {

                if (password == userToDelete.Password)
                {
                    obj.UserList.RemoveAt(obj.UserIndex);
                    return true;
                }
                else return false;
            }
            else return false;
        }
        public bool IsUserNameValid(string username)
        {
            if (username.Any(char.IsDigit))
            {
                return username.Any(char.IsLetter);
            }
            else
                return false;
        }
    }
}
