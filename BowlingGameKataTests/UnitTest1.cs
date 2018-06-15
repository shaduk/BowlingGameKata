using System;
using BowlingGameKata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingGameKataTests
{
    [TestClass]
    public class UnitTest1
    {
        Game g;

        [TestInitialize]
        public void Setup()
        {
            g = new Game();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

        [TestMethod]
        public void testGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }


        [TestMethod]
        public void testAllOnes()
        {

            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void testOneSpare()
        {
            RollSpare();
            g.Roll(3);
            RollMany(17, 0);
            Assert.AreEqual(16, g.Score());
        }

        

        [TestMethod]
        public void testOneStrike()
        {
            RollStrike();
            g.Roll(3);
            g.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, g.Score());
        }

        private void RollStrike()
        {
            g.Roll(10);
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);   // spare
        }

        [TestMethod]
        public void testPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, g.Score());
        }
    }
}
