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
    public class BlueTests
    {
        GameState gameState;
        Ghost ghosts;
        Blue _blue;
        Pacman _pacman;
        Red _red;

        [TestInitialize]
        public void Initialize_Blue()
        {
            gameState = new GameState();
            _blue = new Blue(90, 110, gameState, 1.8f, 1.5f);
            _pacman = new Pacman(Pacman.StartX, Pacman.StartY, gameState, 3.0f);
            _red = new Red(90, 110, gameState, 1.8f, 1.9f);
        }

        [TestMethod()]
        public void BlueTest()
        {
            ghosts = new Blue(Blue.StartX, Blue.StartY, new GameState(), 2.8f, 1.5f);
            Assert.IsNotNull(ghosts);
        }

        [TestMethod()]
        public void PacmanDeadTest()
        {
            _blue.PacmanDead();
            Assert.AreEqual(95, Blue.StartX);
            Assert.AreEqual(118, Blue.StartY);
        }

        [TestMethod()]
        public void ResetPositionTest()
        {
            _blue.ResetPosition();
            Assert.AreEqual(95, Blue.StartX);
            Assert.AreEqual(118, Blue.StartY);
        }

        [TestMethod()]
        public void MoveFirstIfCaseTest()
        {
            _pacman.SetPosition(10, 10);
            gameState.Pacman = _pacman;
            for (int i =0; i<100; i++)
                _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MoveSecondIfCaseTest() //Distance(GameState.Red) < 50.0f
        {
            _red.SetPosition(90, 110);
            gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MoveElseCaseTest() // Distance(GameState.Red) < 50.0f Else part
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MoveIfElseCaseTest() 
        {
            _red.SetPosition(12, 10);
            gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MovePackManUpTest() // if( IsAbove(GameState.Pacman) )
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _pacman.SetDirection(Direction.Up);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MovePackManRightTest() // true => (x <= entity.x) for right => IsRight(GameState.Pacman)
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(190, 110);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MovePackManRightFalseTest() // false =>(x <= entity.x) for right => IsRight(GameState.Pacman)
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(94, 110);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void MovePackManDownTest() // Down //(Y <= entity.Y) IsAbove(GameState.Pacman) => false
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(90, 120);
            _pacman.SetDirection(Direction.Up);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]                        // true => IsBelow(GameState.Pacman)
        public void MoveMinimizeXTrueTest() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(97, 140);
            _pacman.SetDirection(Direction.Up);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]                                  // true => IsBelow(GameState.Pacman) // true => IsLeft(GameState.Pacman)
        public void MoveMinimizeXSecondCaseTrueTest() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(95, 120);
            _pacman.SetDirection(Direction.Up);
            gameState.Pacman = _pacman;
            for (int i = 0; i < 100; i++)
                _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]                                  // true => IsBelow(GameState.Pacman) // true => IsLeft(GameState.Pacman)
        public void MoveMinimizeXSecondORCaseTrueTest() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(12, 10);
            gameState.Red = _red;
            _pacman.SetPosition(95, 120);
            _pacman.SetDirection(Direction.Up);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]                        // false => IsBelow(GameState.Pacman)
        public void MoveMinimizeXFalseTest() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(97, 110);
            _pacman.SetDirection(Direction.Up);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]                                  // true => IsBelow(GameState.Pacman) // true => IsLeft(GameState.Pacman)
        public void MoveJustFindSomethingFirstElseIfTest() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            gameState.Blue = _blue;
            _red.SetPosition(10, 10);
            gameState.Red = _red;
            _pacman.SetPosition(95, 120);
            _pacman.SetDirection(Direction.Right);
            gameState.Pacman = _pacman;
            _blue.Move();
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CloneTest()
        {
            Blue expected = new Blue(90, 110, gameState, 1.8f, 1.5f);
            expected.Clone();
            Blue parent = (Blue)((ICloneable)expected).Clone();
            Assert.AreEqual(expected.ImgX, _blue.ImgX);
            Assert.AreEqual(expected.ImgX, parent.ImgX);
        }
    }
}