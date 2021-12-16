using NUnit.Framework;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class LoginTest
    {

        [Test]
        public void GetCodeOnObjectLogin()

        {
            Login login = new("aaa", "bbbb");
            Assert.AreEqual("aaa", login.Code);
        }


        [Test]
        public void GetMdpsOnnObjectLogin()

        {
            Login login = new("aaa", "bbbb");
            Assert.AreEqual("bbbb", login.Mdps);
        }


        [Test]
        public void MdpsWithWitheSpaceIsFalse()
        {
            Login user = new("cccc", "5654654654");
            Assert.False(user.WitheSpaceMdps());
        }


        [Test]
        public void MdpsWithWitheSpaceIsTrueWitheSpace()
        {
            Login user = new("cccc", "    ");
            var exeption = Assert.Throws<Exception>(() => user.WitheSpaceMdps());
            Assert.AreEqual("Mots de passe est vide", exeption.Message);
        }


        [Test]
        public void MdpsWithWitheSpaceIsTrueValueNull()
        {
            Login user = new("cccc", null);
            var exeption  = Assert.Throws<Exception>(() => user.WitheSpaceMdps());
            Assert.AreEqual("Mots de passe est vide", exeption.Message);
        }

        [Test]
        public void MemberIxistingInTheList()
        {
            Login user = new("abc", "123456");
            List<User> allUsers = new();
            allUsers.Add(new(user, "Nicolas", "Vincent"));
            Assert.True(user.ListMumber(allUsers));
        }

        [Test]
        public void MemberNotIxistingInTheList()
        {
            Login user = new("cccc", "5654654654");
            List<User> allUsers = new();
            allUsers.Add(new(new("",""), "Nicolas", "Vincent"));
            var expetion  = Assert.Throws<Exception>(() => user.ListMumber(allUsers));
            Assert.AreEqual("Authentification échouée", expetion.Message);

        }


        [Test]
        public void TestingOverideEqualsIsFalse()
        {
            Login user = new("cccc", "5654654654");
            Assert.False(user.Equals(new Login("","")));
        }

        [Test]
        public void TestingOverideEqualsIsFalseCode()
        {
            Login user = new("cccc", "5654654654");
            Assert.False(user.Equals(new Login("aaa", "5654654654")));
        }

        [Test]
        public void TestingOverideEqualsIsFalseMdps()
        {
            Login user = new("cccc", "5654654654");
            Assert.False(user.Equals(new Login("cccc", "489849894")));
        }


        [Test]
        public void TestingOverideEqualsIsTrue()
        {
            Login user = new("cccc", "cccc");
            Assert.True(user.Equals(new Login("cccc", "cccc")));
        }



        [Test]
        public void GetHashCodeValue()
        {
            Login user = new("cccc", "cccc");
            Assert.AreEqual(user.GetHashCode(), user.GetHashCode());
        }

        [Test]
        public void CodeWithWitheSpaceIsTrueValueNull()
        {
            Login user = new(null, null);
            var exeption = Assert.Throws<Exception>(() => user.WitheSpaceCode());
            Assert.AreEqual("Le code est vide", exeption.Message);
        }

        [Test]
        public void CodeWithWitheSpaceIsFalse()
        {
            Login user = new("cccc", "5654654654");
            Assert.False(user.WitheSpaceCode());
        }



    }
}
