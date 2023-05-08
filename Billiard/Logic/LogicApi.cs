using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Data;

namespace Logic
{
    internal class LogicApi : LogicAbstractApi
    {
        Semaphore semaphoreOrb = new Semaphore(1, 1);
        Semaphore semaphoreBorder = new Semaphore(1, 1);
        private DataAbstractApi dataApi;
        private int width;
        private int height;
        private readonly List<ILogicOrb> logicOrbs = new List<ILogicOrb>();

        public override event PropertyChangedEventHandler? PropertyChanged;

        public LogicApi(DataAbstractApi api = null)
        {
            if (api != null) { dataApi = api; }
            else { dataApi = DataAbstractApi.CreateApi(); }
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
                IOrb newOrb = dataApi.CreateOrb(width, height);
                ILogicOrb newLogicOrb = new LogicOrb(newOrb);
                logicOrbs.Add(newLogicOrb);

            }
            foreach (ILogicOrb orb in logicOrbs)
            {
                orb.PropertyChanged += OrbPosChanged;
            }
            // laczymy event dopiero w metodzie Start, a nie w konstruktorze, bo wtedy orby jeszcze nie istnieja
        }

        public override void Dispose()
        {
            foreach (ILogicOrb orb in logicOrbs)
            {
                orb.Dispose();
            }
            logicOrbs.Clear();

        }

        private void OrbPosChanged(object sender, PropertyChangedEventArgs e)
        {
            ILogicOrb orb = (ILogicOrb)sender;
            semaphoreOrb.WaitOne();
            CheckCollisionWithOrbs(orb);
            semaphoreOrb.Release(1);
            semaphoreBorder.WaitOne();
            CheckCollisionWithBorder(orb);
            semaphoreBorder.Release(1);
        }

        private void CheckCollisionWithOrbs(ILogicOrb orb)
        {
            foreach(var oneOfOrbs in logicOrbs) {
                if (oneOfOrbs != orb)
                {
                    double distance = Math.Sqrt(Math.Pow(orb.X - oneOfOrbs.X, 2) + Math.Pow(orb.Y - oneOfOrbs.Y, 2));
                    if (distance <= 10)
                    {
                        orb.Collision(oneOfOrbs);
                    }
                }
            }
        }

        private void CheckCollisionWithBorder(ILogicOrb orb)
        {
            if (orb.Y > height-5 || orb.Y < 5)
            {
                orb.CollisionBorder("y");
            }
            else if(orb.X > width-5 || orb.X < 5)
            {
                orb.CollisionBorder("x");
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            // ta metoda na razie nie jest wywolywana ale zostawiamy do uzycia w przyszlosci
        }
    }
}
