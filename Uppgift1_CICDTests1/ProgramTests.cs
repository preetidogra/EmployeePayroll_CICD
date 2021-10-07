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
            obj.UserIndex = -1;
            var signIn = Program.SignIn("admin1", "admin1234", obj);

            Assert.IsTrue(signIn);
        }
    }
}