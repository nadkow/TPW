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
        private DataAbstractApi dataApi;

        public LogicApi()
        {
            this.dataApi = DataAbstractApi.CreateApi();
        }

        public override void Start(int width, int height, int noOfOrbs)
        {
            this.dataApi.Start(width, height, noOfOrbs);
        }

        public override void Dispose()
        {
            this.dataApi.Dispose();
        }
    }
}
