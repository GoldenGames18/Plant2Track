using NUnit.Framework;
using System;
using System.Globalization;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{

    public class UserTest
    {


        [Test]
        public void GetName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");

            Assert.AreEqual("Nicolas", user.Name);
        }
        [Test]
        public void SetName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");
            user.Name = "Bob";

            Assert.AreEqual("Bob", user.Name);
        }
        [Test]
        public void GetFirstName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");

            Assert.AreEqual("Vincent", user.FirstName);
        }
        [Test]
        public void SetFirstName()
        {
            User user = new(new Login("", ""), "Nicolas", "Vincent");
            user.FirstName = "Bob";
            Assert.AreEqual("Bob", user.FirstName);
        }


        [Test]
        public void GetLogin()
        {
            Login login = new("", " ");
            User user = new(login, "Nicolas", "Vincent");
            Assert.AreEqual(login, user.Login);
        }

        [Test]
        public void Testdate()
        {
            /*DateTime start = new(2021,12,31);
            DateTime end = new(2022,02,10);
            int value = 0;
            while (end.CompareTo(start) != 0)
            {
                start = start.AddDays(1);
                value++;
                
            }*/
            /*
            DayOfWeek dayOfWeek = start.DayOfWeek;
            int timebetween = (end - start).Days;
            //Assert.AreEqual(365, value);
            


            int time = (start.Day % 7)+1;

            //Assert.AreEqual(time, 5);


            string path = @"c:\temp";
            

            JsonRepositoty json = new();

            List<Planning> list = json.LoadPlanning();

            Task old = new("a", "H042", DateTime.Parse("2021-12-15"), DateTime.Parse("2021-12-16"));
            Task task = new("a", "H042", DateTime.Parse("2021-12-15"), DateTime.Parse("2021-12-16"));
            old.Planning = "a";
            task.Planning = "a";
            task.AffectDateEnd();

            list = json.SaveData(task);

            */

            int value = ISOWeek.GetWeekOfYear(DateTime.Now);
            Console.WriteLine(value);



        }



    }

        

       
}
