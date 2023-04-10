using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Data;

namespace TestProject
{
    [TestFixture]
    internal class DataTests
    {
        private DataAbstractApi DataApi = DataAbstractApi.CreateApi();
        [Test]
        public void DataStartTest() 
        {
            DataApi.Start(100, 100, 10);
            Assert.IsNotNull(DataApi.getOrbs());
            Assert.That(DataApi.getOrbs().Count, Is.EqualTo(10));
            Orb orb = DataApi.getOrbs().First();
            Assert.That(orb.Y, Is.AtMost(100));
            Assert.That(orb.X, Is.AtMost(100));
            Assert.That(orb.Y, Is.AtLeast(0));
            Assert.That(orb.X, Is.AtLeast(0));
        }
    }
}
