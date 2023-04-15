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
        private readonly List<Orb> orbs = new List<Orb>();
        private readonly List<ILogicOrb> logicOrbs = new List<ILogicOrb>();


        public override event PropertyChangedEventHandler? PropertyChanged;

        public LogicApi(DataAbstractApi api = null)
        {
            if (api != null) { dataApi = api; }
            else { dataApi = DataAbstractApi.CreateApi(); }
        }

        public override List<Orb> GetOrbs()
        {
            return orbs;
        }
        public override List<ILogicOrb> GetLogicOrbs()
        {
            return logicOrbs;
        }

        public override void Start(int width, int height, int noOfOrbs)
        {
            this.width = width;
            this.height = height;
            for (int i = 0; i < noOfOrbs; i++)
            {
                Orb newOrb = dataApi.CreateOrb(width, height);
                orbs.Add(newOrb);
                ILogicOrb newLogicOrb = new LogicOrb(newOrb);
                logicOrbs.Add(newLogicOrb);

            }
            foreach (Orb orb in orbs)
            {
                orb.PropertyChanged += OrbPosChanged;
            }
            // laczymy event dopiero w metodzie Start, a nie w konstruktorze, bo wtedy orby jeszcze nie istnieja
        }

        public override void Dispose()
        {
            foreach (Orb orb in orbs)
            {
                dataApi.Dispose(orb);
            }

        }

        private void OrbPosChanged(object sender, PropertyChangedEventArgs e)
        {
                // stol pilnuje czy kule znajduja sie wewnatrz niego
                Orb orb = (Orb)sender;
                if (orb.X > width || orb.Y > height || orb.X < 0 || orb.Y < 0)
                {
                    orb.DisposeTimer();
                }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
