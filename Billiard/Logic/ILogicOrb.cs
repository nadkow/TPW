using System.ComponentModel;
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
        public Vector Speed { get; }
        public Vector Coords { get; }
        public Object CoordsLock { get; }
        public Object SpeedLock { get; }
        public IOrb GetOrb();
        public void SetSpeed(double x, double y);
        public void Dispose();
        public void CollisionBorderX();
        public void CollisionBorderY();
    }
}
