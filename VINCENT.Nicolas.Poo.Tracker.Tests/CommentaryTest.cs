using NUnit.Framework;
using System;
using VINCENT.Nicolas.Poo.Tracker.Domains;

namespace VINCENT.Nicolas.Poo.Tracker.Tests
{
    public class CommentaryTest
    {
        [Test]
        public void GetTitelOnCommentary()
        {
            Commentary commentary = new("test","test");
            Assert.AreEqual( "test", commentary.Titel);
        }

        [Test]
        public void GetDescriptionOnCommentary()
        {
            Commentary commentary = new("test", "test");
            Assert.AreEqual("test", commentary.Description);
        }

        [Test]
        public void DateGetOnCommentary()
        {
            Commentary commentary = new("test", "test");
            Assert.AreEqual(DateTime.Now.ToString("dd-MM-yy"), commentary.DatePost);
        }


        [Test]
        public void toStringUseOnCommentary()
        {
            Commentary commentary = new("test", "test");
            DateTime auj = DateTime.Now;
            Assert.AreEqual(string.Format("test                            test             {0}       ", auj.ToString("dd-MM-yy")), commentary.ToString());
        }


    }
}
