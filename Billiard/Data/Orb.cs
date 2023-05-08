using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Orb : IOrb
    {
        private double x;
        private double y;
        private int d = 10;
        private int m = 5;
        private double xspeed;
        private double yspeed;
        private int period = 100;
        private Timer ChangePositionTimer;
        private Random rnd = new Random();

        public double X { get => x;}
        public double Y { get => y;}
        public int D { get => d;}
        public int M { get => m; }
        public double XSpeed { get => xspeed;}
        public double YSpeed { get => yspeed;}
        public void SetSpeed(double x, double y)
        {
            xspeed = x;
            yspeed = y;
            CalculatePeriod();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Orb(double x, double y)
        {
            this.x = x;
            this.y = y;
            // losowa predkosc poczatkowa
            xspeed = rnd.NextDouble() * 6 - 3;
            yspeed = rnd.NextDouble() * 6 - 3;
            Start();
            CalculatePeriod();
        }

        private void CalculatePeriod()
        {
            double v = Math.Sqrt((yspeed * yspeed) + (xspeed * xspeed));
            period = (int)(100 / v);
        }

        public void Collision(IOrb orb)
        {
            double xv = xspeed;
            double yv = yspeed;
            ChangeRoute(orb.XSpeed, orb.YSpeed);
            orb.ChangeRoute(xv,yv);
        } 

        public void ChangeRoute(double xv, double yv)
        {
            xspeed = xv;
            yspeed = yv;
            CalculatePeriod();
        }

        public void CollisionBorder(String axis)
        {
            if(axis == "x")
            {
                xspeed = -xspeed;
                CalculatePeriod();
            }
            else if (axis == "y")
            {
                yspeed = -yspeed;
                CalculatePeriod();
            }
        }
        public async Task Start()
        {
            while (true) //to zamiast funkcji ChangePosition i Timera
            {
                x += xspeed;
                y += yspeed;
                OnPropertyChanged();
                await Task.Delay(period);
            }
        }

        public void DisposeTimer()
        {
            ChangePositionTimer.Dispose();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}