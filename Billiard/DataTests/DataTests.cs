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

        [Test] public void DataDisposeTest()
        {
            IOrb orb = DataApi.CreateOrb(100, 100);
            DataApi.Dispose(orb);
            double first_x = orb.X;
            double first_y = orb.Y;
            // sprawdzenie czy x i y (nie) zmieniaja sie w czasie
            Assert.That(orb.X, Is.EqualTo(first_x));
            Assert.That(orb.Y, Is.EqualTo(first_y));

        }

        [Test]
        public void OrbEventTest()
        {
            bool wasRaise = false;
            IOrb orb = DataApi.CreateOrb(100, 100);
            orb.PropertyChanged += (s, e) => { wasRaise = true; };
            System.Threading.Thread.Sleep(500); // trzeba poczekac bo timer wywoluje metode co ok. 100ms
            Assert.That(wasRaise, Is.EqualTo(true));
        }
    }
}
