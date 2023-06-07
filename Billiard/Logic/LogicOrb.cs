using Data;

namespace Logic
{
    internal class LogicOrb : ILogicOrb
    {
        IOrb orb;
        private int diameter;
        private Vector coords = new Vector();
        private Object coordsLock = new Object();
        private Object speedLock = new Object();
        public event PositionChanged? PropertyChanged;
        public double X { get => coords.x;}
        public double Y { get => coords.y;}
        public int D { get => diameter;}
        public Vector Speed { get => orb.Speed; }
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
            lock(orb.CoordsLock)
            {
                coords.x = orb.Coords.x;
                coords.y = orb.Coords.y;
            }
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
            this.PropertyChanged?.Invoke(this, coords.x, coords.y);
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
    }
}
