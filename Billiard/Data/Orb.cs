using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb
    {
        private int radius;
        private int x;
        private int y;

        public Orb(int radius, int x, int y)
        {
            this.radius = radius;
            this.x = x;
            this.y = y;
        }

        void changePosition() //domyslnym kwalifikatorem dostepu jest internal
        {
            Random rnd = new Random();
            x += rnd.Next(-10,10); //na razie przykładowe liczby (-10,10)
            y += rnd.Next(-10,10);
        }

    }
}