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

        public double X { get => coords.x;}
        public double Y { get => coords.y;}
        public int D { get => d;}
        public double XSpeed { get => speed.x;}
        public double YSpeed { get => speed.y;}
        public Vector Speed { get { lock (speedLock) { return new Vector(speed.x, speed.y); } } }
        public Vector Coords { get => coords;}

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
            speed.x = -speed.x;
        }

        public void CollisionBorderY()
        {
            speed.y = -speed.y;
        }

        private async Task Start()
        {
            while (true)
            {
                coords.y += speed.y;
                coords.x += speed.x;
                this.PropertyChanged?.Invoke(this, coords.x, coords.y);           
                await Task.Delay(period);
            }
        }
    }
}