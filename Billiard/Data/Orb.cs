using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Orb : IOrb, INotifyPropertyChanged
    {
        private double x;
        private double y;
        private int d = 10; 
        private Timer ChangePositionTimer;
        private Random rnd = new Random();

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public int D { get => d; set => d = value; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public Orb(double x, double y)
        {
            this.x = x;
            this.y = y;
            ChangePositionTimer = new Timer(ChangePosition, null, 0, 100);
        }

        public void ChangePosition(object? state) //zeby mozna bylo uzyc changePosition w Timerze musi mieć argument object
        {   
            x += rnd.NextDouble()*10-5;
            y += rnd.NextDouble()*10-5;
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