using Data;

namespace Logic
{
    public delegate void PositionChanged(ILogicOrb sender, double x, double y);
    public interface ILogicOrb
    {
        public double X { get; }
        public double Y { get; }
        public int D { get; }
        public double XSpeed { get; }
        public double YSpeed { get; }
        public Vector Speed { get; }
        public Vector Coords { get; }
        public Object CoordsLock { get; }
        public event PositionChanged PropertyChanged;
        public IOrb GetOrb();
        public void SetSpeed(double x, double y);
        public void Dispose();
        public void CollisionBorderX();
        public void CollisionBorderY();
    }
}
