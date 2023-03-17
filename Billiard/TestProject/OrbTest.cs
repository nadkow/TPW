using BilliardLibrary;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
 
        static int r = 12;
        Orb orbee = new Orb(r);
        Orb orbee2 = new Orb(r);


        [Test]
        public void Test1()
        {
            Assert.That(r, Is.EqualTo(orbee.Radius));
            Assert.That(orbee2, Is.EqualTo(orbee));
        }
    }
}