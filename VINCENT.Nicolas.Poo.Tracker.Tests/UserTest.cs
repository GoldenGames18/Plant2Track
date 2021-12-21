using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using VINCENT.Nicolas.Poo.Tracker.Datas;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{

    public class UserTest
    {


        [Test]
        public void GetName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");

            Assert.AreEqual("Nicolas", user.Name);
        }
        [Test]
        public void SetName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");
            user.Name = "Bob";

            Assert.AreEqual("Bob", user.Name);
        }
        [Test]
        public void GetFirstName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");

            Assert.AreEqual("Vincent", user.FirstName);
        }
        [Test]
        public void SetFirstName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");
            user.FirstName = "Bob";
            Assert.AreEqual("Bob", user.FirstName);
        }


        [Test]
        public void GetLogin()
        {
            Login login = new("", " ");
            User user = new(login, "Nicolas", "Vincent");
            Assert.AreEqual(login, user.Login);
        }

       



    }

        

       
}
