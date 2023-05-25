namespace Model
{
    public delegate void PositionChanged(double x, double y);
    public interface ICircle
    {
        public double X { get; }
        public double Y { get; }
        public int D { get; }
        public event PositionChanged PropertyChanged;
    }
}
