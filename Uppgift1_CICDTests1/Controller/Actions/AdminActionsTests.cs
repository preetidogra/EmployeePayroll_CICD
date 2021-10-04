using NUnit.Framework;
using Uppgift1_CICD.Controller.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Controller.Actions.Tests
{
    [TestFixture()]
    public class AdminActionsTests
    {
        [Test()]
        public void IsUserNameValidTest()
        {
            var method = new Controller.Actions.AdminActions();
            Assert.AreEqual(true, method.IsUserNameValid("df4"));
            Assert.AreEqual(true, method.IsUserNameValid("df4333"));
            Assert.AreEqual(false, method.IsUserNameValid("3232"));
            Assert.AreEqual(false, method.IsUserNameValid("dfdfd"));
            Assert.AreEqual(false, method.IsUserNameValid("44S"));
        }
    }
}