using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public interface ILogicOrb : INotifyPropertyChanged
    {
        public double X { get; }
        public double Y { get; }
        public int D { get; }
        public double XSpeed { get; }
        public double YSpeed { get; }
        public IOrb GetOrb();
        public void SetSpeed(double x, double y);
        public void Start();
        public void Dispose();
        public void Collision(ILogicOrb CollidedOrb);
        public void CollisionBorderX();
        public void CollisionBorderY();
    }
}
