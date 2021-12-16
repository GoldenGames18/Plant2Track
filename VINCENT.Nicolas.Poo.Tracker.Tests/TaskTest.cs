using NUnit.Framework;
using System;
using System.Collections.Generic;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class TaskTest
    {

        [Test]
        public void AffectStatutAFaire()
        
        {
            DateTime dateTime = new(2021, 10, 6);
            Task task = new("aa", "aa", dateTime, dateTime);
            Assert.AreEqual(StatutTask.AFaire, task.GenerateStatut());
        }

        [Test]
            public void AffectStatutTerminer()
        {
            DateTime dateTime = new(2021, 10, 6);
            Task task = new("aa", "aa", dateTime, dateTime, dateTime, dateTime);
            Assert.AreEqual(StatutTask.Terminee, task.GenerateStatut());
        }

        [Test]
        public void AffectStatutEnCours()
        {
            DateTime dateTime = new(2021, 10, 6);
            Task task = new("aa", "aa", dateTime, dateTime, dateTime);
            Assert.AreEqual(StatutTask.EnCours, task.GenerateStatut());
        }



        [Test]
        public void DelayTimeIsPosistif()
        {
            DateTime dateTime = new(2021, 10, 08);
            DateTime yesterday = DateTime.Today.AddDays(-2);
            Task task = new("aa", "aa", dateTime, yesterday);
            Assert.AreEqual(2, task.DelayTime());
        }

        [Test]
        public void DelayTimeIsNegatif()
        {
            DateTime dateTime = new(2021, 10, 11);
            DateTime tomorrow = DateTime.Today.AddDays(+1);
            Task task = new("aa", "aa", dateTime, tomorrow);
            Assert.AreEqual(0, task.DelayTime());
        }

        [Test]
        public void DelayTimeIsAfterEnd()
        {
            DateTime dateTime = new(2021, 10, 06);
            Task task = new("aa", "aa", dateTime, dateTime, new DateTime(2021, 10, 06), new DateTime(2021, 10, 10));
            Assert.AreEqual(4, task.DelayTime());
        }



        

        [Test]
        public void SetDescription()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "aa", dateTime, dateTime)
            {
                Description = "Une description"
            };
            Assert.AreEqual("Une description", task.Description);
        }


        [Test]
        public void GetDescription()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new( "aa", "aa", dateTime, dateTime);
            Assert.AreEqual("aa", task.Description);
        }


        [Test]
        public void EffectiveDateIndefini()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "aa", dateTime, dateTime);
            Assert.AreEqual("Indéfinies", task.EffectiveDate());
        }

        [Test]
        public void EffectiveDateTerminer()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "aa", dateTime, dateTime, dateTime, dateTime);
            Assert.AreEqual("2021-10-08 2021-10-08", task.EffectiveDate());
        }

        [Test]
        public void ToStringTest()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "aa", dateTime, dateTime, dateTime, dateTime);
            Assert.AreEqual("| aa                             | 2021-10-08            2021-10-08 | Terminée             | 2021-10-08 2021-10-08               | 0                   ", task.ToString());
        }

        [Test]
        public void GetDateEnd()
        {
            DateTime dateTime = new(2021, 10, 08);
            Task task = new("aa", "aa", dateTime, dateTime);
            Assert.AreEqual("2021-10-08", task.DateEnd);
        }

        [Test]
        public void GetDateStart()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "aa", dateTime, dateTime);
            Assert.AreEqual("2021-10-08", task.DateStart);
        }


        [Test]
        public void GetCode()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "bob", dateTime, dateTime);
            Assert.AreEqual("bob", task.Code);
        }

        [Test]
        public void GetStatutTerminee()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "bob", dateTime, dateTime, dateTime, dateTime);
            Assert.AreEqual("Terminée", task.Statut);
        }

        [Test]
        public void GetStatutAFaire()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "bob", dateTime, dateTime);
            Assert.AreEqual("À faire", task.Statut);
        }

        [Test]
        public void GetStatutEnCours()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "bob", dateTime, dateTime, new DateTime(2001,02,18));
            Assert.AreEqual("En cours", task.Statut);
        }


        [Test]
        public void GetEffectiveDateStart()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "bob", dateTime, dateTime, dateTime);
            Assert.AreEqual("2021-10-08", task.EffectiveDateStart.ToString("yyyy-MM-dd"));
        }



        [Test]
        public void GetNameSiteTask()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("aa", "bob", dateTime, dateTime);
            Task task2 = new("aa", "bob", dateTime, dateTime);
            Task task3 = new("aa", "bob", dateTime, dateTime);
            Task task4 = new("aa", "bob", dateTime, dateTime);
            Planning planning = new("test", task, task3, task2);
            Planning planning1 = new("Bob", task4);
            List<Planning> planningList = new();
            planningList.Add(planning);
            planningList.Add(planning1);
            Assert.AreEqual("test", task.GetSite(planningList));
        }

        [Test]
        public void GetNameSiteTaskisNull()
        {
            DateTime dateTime = new(2021, 10, 8);
            Task task = new("a", "bob", dateTime, dateTime);
            Task task2 = new("b", "bob", dateTime, dateTime);
            Task task3 = new("c", "bob", dateTime, dateTime);
            Task task4 = new("d", "bob", dateTime, dateTime);
            Task task5 = new("e", "cccc", dateTime, dateTime);
            Planning planning = new("test", task, task3, task2);
            Planning planning1 = new("Bob", task4);
            List<Planning> planningList = new();
            planningList.Add(planning);
            planningList.Add(planning1);
            Assert.AreEqual(null, task5.GetSite(planningList));
        }


        


        [Test]
        public void DateStartAddNewDateStart()
        {
            Task task = new("", "", default, default);
            task.AffectDateStart();
            Assert.AreEqual(DateTime.Now.ToString("yyyy-MM-dd"), task.EffectiveDateStart.ToString("yyyy-MM-dd"));
        }

        [Test]
        public void DateStartAddNewDateEnd()
        {
            Task task = new("", "", default, default);
            task.AffectDateStart();
            task.AffectDateEnd();
            Assert.AreEqual(DateTime.Now.ToString("yyyy-MM-dd"), task.EffectiveDateEnd.ToString("yyyy-MM-dd"));
        }


        [Test]
        public void AddplanningNameToTheTask()
        {
            Task task = new("", "", default, default);
            task.Planning = "test";
            Assert.AreEqual("test", task.Planning);
        }


        [Test]
        public void UpdateDataAssemblyIsTrue()
        {
            Task task = new("", "", default, default);
            task.Planning = "test";
            Task taskUpdate = new("", "", default, default);
            taskUpdate.Planning = "test";
            Assert.True(task.Update(taskUpdate));
        }


        [Test]
        public void UpdateDataAssemblyButNamePlanningIsNotSame()
        {
            Task task = new("", "", default, default);
            task.Planning = "test";
            Task taskUpdate = new("", "", default, default);
            Assert.False(task.Update(taskUpdate));
        }

        [Test]
        public void UpdateDataAssemblyButDateEndIsNotSame()
        {
            Task task = new("", "", default, DateTime.Now);
            task.Planning = "test";
            Task taskUpdate = new("", "", default, default);
            Assert.False(task.Update(taskUpdate));
        }

        [Test]
        public void UpdateDataAssemblyButDateStartIsNotSame()
        {
            Task task = new("", "", DateTime.Now, default);
            task.Planning = "test";
            Task taskUpdate = new("", "", default, default);
            Assert.False(task.Update(taskUpdate));
        }

        [Test]
        public void UpdateDataAssemblyButDescriptionIsNotSame()
        {
            Task task = new("", "aaaaa", default, default);
            task.Planning = "test";
            Task taskUpdate = new("", "", default, default);
            Assert.False(task.Update(taskUpdate));
        }

        [Test]
        public void UpdateDataAssemblyButNameIsNotSame()
        {
            Task task = new("aaaa", "", default, default);
            Task taskUpdate = new("", "", default, default);
            Assert.False(task.Update(taskUpdate));
        }

    }
}
