using System.ComponentModel;

namespace Data
{
    public delegate void PositionChanged(IOrb sender, Vector newCoords);
    public interface IOrb
    {
        public int D { get;}
        public Vector Speed { get;}
        public Vector Coords { get; }
        public Object CoordsLock { get; }
        public event PositionChanged PropertyChanged;
        public void SetSpeed(double x, double y);
        public void CollisionBorderX();
        public void CollisionBorderY();
    }
}
