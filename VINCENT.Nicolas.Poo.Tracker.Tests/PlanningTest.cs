using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class PlanningTest
    {
        [Test]
        public void GetName()
        {
            Task  task = new("aa","", default, default);
            Planning planning = new("test", task, task);
            Assert.AreEqual("test", planning.Name);
        }

        [Test]
        public void TaketaskWithCode()
        {
            Task task1 = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01), new DateTime(2021, 09, 06));
            Task task2 = new("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01));
            Planning planning = new("test", task1, task2);
            List<Task> taskUser = planning.TakeTask("D007");
            Assert.AreEqual(task1, taskUser[0]);
            Assert.AreEqual(1, taskUser.Count);
        }
        [Test]
        public void TaketaskWithCodeTwoTask()
        {
            Task task1 = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01), new DateTime(2021, 09, 06));
            Task task9 = new("Installer électricité", "D007", new DateTime(2021, 09, 05), new DateTime(2021, 09, 07), new DateTime(2021, 09, 05), new DateTime(2021, 09, 06));
            Task task2 = new("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01));
            Planning planning = new("test", task1, task2, task9);
            List<Task> taskUser = planning.TakeTask("D007");
            Assert.AreEqual(task1, taskUser[0]);
            Assert.AreEqual(task9, taskUser[1]);
            Assert.AreEqual(2, taskUser.Count);
        }

        [Test]
        public void TaketaskWithCodeNotPresentTask()
        {
            Task task1 = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01), new DateTime(2021, 09, 06));
            Task task9 = new("Installer électricité", "D007", new DateTime(2021, 09, 05), new DateTime(2021, 09, 07), new DateTime(2021, 09, 05), new DateTime(2021, 09, 06));
            Task task2 = new("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01));
            Planning planning = new("test", task1, task2, task9);
            List<Task> taskUser = planning.TakeTask("00");
            Assert.True(taskUser.Count == 0);
           
        }

        [Test]
        public void UseGiveNamePojectByTaskNotFound()
        {
            Task task1 = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01), new DateTime(2021, 09, 06));
            Task task9 = new("Installer électricité", "D007", new DateTime(2021, 09, 05), new DateTime(2021, 09, 07), new DateTime(2021, 09, 05), new DateTime(2021, 09, 06));
            Task task2 = new("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01));
            Planning planning = new("test", task1, task2);
            Assert.AreEqual(null, planning.GiveNamePojectByTask(task9));
            Assert.AreEqual("test", planning.GiveNamePojectByTask(task2));
        }

        [Test]
        public void TaketaskListOfAssembly()
        {
            Task task1 = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01), new DateTime(2021, 09, 06));
            Task task2 = new("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01));
            Planning planning = new("test", task1, task2);
            List<Task> tasks = new();
            tasks.Add(task1);
            tasks.Add(task2);
            Assert.AreEqual(tasks, planning.Tasks);

        }


        [Test]
        public void UpdateTaskPlanning()
        {
            Task task1 = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01));
            Task task2 = new("Installer eau", "G021", new DateTime(2021, 09, 01), new DateTime(2021, 09, 05), new DateTime(2021, 09, 01));
            Planning planning = new("test", task1, task2);
            List<Task> tasks = new();
            tasks.Add(task1);
            tasks.Add(task2);

            Task update = new("Installer electricité", "D007", new DateTime(2021, 09, 01), new DateTime(2021, 09, 06), new DateTime(2021, 09, 01));
            update.AffectDateEnd();

            planning.Update(update);
            Assert.AreEqual(update, planning.Tasks[0] );

        }



    }
}
