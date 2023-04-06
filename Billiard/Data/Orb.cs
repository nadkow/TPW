using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb
    {
        private int x;
        private int y;
        private Timer ChangePositionTimer;
        private Random rnd = new Random();
        public event PropertyChangedEventHandler PropertyChanged;

        public Orb(int x, int y)
        {
            this.x = x;
            this.y = y;
            ChangePositionTimer = new Timer(ChangePosition, null, 0, 100);
        }

        private void ChangePosition(object? state) //zeby mozna bylo uzyc changePosition w Timerze musi mieć argument object
        {   
            x += rnd.Next(10); //na razie przykładowe liczby (0,10)
            y += rnd.Next(10);
            Console.WriteLine("dziala");
            Console.WriteLine(x);
            Console.WriteLine(y);

        }


        public void DisposeTimer()
        {
            ChangePositionTimer.Dispose();
        }

    }
}