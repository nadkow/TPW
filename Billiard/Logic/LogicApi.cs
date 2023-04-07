using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    internal class LogicApi : LogicAbstractApi
    {
        private DataAbstractApi dataAPI;

        public LogicApi()
        {
            this.dataAPI = DataAbstractApi.CreateApi();
        }

        public override void Start(int width, int height, int noOfOrbs)
        {
            this.dataAPI.Start(width, height, noOfOrbs); //TODO number of orbs bedzie podany przez uzytkownika
        }
    }
}
