using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class LogicApi : LogicAbstractApi
    {
        private DataAbstractApi dataApi;

        public LogicApi()
        {
            this.dataApi = DataAbstractApi.CreateApi();
        }

        public override void Start(int width, int height, int noOfOrbs)
        {
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

        private void OrbPosChanged(object source, PropertyChangedEventArgs e)
        {
            Console.WriteLine("event raised");
            if (e.PropertyName == "Position")
            {
                Console.WriteLine("pos changed");
                // stol pilnuje czy kule znajduja sie wewnatrz niego
                // TODO tutaj kod zawracajacy lub usuwajacy kule jesli zderza sie ze scianka stolu
                // TODO jesli kula nie wyszla poza stol to wyslij event z logic do model informujacy o pozycji kuli
            }
        }
    }
}
