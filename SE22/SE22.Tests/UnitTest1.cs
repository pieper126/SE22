using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE22;

namespace SE22.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod()]
        public void InlogTest()
        {
            // Arrange
            string password = "password";
            string username = "example1";
            User user;
            User userUsedToReference;

            //act
            user = SE22.Tests.DatabaseManager.LogIn(username, password);
            userUsedToReference = new User("example1", "example1@example.com", new System.Collections.Generic.List<Rights> { });

            //assert
            Assert.AreEqual(user.Username, userUsedToReference.Username);
            Assert.AreEqual(user.Functions.Count, userUsedToReference.Functions.Count);
            Assert.AreEqual(user.Email, userUsedToReference.Email);

        }

        [TestMethod()]
        public void InlogTest1()
        {
            // Arrange
            string password = "passwod";
            string username = "example1";
            User user;

            //act
            user = SE22.Tests.DatabaseManager.LogIn(username, password);

            //assert
            Assert.IsNull(user);
        }

        [TestMethod()]
        public void InlogTest2()
        {
            // Arrange
            string password = "; DROP ALL TABLES";
            string username = "example1";
            User user;

            //act
            user = SE22.Tests.DatabaseManager.LogIn(username, password);

            //assert
            Assert.IsNull(user);
        }

        [TestMethod()]
        public void NewIDTest()
        {
            // Arrange
            MainAdministration.StartUp();
            

            //act
            DatabaseManager.LogIn(username, password);

            Assert.Fail();
        }
    }
}
