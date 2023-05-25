using Logic;

namespace Model
{
    internal class Circle : ICircle
    {
        // wizualna reprezentacja Orb
        private double x;
        private double y;
        private int diameter;

        public event PositionChanged? PropertyChanged;

        public Circle(ILogicOrb orb)
        {
            diameter = orb.D;
            x = orb.X - 5;
            y = orb.Y - 5; 
            orb.PropertyChanged += Update;

        }
        public double X { get => x;}
        public double Y { get => y;}
        public int D { get => diameter;}

        private void Update(ILogicOrb orb, double x, double y)
        {
            this.x = x - 5;
            this.y = y - 5;
            this.PropertyChanged?.Invoke(this.x, this.y);
        }
    }
}
