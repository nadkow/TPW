using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Orb : IOrb
    {
        private int d = 10;
        private Vector coords = new Vector();
        private Vector speed = new Vector();
        private int period;
        private static Random rnd = new Random();
        private Object speedLock = new Object();
        private Object coordsLock = new Object();

        public int D { get => d;}
        public Object CoordsLock { get => coordsLock; }
        public Vector Speed { get { lock (speedLock) { return new Vector(speed.x, speed.y); } } }
        public Vector Coords { get { lock (coordsLock) { return new Vector(coords.x, coords.y); } } }

        public void SetSpeed(double x, double y)
        {
            lock(speedLock)
            {
                speed.x = x;
                speed.y = y;
            }
            CalculatePeriod();
        }

        public event PositionChanged? PropertyChanged;

        public Orb(double x, double y)
        {
            coords.x = x;
            coords.y = y;
            // losowa predkosc poczatkowa
            speed.x = rnd.NextDouble() * 8 - 4;
            speed.y = rnd.NextDouble() * 8 - 4;
            CalculatePeriod();
            Start();
        }

        private void CalculatePeriod()
        {
            double v;
            lock (speedLock)
            {
                v = Math.Max(Math.Abs(speed.x), Math.Abs(speed.y));
            }
            v += 1; // +1 żeby nie było <0;1)
            period = Convert.ToInt32(100 / v); // max 100 min 20
        }

        public void CollisionBorderX()
        {
            lock (speedLock)
            {
                speed.x = -speed.x;
            }
        }

        public void CollisionBorderY()
        {
            lock (speedLock)
            {
                speed.y = -speed.y;
            }
        }

        private async Task Start()
        {
            while (true)
            {
                lock (coordsLock)
                {
                    lock (speedLock)
                    {
                        coords.y += speed.y;
                        coords.x += speed.x;
                    }
                    this.PropertyChanged?.Invoke(this, coords.x, coords.y);
                }
                await Task.Delay(period);
            }
        }
    }
}