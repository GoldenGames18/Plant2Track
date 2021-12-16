using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class MainControlleurTest
    {
        

        [Test]
        public void NotifiesOnFilterStatutByTypeNameAndSortStatut()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("1");
            vs.Add("1");
            vs.Add("Terminée");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()  ));

        }


        [Test]
        public void NotifiesOnFilterStatutByTypeNameAndReverseStatut()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("2");
            vs.Add("1");
            vs.Add("Terminée");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()));

        }

        [Test]
        public void NotifiesOnFilterAssemblyByTypeNameAndSortStatut()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("1");
            vs.Add("2");
            vs.Add("Helmo");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()));

        }

        [Test]
        public void NotifiesOnFilterAssemblyByTypeNameAndReverseStatut()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("2");
            vs.Add("2");
            vs.Add("");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()));

        }

        [Test]
        public void NotifiesOnFilterDateByTypeNameAndSortStatut()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("1");
            vs.Add("3");
            vs.Add("10/10/10");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()));

        }

        [Test]
        public void NotifiesOnFilterDateByTypeNameAndReverseStatut()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("2");
            vs.Add("3");
            vs.Add("");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()));

        }

        [Test]
        public void NotifiesOnResetFilter()
        {
            Mock<IMainView> mockedView = new();
            Mock<ITaskRepository> mockRepository = new();
            Mock<EventHandler<List<string>>> mockedObserver = new();


            var sut = new MainControlleur(mockRepository.Object);
            sut.Filter += mockedObserver.Object;


            List<string> vs = new();
            vs.Add("0");
            vs.Add("0");
            vs.Add("");

            sut.Affect(this, vs);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<List<string>>()));

        }

    }
}
