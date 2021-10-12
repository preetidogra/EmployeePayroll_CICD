using NUnit.Framework;
using Uppgift1_CICD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1_CICD.Tests
{
    [TestFixture()]
    public class ProgramTests
    {
        [Test()]
        public void RunProgramTest()
        {
            var obj = new Controller.VariableObject();
            CreateDatabase.CreateListOCompanyRoles(obj);
            CreateDatabase.CreateListOfUsers(obj);
            obj.Admin = CreateDatabase.admin1;
            var signInAdmin = Program.SignIn("admin1", "admin1234", obj);
            var signInUser1 = Program.SignIn("phiras001", "qasw12", obj);
            var signInUser2 = Program.SignIn("predog001", "qasw12", obj);

            Assert.IsTrue(signInAdmin);
            Assert.IsTrue(signInUser1);
            Assert.IsTrue(signInUser2);
        }
        
        [Test()]
        public void IntegrationTestDeleteUser()
        {
            var obj = new Controller.VariableObject();
            var adminActions =  new Controller.Actions.AdminActions();
            CreateDatabase.CreateListOCompanyRoles(obj);
            CreateDatabase.CreateListOfUsers(obj);
            obj.Admin = CreateDatabase.admin1;
            var signInAdmin = Program.SignIn("admin1", "admin1234", obj);
            var initialUserListLength = obj.UserList.Count;
            var firstTryToDelete = adminActions.DeleteUser(obj, "phiras001", "qasw12");
            var postDeleteUserListLength = obj.UserList.Count;
           var secondTryToDelete = adminActions.DeleteUser(obj, "phiras001", "qasw12");

            Assert.IsTrue(signInAdmin);
            Assert.Greater( initialUserListLength, postDeleteUserListLength);
            Assert.IsTrue(firstTryToDelete);
            Assert.IsFalse(secondTryToDelete);
        }
        [Test()]
        public void IntegrationTestCreateUser()
        {
            var obj = new Controller.VariableObject();
            var adminActions =  new Controller.Actions.AdminActions();
            CreateDatabase.CreateListOCompanyRoles(obj);
            CreateDatabase.CreateListOfUsers(obj);
            obj.Admin = CreateDatabase.admin1;
            Program.SignIn("admin1", "admin1234", obj);
            var initialUserListLength = obj.UserList.Count;
            var createExistingUser = adminActions.CreateNewUser(obj, "phiras001", "qasw12");
           var createNewUser = adminActions.CreateNewUser(obj, "newusers001", "qasw12");
            var postCreateUserListLength = obj.UserList.Count;

            Assert.Greater( postCreateUserListLength, initialUserListLength);
            Assert.IsFalse(createExistingUser);
            Assert.IsTrue(createNewUser);
        }

    }
}