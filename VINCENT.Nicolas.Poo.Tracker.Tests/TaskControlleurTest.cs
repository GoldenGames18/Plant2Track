using Moq;
using NUnit.Framework;
using System;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Domains;
using Task = VINCENT.Nicolas.Poo.Tracker.Domains.Task;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class TaskControlleurTest
    {
        [Test]
        public void NotifyAboutUpdateEffectiveStartDatetask()
        {
            Mock<ITaskRepository> mockedView = new();

            Mock<EventHandler<Task>> mockedObserver = new();


            var sut = new TaskController(mockedView.Object);

            sut.StartTask += mockedObserver.Object;

            sut.AffectDateTaskStart(this, new Task("","",default, default, default, default));

            mockedObserver.Verify(observer => observer(sut, It.IsAny<Task>()));


        }


        [Test]
        public void NotifyAboutUpdateEffectiveEndDateTask()
        {
            Mock<ITaskRepository> mockedView = new();

            Mock<EventHandler<Task>> mockedObserver = new();


            var sut = new TaskController(mockedView.Object);

            sut.EndTask += mockedObserver.Object;

            sut.AffectDateTaskEnd(this, new Task("", "", default, default, default, default));

            mockedObserver.Verify(observer => observer(sut, It.IsAny<Task>()));


        }


    }
}
