using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Controllers;
using VINCENT.Nicolas.Poo.Tracker.Datas;
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

            JsonRepositoty json = new();
            Task task = new("", "", default, default, default, default);
            task.Planning = "test";

            List<Planning> plannings = new();
            plannings.Add(new Planning("test", task));

            json.Planning = plannings;

            var sut = new TaskController(mockedView.Object, json);

            sut.StartTask += mockedObserver.Object;

            sut.AffectDateTaskStart(this, task);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<Task>()));


        }


        [Test]
        public void NotifyAboutUpdateEffectiveEndDateTask()
        {
            Mock<ITaskRepository> mockedView = new();

            Mock<EventHandler<Task>> mockedObserver = new();

            JsonRepositoty json = new();
            Task task = new("", "", default, default, default, default);
            task.Planning = "test";

            List<Planning> plannings = new();
            plannings.Add(new Planning("test", task));

            json.Planning = plannings;

            var sut = new TaskController(mockedView.Object, json);

            sut.EndTask += mockedObserver.Object;

            sut.AffectDateTaskEnd(this, task);

            mockedObserver.Verify(observer => observer(sut, It.IsAny<Task>()));


        }


       
        




    }
}
