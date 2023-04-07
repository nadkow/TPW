﻿using Logic;

namespace Model
{
    public class ModelApi : ModelAbstractApi
    {
        private LogicAbstractApi logicApi;

        public ModelApi()
        {
            this.logicApi = LogicAbstractApi.CreateApi();
        }

        public override void Start(int noOfOrbs)
        {
            this.logicApi.Start(500, 600, noOfOrbs); // nie wiem czy tutaj maja byc podane wymiary stolu
        }

        public override void Stop()
        {
            this.logicApi.Dispose();
        }
    }
}