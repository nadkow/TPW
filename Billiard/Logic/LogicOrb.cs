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
    internal class LogicOrb : ILogicOrb, INotifyPropertyChanged
    {
        private IOrb orb;
        public event PropertyChangedEventHandler? PropertyChanged;
        public double X { get => orb.X; set => orb.X = value; }
        public double Y { get => orb.Y; set => orb.Y = value; }
        public int D { get => orb.D; set => orb.D = value; }
        public LogicOrb(IOrb orb)
        {
            this.orb = orb;
            orb.PropertyChanged += Update;
        }
       
        public void Update(object sender, PropertyChangedEventArgs e)
        {
            //OnPropertyChanged();
        }
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
