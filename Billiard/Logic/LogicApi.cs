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
    internal class LogicApi : LogicAbstractApi
    {
        private DataAbstractApi dataApi;
        private int width;
        private int height;

        public override event PropertyChangedEventHandler? PropertyChanged;

        public LogicApi()
        {
            this.dataApi = DataAbstractApi.CreateApi();
        }

        public override List<Orb> GetOrbs()
        {
            return dataApi.getOrbs();
        }

        public override void Start(int width, int height, int noOfOrbs)
        {
            this.width = width;
            this.height = height;
            this.dataApi.Start(width, height, noOfOrbs);
            foreach (Orb orb in this.dataApi.getOrbs())
            {
                orb.PropertyChanged += OrbPosChanged;
            }
            // laczymy event dopiero w metodzie Start, a nie w konstruktorze, bo wtedy orby jeszcze nie istnieja
        }

        public override void Dispose()
        {
            this.dataApi.Dispose();
        }

        private void OrbPosChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Position")
            {
                // stol pilnuje czy kule znajduja sie wewnatrz niego
                Orb orb = (Orb)sender;
                if (orb.X > width || orb.Y > height || orb.X < 0 || orb.Y < 0)
                {
                    orb.DisposeTimer();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
