using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SE22;

namespace SE22.Tests
{
    [TestClass]
    public class UnitTest1
    {
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
            ForumThread before;
            ForumThread after;
            Post PostUsedToAssert = null;
            int threadID = 1;
            string content = "test";
            string username = "example2";
            int postID = int.MinValue;

            //act
            SE22.Tests.MainAdministration.StartUp();
            before = SE22.Tests.DatabaseManager.UpdateThread(threadID);
            postID = SE22.Tests.DatabaseManager.GetNewID("post");
            SE22.Tests.DatabaseManager.CreateNewPost(threadID, content, username);
            after = SE22.Tests.DatabaseManager.UpdateThread(threadID);

            if (before.Posts.Count < after.Posts.Count)
            {
                PostUsedToAssert = after.Posts.Find(x => x.ID == postID);
            }
            else
            {
                Assert.Fail();
            }

            TestDeletePost(postID, threadID);

            Assert.IsNotNull(PostUsedToAssert);
        }

        [TestMethod()]
        public void TestDeletePost(int id, int threadID)
        {
            // Arrange
            ForumThread before;
            ForumThread after;

            //act
            SE22.Tests.MainAdministration.StartUp();
            before = SE22.Tests.DatabaseManager.UpdateThread(threadID);
            DatabaseManager.DeletePost(id);
            after = SE22.Tests.DatabaseManager.UpdateThread(threadID);

            Assert.AreNotSame(before.Posts.Count, after.Posts.Count);
        }
    }
}
