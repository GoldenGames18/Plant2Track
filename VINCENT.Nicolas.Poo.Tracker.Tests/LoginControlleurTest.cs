using Moq;
using NUnit.Framework;
using System;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
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


            var sut = new LoginControlleur((str, test) => new Login(str, test));

            sut.AboutToQuit += mockedObserver.Object;

            sut.OnQuitRequested(this, EventArgs.Empty);

            mockedObserver.Verify(observer => observer(sut, EventArgs.Empty));

        }


        [Test]
        public void NotifiesOnValidLoginCreation()
        {
            Mock<ILoginView> mockedView = new();
            Mock<EventHandler<Login>> mockedObserver = new();

            var sut = new LoginControlleur((str, test) => new Login(str, test));
            sut.LoginRequested += mockedObserver.Object;

            sut.VerifyConnection(this, new Login("D007", "DaniBond"));

            mockedObserver.Verify(observer => observer(sut, new Login("D007", "DaniBond")));
        }

        

       



    }
}
