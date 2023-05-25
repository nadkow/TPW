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
            double x, y, otherX, otherY;
            lock (orb.CoordsLock)
            {
                x = orb.Coords.x;
                y = orb.Coords.y;
            }
            foreach (var oneOfOrbs in logicOrbs)
            {
                if (oneOfOrbs != orb)
                {
                    lock (oneOfOrbs.CoordsLock)
                    {
                        otherX = oneOfOrbs.Coords.x;
                        otherY = oneOfOrbs.Coords.y;
                    }
                    double distance = Math.Sqrt(Math.Pow(x - otherX, 2) + Math.Pow(y - otherY, 2));
                    if (distance <= 10)
                    {
                        if ((orb.XSpeed - oneOfOrbs.XSpeed)*(otherX - x) + (orb.YSpeed - oneOfOrbs.YSpeed)*(otherY - y) >= 0)
                        {
                            double xs = orb.XSpeed;
                            double xy = orb.YSpeed;
                            orb.SetSpeed(oneOfOrbs.XSpeed, oneOfOrbs.YSpeed);
                            oneOfOrbs.SetSpeed(xs, xy);
                        }
                    }
                }
            }
        }

        private void CheckCollisionWithBorder(ILogicOrb orb)
        {
            if (orb.Y >= height - 5)
            {
                if (orb.YSpeed > 0)
                    orb.CollisionBorderY();
            }
            else if(orb.Y <= 5)
            {
                if (orb.YSpeed < 0)
                    orb.CollisionBorderY();
            }
            else if (orb.X >= width - 5)
            {
                if (orb.XSpeed > 0)
                    orb.CollisionBorderX();
            }
            else if (orb.X <= 5)
            {
                if (orb.XSpeed < 0)
                    orb.CollisionBorderX();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            // ta metoda na razie nie jest wywolywana ale zostawiamy do uzycia w przyszlosci
        }
    }
}
