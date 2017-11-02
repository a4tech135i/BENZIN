using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BENZIN_1._0;
namespace UnitTestProject1
{
    [TestClass]
    public class BENZIN_Tests
    {
        Wheels wh = null;
        Corpus cor = null;
        Car car_Test = null;
        [TestInitialize]
        public void TestInit()
        {
            wh = new Wheels("deloren", 100, 1, 4, 100, 85);
            cor= new Corpus("deloren", 100, 1, 6, 5, 5);
            car_Test = new Car(wh, cor, 177, 100, 100);
        }
        [TestMethod]
        public void TestDMG24Wheels()
        {

            Wheels cc = car_Test.getWheels();
            int dmg_tr = Math.Abs(24 - 4 * 10);
            int dmg = cc.damage(24);
            Console.WriteLine(dmg);
            Assert.AreEqual(  dmg_tr , dmg);
        }
        [TestMethod]
        public void TestDMG50Corpus()
        {

            Corpus cc = car_Test.getCorpus();
            int dmg_tr = Math.Abs(50 - 6 * 10);
            int dmg = cc.damage(50);
            Console.WriteLine(dmg);
            Assert.AreEqual(dmg_tr, dmg);
        }
        [TestMethod]
        public void TestDMGWheels()
        {
            Wheels cc = car_Test.getWheels();
            int dmg_tr = 10 - 4;
            int dmg = cc.damage();
            Console.WriteLine(dmg);
            Assert.AreEqual(dmg_tr, dmg);
        }
        [TestMethod]
        public void TestDMGCorpus()
        {
            Corpus cc = car_Test.getCorpus();
            int dmg_tr = 10 - 6;
            int dmg = cc.damage();
            Console.WriteLine(dmg);
            Assert.AreEqual(dmg_tr, dmg);
        }
        [TestMethod]
        public void TestRepairCorpus()
        {
            Corpus cc = car_Test.getCorpus();
            cc.damage();
            int rep = cc.getHP()+cc.damage();
            cc.repair();
            Assert.AreEqual(rep, cc.getHP());
        }
        [TestMethod]
        public void TestRepairWheels()
        {
            Wheels cc = car_Test.getWheels();
            cc.damage();
            int rep = cc.getHP() + cc.damage();
            cc.repair();
            Assert.AreEqual(rep, cc.getHP());
        }
    }
}
