using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb : INotifyPropertyChanged
    {
        private int x;
        private int y;
        private int d = 10; //TODO wartosc do zmiany po ustaleniu wielkosci stolu
        private Timer ChangePositionTimer;
        private Random rnd = new Random();

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int D { get => d; set => d = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Orb(int x, int y)
        {
            this.x = x;
            this.y = y;
            ChangePositionTimer = new Timer(ChangePosition, null, 0, 100);
        }

        private void ChangePosition(object? state) //zeby mozna bylo uzyc changePosition w Timerze musi mieć argument object
        {   
            x += rnd.Next(-10,10); //TODO wartosci do zmiany po ustaleniu wielkosci stolu
            y += rnd.Next(-10,10);
            OnPropertyChanged("Position");
        }

        public void DisposeTimer()
        {
            ChangePositionTimer.Dispose();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}