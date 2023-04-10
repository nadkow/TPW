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
        private LogicAbstractApi LogicApi = LogicAbstractApi.CreateApi();
        [Test]
        public void LogicStartTest()
        {
            LogicApi.Start(100, 100, 10);
            Assert.IsNotNull(LogicApi.GetOrbs());
        }

    }
}
