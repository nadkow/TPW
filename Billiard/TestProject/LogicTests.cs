using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Logic;

namespace TestProject
{
    [TestFixture]
    internal class LogicTests
    {
        sealed class MockDataApi : DataAbstractApi
        {
            private List<Orb> orbs = new List<Orb>();

            public override void Dispose()
            {
                throw new NotImplementedException();
            }

            public override List<Orb> getOrbs()
            {
                return orbs;
            }

            public override void Start(int tableWidth, int tableHeight, int numberOfOrbs)
            {
                for (int i = 0; i < numberOfOrbs; i++)
                {
                    Orb newOrb = new Orb(i, i);
                    orbs.Add(newOrb);
                }
            }
        }

        private static MockDataApi DataApi = new MockDataApi();
        private LogicAbstractApi LogicApi = LogicAbstractApi.CreateApi(DataApi);
        [Test]
        public void LogicStartTest()
        {
            LogicApi.Start(100, 100, 10);
            Assert.IsNotNull(LogicApi.GetOrbs());
            Assert.That(10, Is.EqualTo(LogicApi.GetOrbs().Count));
        }

    }
}
