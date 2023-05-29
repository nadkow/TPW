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
            private double x;
            private double y;
            private int d = 10;
            private int m = 5;
            private double xspeed;
            private double yspeed;
            private int period = 100;
            public MockOrb(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public double X { get => x; set => X = value; }
            public double Y { get => y; set => Y = value; }
            public int D { get => d; set => D = value; }
            public int M { get  => m; set => m = value; }
            public double XSpeed { get => xspeed; }
            public double YSpeed { get => yspeed; }

            public Vector Speed => throw new NotImplementedException();

            public Vector Coords => throw new NotImplementedException();

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
                while (true) //to zamiast funkcji ChangePosition i Timera
                {
                    x += xspeed;
                    y += yspeed;
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
