using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Circle
    {
        // wizualna reprezentacja Orb
        private int x;
        private int y;
        private int diameter;

        public Circle(Orb orb)
        {
            x = orb.X;
            y = orb.Y;
            diameter = orb.D;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Diameter { get => diameter; set => diameter = value; }
    }
}
