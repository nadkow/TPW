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
            Assert.That(orb.Coords.y, Is.AtMost(100));
            Assert.That(orb.Coords.x, Is.AtMost(100));
            Assert.That(orb.Coords.y, Is.AtLeast(0));
            Assert.That(orb.Coords.x, Is.AtLeast(0));
        }


        [Test]
        public async Task OrbEventTest()
        {
            bool wasRaise = false;
            IOrb orb = DataApi.CreateOrb(100, 100);
            orb.PropertyChanged += (s, Coords) => { wasRaise = true; };
            Thread.Sleep(500);
            Assert.That(wasRaise, Is.EqualTo(true));
        }

        [Test]
        public async Task DataMoveTest()
        {
            IOrb orb = DataApi.CreateOrb(100, 100);
            double first_x = orb.Coords.x;
            double first_y = orb.Coords.y;
            Thread.Sleep(500);
            Assert.That(orb.Coords.x, Is.Not.EqualTo(first_x));
            Assert.That(orb.Coords.y, Is.Not.EqualTo(first_y));

        }
    }
}
