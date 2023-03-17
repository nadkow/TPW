namespace BilliardLibrary
{
    public class Orb
    {
        private int radius;

        public Orb(int radius)
        {
            this.radius = radius;
        }

        public int Radius { get => radius; set => radius = value; }

        public override bool Equals(object? obj)
        {
            return obj is Orb orb &&
                   radius == orb.radius;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(radius);
        }
    }
}