using System.ComponentModel;

namespace Data
{
    public delegate void PositionChanged(IOrb sender, double x, double y);
    public interface IOrb
    {
        public double X { get;}
        public double Y { get;}
        public int D { get;}
        public int M { get;}
        public double XSpeed { get;}
        public double YSpeed { get;}
        public Vector Speed { get;}
        public Vector Coords { get; }
        public event PositionChanged PropertyChanged;
        public void SetSpeed(double x, double y);
        public void CollisionBorderX();
        public void CollisionBorderY();
    }
}
