using NUnit.Framework;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class DelayViewModelTest
    {

        [Test]
        public void GetTitleOfListOfAssembly()
        {
            Task _task = new("","", default, default );
            _task.Planning = "test";
            List<Task> list = new();
            list.Add(_task);
            DelayViewModel delayViewModel = new(list);

            Assert.AreEqual("test", delayViewModel.Name);
        }

        [Test]
        public void GetDelayListAssembly()
        {
            Task _task = new("", "", DateTime.Today.AddDays(-1), DateTime.Today, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));
            _task.Planning = "test";
            Task _task2 = new("", "", DateTime.Today.AddDays(-1), DateTime.Today, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));
            _task2.Planning = "test";
            List<Task> list = new();
            list.Add(_task);
            list.Add(_task2);
            DelayViewModel delayViewModel = new(list);

            Assert.AreEqual("2 jours de retard", delayViewModel.Delay);
        }
    }
}
