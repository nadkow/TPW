using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
            private int d = 10;
            private int period = 100;
            private Vector coords = new Vector();
            private Vector speed = new Vector();
            private Object speedLock = new Object();
            public MockOrb(double x, double y)
            {
                coords.x = x;
                coords.y = y;
            }

            public double X { get => coords.x; set => X = value; }
            public double Y { get => coords.y; set => Y = value; }
            public int D { get => d; set => D = value; }
            public double XSpeed { get => speed.x; }
            public double YSpeed { get => speed.y; }

            public Vector Speed { get { lock (speedLock) { return new Vector(speed.x, speed.y); } } }

            public Vector Coords { get => coords; }

            public event PropertyChangedEventHandler? PropertyChanged;

            event Data.PositionChanged IOrb.PropertyChanged
            {
                add
                {}

                remove
                {}
            }

            public void ChangeRoute(double xv, double yv){}

            public void Collision(IOrb orb){}

            public void CollisionBorderX(){}

            public void CollisionBorderY(){}

            public void DisposeTimer() { }
            public void SetSpeed(double x, double y) { }

            public async Task Start()
            {
                while (true)
                {
                    coords.y += speed.y;
                    coords.x += speed.x;
                    await Task.Delay(period);
                }
            }
        }

        sealed class MockDataApi : DataAbstractApi
        {

            public override IOrb CreateOrb(int tableWidth, int tableHeight)
            {
                return new MockOrb(1, 1);
            }

            public override void Start(int tableWidth, int tableHeight, int noOfOrbs)
            {
                
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
            LogicApi.Dispose();
            LogicApi.Start(100, 100, 10);
            Assert.That(10, Is.EqualTo(LogicApi.GetLogicOrbs().Count));
            LogicApi.Dispose();
            Assert.That(0, Is.EqualTo(LogicApi.GetLogicOrbs().Count));

        }

    }
}
