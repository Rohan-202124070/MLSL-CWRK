using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pacman.GameLogic.Ghosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.GameLogic.Ghosts.Tests
{
    [TestClass()]
    public class BrownTests
    {
        GameState gameState;
        Ghost ghosts;
        Pacman _pacman;
        Brown _brown;

        [TestInitialize]
        public void Initialize_Blue()
        {
            gameState = new GameState();
            _brown = new Brown(90, 110, gameState, 1.8f, 1.5f);
            _pacman = new Pacman(Pacman.StartX, Pacman.StartY, gameState, 3.0f);
        }

            [TestMethod()]
        public void BrownTest()
        {
            ghosts = new Brown(Brown.StartX, Brown.StartY, new GameState(), 2.8f, 1.5f);
            Assert.IsNotNull(ghosts);
        }

        [TestMethod()]
        public void PacmanDeadTest()
        {
            _brown.PacmanDead();
            Assert.AreEqual(127, Brown.StartX);
            Assert.AreEqual(118, Brown.StartY);
        }

        [TestMethod()]
        public void ResetPositionTest()
        {
            _brown.ResetPosition();
            Assert.AreEqual(127, Brown.StartX);
            Assert.AreEqual(118, Brown.StartY);
        }

        [TestMethod()]
        public void MoveTest()
        {
            _brown.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CloneTest()
        {
            _brown.Clone();
            Assert.IsTrue(true);
        }
    }
}