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
    public class CreateDatabaseTests
    {
        [Test()]
        public void CreateListOfUsersTest()
        {
            var obj = new Controller.VariableObject();
            CreateDatabase.CreateListOfUsers(obj);
            CreateDatabase.CreateListOCompanyRoles(obj);

            Assert.AreEqual(10, obj.UserList.Count);
            Assert.AreEqual(4, obj.RoleList.Count);
        }
    }
}