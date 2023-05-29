using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Data;

namespace DataTests
{
    [TestFixture]
    internal class DataTests
    {
        private DataAbstractApi DataApi = DataAbstractApi.CreateApi();
        [Test]
        public void DataCreateOrbTest() 
        {
            IOrb orb = DataApi.CreateOrb(100, 100);
            Assert.That(orb.Y, Is.AtMost(100));
            Assert.That(orb.X, Is.AtMost(100));
            Assert.That(orb.Y, Is.AtLeast(0));
            Assert.That(orb.X, Is.AtLeast(0));
        }


        [Test]
        public async Task OrbEventTest()
        {
            bool wasRaise = false;
            IOrb orb = DataApi.CreateOrb(100, 100);
            orb.PropertyChanged += (s, x, y) => { wasRaise = true; };
            Thread.Sleep(500);
            Assert.That(wasRaise, Is.EqualTo(true));
        }

        [Test]
        public async Task DataMoveTest()
        {
            IOrb orb = DataApi.CreateOrb(100, 100);
            double first_x = orb.X;
            double first_y = orb.Y;
            Thread.Sleep(500);
            Assert.That(orb.X, Is.Not.EqualTo(first_x));
            Assert.That(orb.Y, Is.Not.EqualTo(first_y));

        }
    }
}
