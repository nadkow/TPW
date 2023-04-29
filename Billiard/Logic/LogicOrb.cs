using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class LogicOrb : ILogicOrb
    {
        IOrb orb;
        private double x;
        private double y;
        private int diameter;
        public event PropertyChangedEventHandler? PropertyChanged;
        public double X { get => x;}
        public double Y { get => y;}
        public int D { get => diameter;}
        public LogicOrb(IOrb orb)
        {
            this.orb = orb;
            x = orb.X;
            y = orb.Y;
            diameter = orb.D;
            orb.PropertyChanged += Update;
        }
       
        private void Update(object sender, PropertyChangedEventArgs e)
        {
            IOrb orb = (IOrb)sender;
            x = orb.X;
            y = orb.Y;
            OnPropertyChanged();
        }

        public void Dispose()
        {
            orb.DisposeTimer();
        }
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
