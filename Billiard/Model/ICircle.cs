using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace Model
{
    public interface ICircle : INotifyPropertyChanged
    {
        public double X { get; }
        public double Y { get; }
        public int D { get; }
    }
}
