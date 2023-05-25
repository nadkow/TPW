using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class LogicOrb : ILogicOrb
    {
        IOrb orb;
        private int diameter;
        private Vector coords = new Vector();
        private Vector speed = new Vector();
        private Object coordsLock = new Object();
        private Object speedLock = new Object();
        public event PropertyChangedEventHandler? PropertyChanged;
        public double X { get => coords.x;}
        public double Y { get => coords.y;}
        public int D { get => diameter;}
        public double XSpeed { get => orb.XSpeed;}
        public double YSpeed { get => orb.YSpeed;}
        public Vector Speed { get => speed; }
        public Vector Coords { get => coords; }
        public Object CoordsLock { get => coordsLock; }
        public Object SpeedLock { get => speedLock; }
        public void SetSpeed(double x, double y)
        {
            orb.SetSpeed(x, y);
        }
        public IOrb GetOrb() { return orb; }
        public LogicOrb(IOrb orb)
        {
            this.orb = orb;
            coords.x = orb.X;
            coords.y = orb.Y;
            diameter = orb.D;
            orb.PropertyChanged += Update;
        }
       
        private void Update(IOrb sender, double x, double y)
        {
            lock(coordsLock)
            {
                coords.x = x;
                coords.y = y;
            }
            OnPropertyChanged();
        }

        public void Dispose()
        {
            //pass
        }

        public void CollisionBorderX()
        {
            orb.CollisionBorderX();
        }
        public void CollisionBorderY()
        {
            orb.CollisionBorderY();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
