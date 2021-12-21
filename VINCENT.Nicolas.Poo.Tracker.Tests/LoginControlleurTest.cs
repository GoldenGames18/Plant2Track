using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Datas;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class LoginControlleurTest
    {


        [Test]
        public void NotifiesOnAboutToQuit()
        {
            Mock<ILoginView> mockedView = new();

            Mock<EventHandler> mockedObserver = new();

            JsonRepositoty json = new();



            var sut = new LoginControlleur((str, test) => new Login(str, test), json);

            sut.AboutToQuit += mockedObserver.Object;

            sut.OnQuitRequested(this, EventArgs.Empty);

            mockedObserver.Verify(observer => observer(sut, EventArgs.Empty));

        }


        [Test]
        public void NotifiesOnValidLoginCreation()
        {
            Mock<ILoginView> mockedView = new();
            Mock<EventHandler<Login>> mockedObserver = new();

            JsonRepositoty json = new();
            List<User> logins = new();
            logins.Add(new User (new Login("D007", "DaniBond"), "",""));
            json.Users =  logins;

            var sut = new LoginControlleur((str, test) => new Login(str, test), json);
            sut.LoginRequested += mockedObserver.Object;
            

            Login login = new("D007", "DaniBond");

            sut.VerifyConnection(this, login);

            mockedObserver.Verify(observer => observer(sut,  login));
            
        }

        [Test]
        public void IgnoresNotifyOnInvalidLoginPasseWord()
        {
            Mock<ILoginView> mockedView = new();
            Mock<EventHandler<Login>> mockedObserver = new();

            JsonRepositoty json = new();
            List<User> logins = new();
            logins.Add(new User(new Login("D007", "DaniBond"), "", ""));
            json.Users = logins;

            var sut = new LoginControlleur((str, test) => new Login(str, test), json);
            sut.LoginRequested += mockedObserver.Object;

            Login login = new("D007", "");

            try
            {
                sut.VerifyConnection(this, login);
            }
            catch (Exception)
            {
                mockedObserver.Verify(observer => observer(sut, login), Times.Never);
            }

        }


        [Test]
        public void IgnoresNotifyOnInvalidLoginUser()
        {
            Mock<ILoginView> mockedView = new();
            Mock<EventHandler<Login>> mockedObserver = new();

            JsonRepositoty json = new();
            List<User> logins = new();
            logins.Add(new User(new Login("D007", "DaniBond"), "", ""));
            json.Users = logins;

            var sut = new LoginControlleur((str, test) => new Login(str, test), json);
            sut.LoginRequested += mockedObserver.Object;

            Login login = new("", "");

            try
            {
                sut.VerifyConnection(this, login);
            }
            catch (Exception)
            {

                mockedObserver.Verify(observer => observer(sut, login), Times.Never);
            }

        }








    }
}
