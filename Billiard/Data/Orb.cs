using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Orb : IOrb
    {
        private int d = 10;
        private double xspeed;
        private double yspeed;
        private Vector coords = new Vector();
        private Vector speed = new Vector();
        private int period;
        private static Random rnd = new Random();
        private Object coordsLock = new Object();
        private Object speedLock = new Object();

        public double X { get => coords.x;}
        public double Y { get => coords.y;}
        public int D { get => d;}
        public double XSpeed { get => xspeed;}
        public double YSpeed { get => yspeed;}
        public Vector Speed { get => speed;}
        public Vector Coords { get => coords;}

        public void SetSpeed(double x, double y)
        {
            xspeed = x;
            yspeed = y;
            CalculatePeriod();
        }

        public event PositionChanged? PropertyChanged;

        public Orb(double x, double y)
        {
            coords.x = x;
            coords.y = y;
            // losowa predkosc poczatkowa
            xspeed = rnd.NextDouble() * 8 - 4;
            yspeed = rnd.NextDouble() * 8 - 4;
            CalculatePeriod();
            Start();
        }

        private void CalculatePeriod()
        {
            double v = Math.Sqrt((yspeed * yspeed) + (xspeed * xspeed));
            period = Convert.ToInt32(100 / v);
        }

        public void CollisionBorderX()
        {
            xspeed = -xspeed;
        }

        public void CollisionBorderY()
        {
            yspeed = -yspeed;
        }

        private async Task Start()
        {
            while (true)
            {
                coords.y += yspeed;
                coords.x += xspeed;
                this.PropertyChanged?.Invoke(this, coords.x, coords.y);           
                await Task.Delay(period);
            }
        }
    }
}