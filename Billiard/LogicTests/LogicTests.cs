using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace LogicTests
{
    [TestFixture]
    internal class LogicTests
    {
        sealed class MockOrb : IOrb
        {
            private double x;
            private double y;
            private int d = 10;
            public MockOrb(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double X { get => x; set => X = value; }
            public double Y { get => y; set => Y = value; }
            public int D { get => d; set => D = value; }

            public event PropertyChangedEventHandler? PropertyChanged;

            public void DisposeTimer()
            {

            }
        }

        sealed class MockDataApi : DataAbstractApi
        {
            public override void Dispose(IOrb orb)
            {
                orb.DisposeTimer();
            }

            public override IOrb CreateOrb(int tableWidth, int tableHeight)
            {
                return new MockOrb(1, 1);
            }
        }

        private static MockDataApi DataApi = new MockDataApi();
        private LogicAbstractApi LogicApi = LogicAbstractApi.CreateApi(DataApi);
        [Test]
        public void LogicStartTest()
        {
            LogicApi.Start(100, 100, 10);
            Assert.IsNotNull(LogicApi.GetLogicOrbs());
            Assert.That(10, Is.EqualTo(LogicApi.GetLogicOrbs().Count));
        }
        [Test]
        public void LogicStopTest()
        {
            LogicApi.Start(100, 100, 10);
            Assert.That(10, Is.EqualTo(LogicApi.GetLogicOrbs().Count));
            LogicApi.Dispose();
            Assert.That(0, Is.EqualTo(LogicApi.GetLogicOrbs().Count));

        }

    }
}
