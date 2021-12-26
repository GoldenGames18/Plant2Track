using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VINCENT.Nicolas.Poo.Tracker.Domains;
using Task = VINCENT.Nicolas.Poo.Tracker.Domains.Task;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class SetTaskRepositoryTest
    {

        [Test]
        public void GetStatutValue()
        {
            SetTaskRepository tasks = new();

            tasks.Value = "test";

            Assert.AreEqual("test", tasks.Value);

        }


        [Test]
        public void GetStartDateTime()
        {
            SetTaskRepository tasks = new();

            tasks.Start = DateTime.Today;

            Assert.AreEqual(DateTime.Today, tasks.Start);

        }


        [Test]
        public void GetEndDateTime()
        {
            SetTaskRepository tasks = new();

            tasks.End = DateTime.Today;

            Assert.AreEqual(DateTime.Today, tasks.End);

        }

        [Test]
        public void GetTabIndex()
        {
            SetTaskRepository tasks = new();

            double[] tab = { 0, 0 };

            tasks.TabIndex = tab;

            Assert.AreEqual(tab, tasks.TabIndex);

        }


        [Test]
        public void GetTabValue()
        {
            SetTaskRepository tasks = new();

            double[] tab = { 0, 0 };

            tasks.TabValue = tab;

            Assert.AreEqual(tab, tasks.TabValue);
        }



        [Test]
        public void ReverseSiteListTask()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task);
            tasks.Add(task2);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.ReverseSite();


            Assert.AreEqual(repository.Tasks[0], task2);
            Assert.AreEqual(repository.Tasks[1], task);

        }

        [Test]
        public void SortSiteListTask()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.SortSite();


            Assert.AreEqual(repository.Tasks[1], task2);
            Assert.AreEqual(repository.Tasks[0], task);

        }


        [Test]
        public void FilterLisOfTaskByNamePlanning()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.FindSite("Bob");


            Assert.AreEqual(repository.Tasks[0], task);

        }



        [Test]
        public void SortByStatu()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task);
            tasks.Add(task2);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.SortStatu();


            Assert.AreEqual(repository.Tasks[0], task2);
            Assert.AreEqual(repository.Tasks[1], task);

        }

        [Test]
        public void RevserseByStatu()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.ReverseStatu();


            Assert.AreEqual(repository.Tasks[1], task2);
            Assert.AreEqual(repository.Tasks[0], task);

        }

        [Test]
        public void SortByDate()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.SortDate();


            Assert.AreEqual(repository.Tasks[0], task2);
            Assert.AreEqual(repository.Tasks[1], task);

        }


        [Test]
        public void ReverseDate()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.ReverseDateStart();


            Assert.AreEqual(repository.Tasks[1], task2);
            Assert.AreEqual(repository.Tasks[0], task);

        }


        [Test]
        public void FindDateOnTaskStartTask()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.FindDate(DateTime.Today.ToString("dd-MM-yyyy"));


            Assert.AreEqual(repository.Tasks[0], task);


        }


        [Test]
        public void FindDateOnTaskEffectiveDateStart()
        {
            Task task = new("test", "ee", DateTime.Today, DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.FindDate(DateTime.Today.ToString("dd-MM-yyyy"));


            Assert.AreEqual(repository.Tasks[0], task);


        }

        [Test]
        public void FindDateSameStartAndEffective()
        {
            Task task = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.FindDate(DateTime.Today.ToString("dd-MM-yyyy"));


            Assert.AreEqual(repository.Tasks[0], task);


        }


        [Test]
        public void ResetFilterTask()
        {
            Task task = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);

            repository.FindDate(DateTime.Today.ToString("dd-MM-yyyy"));

            Assert.AreNotEqual(repository.Tasks, tasks);

            repository.ResetFilter();

            Assert.AreEqual(tasks, repository.Tasks);

        }


        [Test]
        public void FindStatutByName()
        {
            Task task = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.FindStatut("Terminée");


            Assert.AreEqual(repository.Tasks[0], task);


        }


        [Test]
        public void SortDateStart()
        {
            Task task = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(-3), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);


            repository.SortDateStart();


            Assert.AreEqual(repository.Tasks[1], task);
            Assert.AreEqual(repository.Tasks[0], task2);


        }



        [Test]
        public void SizeDayBetwenTwoDateDayValue()
        { 

            SetTaskRepository repository = new();
            repository.SizeDay(DateTime.Today, DateTime.Today.AddDays(1));
            Assert.AreEqual(repository.TabIndex.Length, 2);
           
        }


        [Test]
        public void CalculeGraphDay()
        {

            Task task = new("test", "ee", DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today);
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);



            repository.ValueDay(DateTime.Today, DateTime.Today);
            Assert.AreEqual(repository.TabValue.Length, 1);

        }


        [Test]
        public void SizeDayBetwenTwoDateWeekValue()
        {

            SetTaskRepository repository = new();
            repository.SizeWeek(DateTime.Today, DateTime.Today);
            Assert.AreEqual(repository.TabIndex.Length, 1);

        }


        [Test]
        public void CalculeGraphWeek()
        {

            Task task = new("test", "ee", DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);



            repository.ValueWeek(DateTime.Today, DateTime.Today);
            Assert.AreEqual(repository.TabValue.Length, 1);

        }

        [Test]
        public void SizeDayBetwenTwoDateMonthValue()
        {

            SetTaskRepository repository = new();
            repository.SizeMonth(DateTime.Today, DateTime.Today);
            Assert.AreEqual(repository.TabIndex.Length, 1);

        }


        [Test]
        public void CalculeGraphMonth()
        {

            Task task = new("test", "ee", DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today);
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);



            repository.ValueMonth(DateTime.Today, DateTime.Today);
            Assert.AreEqual(repository.TabValue.Length, 1);

        }

        [Test]
        public void CreateGraphDayNotDateTime()
        {

            Task task = new("test", "ee", DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today);
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);
            repository.Value = "test";


            repository.CreateGraph(DateTime.Today, DateTime.Today, "0");
            Assert.AreEqual(repository.TabValue.Length, 1);
            Assert.AreEqual(repository.TabIndex.Length, 1);

        }

        [Test]
        public void CreateGraphDayNotValue()
        {

            Task task = new("test", "ee", DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today);
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);
           


            repository.CreateGraph(DateTime.Today, DateTime.Today, "0");
            Assert.AreEqual(repository.TabValue.Length, 1);
            Assert.AreEqual(repository.TabIndex.Length, 1);

        }


        [Test]
        public void CreateGraphWeek()
        {

            Task task = new("test", "ee", DateTime.Today, DateTime.Today, DateTime.Today, DateTime.Today);
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today, DateTime.Today);
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);
            repository.Value = "test";



            repository.CreateGraph(DateTime.Today, DateTime.Today, 1+"");
            Assert.AreEqual(repository.TabValue.Length, 1);
            Assert.AreEqual(repository.TabIndex.Length, 1);

        }

        [Test]
        public void CreateGraphMothn()
        {

            Task task = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task);

            SetTaskRepository repository = new();
            repository.Add(tasks);

            repository.Value = "test";


            repository.CreateGraph(DateTime.Today, DateTime.Today, 2+"");
            Assert.AreEqual(repository.TabValue.Length, 1);
            Assert.AreEqual(repository.TabIndex.Length, 1);

        }

        [Test]
        public void DelayPlanning()
        {

            Task task = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task.Planning = "Bob";  
            Task task1 = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1), DateTime.Today, DateTime.Today.AddDays(1));
            task1.Planning = "Bob";
            Task task2 = new("test", "ee", DateTime.Today.AddDays(1), DateTime.Today.AddDays(1));
            task2.Planning = "Z";

            List<Task> tasks = new();
            tasks.Add(task2);
            tasks.Add(task1);
            tasks.Add(task);

            

            SetTaskRepository repository = new();
            repository.Add(tasks);

            
            var memory = repository.ExtractAssembly();
            Assert.AreEqual(memory["Bob"][1], task);
            Assert.AreEqual(memory["Bob"][0], task1);
            Assert.AreEqual(memory["Z"][0], task2);
            
            

        }







    }
}
