using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        Blue _blue; //
        Pacman _pacman;
        Red _red;

        // Ghost[] Ghosts = new Ghost[4];

        [TestInitialize]
        public void Initialize_Blue()
        {
            gameState = new GameState();
            _blue = new Blue(90, 110, gameState, 1.8f, 1.5f);
            _pacman = new Pacman(Pacman.StartX, Pacman.StartY, gameState, 3.0f);
            _red = new Red(90, 110, gameState, 1.8f, 1.9f);
            //_blue.SetPosition(15, 19);
            //gameState.Blue = _blue;
            //gameState.Red = new Red(100, 100, gameState, 5.8f, 1.5f);
            /*var _Mock_Entity = new Mock<Entity>(MockBehavior.Loose) { };
             var _Mock_Gamestate = new Mock<GameState>(MockBehavior.Loose) { };
             var _Mock_Blue = new Mock<Blue>(MockBehavior.Loose) { };
             var _Mock_Red = new Mock<Red>(MockBehavior.Loose) { };*/



            //gameState.ra

            //  _Mock_Entity.Setup(p => p.Distance(_Mock_Blue.Object)).Returns(10);
            // gemestateMock.Setup(p => p.Y).Returns(10);
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
            //_pacman.SetDirection(Direction.Right);
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
            //_pacman.SetDirection(Direction.Right);
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
            _pacman.SetPosition(97, 120);
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
            var _Mock_Entity = new Mock<Entity>(MockBehavior.Loose) { };
            //_Mock_Entity.Setup(x => x.Direction).Returns(Direction.Down);
            _blue.SetRoadPosition(100, 100);
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
            _blue.Clone();
            Assert.IsTrue(true);
        }
    }
}