using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    class TaskViewModalTest
    {

        [Test]
        public void DescriptionView() 
        {
            TaskViewModel task = new(new Domains.Task("description", "code", default, default));
            Assert.AreEqual("description", task.Description);
        }



        [Test]
        public void ChantierView()
        {
            TaskViewModel task = new(new Domains.Task("description", "code", default, default));
            task.Task.Planning = "test";
            Assert.AreEqual("test", task.Chantier);
        }


        [Test]
        public void DateView()
        {
            TaskViewModel task = new(new Domains.Task("description", "code", default, default));
            Assert.AreEqual("Du 0001-01-01 au 0001-01-01", task.Date);
        }


        [Test]
        public void DelayView()
        {
            TaskViewModel task = new(new Domains.Task("description", "code", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            Assert.AreEqual(0, task.Delay);
        }

        [Test]
        public void StatutView()
        {
            TaskViewModel task = new(new Domains.Task("description", "code", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            Assert.AreEqual("Terminée", task.Statut);
        }

        [Test]
        public void EffectievDateStartView()
        {
            TaskViewModel task = new(new Domains.Task("description", "code", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            Assert.AreEqual(DateTime.Now.ToString("dd-MM-yyyy"), task.EffectiveDateStart.ToString("dd-MM-yyyy"));
        }

        [Test]
        public void EffectievDateEndView()
        {
            TaskViewModel task = new(new Domains.Task("description", "code", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
            Assert.AreEqual(DateTime.Now.ToString("dd-MM-yyyy"), task.EffectiveDateEnd.ToString("dd-MM-yyyy"));
        }
    }
}
