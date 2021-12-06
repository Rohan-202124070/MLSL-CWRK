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
        GameState _gameState;
        Ghost _ghosts;
        Blue _blue;
        Pacman _pacman;
        Red _red;

        private MockRepository mockRepository;
        private Mock<GameState> mockGameState;
        private Mock<Red> mockRed;
        private Mock<Entity> mockEntity;

        [TestInitialize]
        public void Initialize_Blue() // initialization and statement coverage
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockGameState = mockRepository.Create<GameState>(100);
            this.mockEntity = mockRepository.Create<Entity>();
            this.mockRed = mockRepository.Create<Red>(10, 10, this.mockGameState.Object, 1.8f, 1.9f);
            _gameState = new GameState();
            _blue = new Blue(90, 110, _gameState, 1.8f, 1.5f);
            _pacman = new Pacman(Pacman.StartX, Pacman.StartY, _gameState, 3.0f);
            _red = new Red(90, 110, _gameState, 1.8f, 1.9f);
        }

        [TestMethod()]
        public void BlueTest() // statement coverage
        {
            _ghosts = new Blue(Blue.StartX, Blue.StartY, new GameState(), 2.8f, 1.5f);
            Assert.IsNotNull(_ghosts);
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void PacmanDeadTest() // statement coverage
        {
            _blue.PacmanDead();
            Assert.AreEqual(95, Blue.StartX);
            Assert.AreEqual(118, Blue.StartY);
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void ResetPositionTest() // statement coverage
        {
            _blue.ResetPosition();
            Assert.AreEqual(95, Blue.StartX);
            Assert.AreEqual(118, Blue.StartY);
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_FirstIfCase_Test() // statement, edge, condition coverage 
        {
            _pacman.SetPosition(10, 10);
            _gameState.Pacman = _pacman;
            for (int i =0; i<100; i++)
                _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_SecondIfCase_Test() // statement, edge, condition coverage //Distance(GameState.Red) < 50.0f
        {
            _red.SetPosition(90, 110);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_ElseCase_Test() // statement, edge, condition coverage // Distance(GameState.Red) < 50.0f Else part
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_IfElseCase_Test() // statement, edge, condition coverage
        {
            _red.SetPosition(12, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_PackManUp_Test()// statement, edge, condition coverage  //true => if( IsAbove(GameState.Pacman))
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _pacman.SetDirection(Direction.Up);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_PackManRight_Test() // statement, edge, condition coverage // true => (x <= entity.x) for right => IsRight(GameState.Pacman)
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(190, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_PackManRight_False_Test() // statement, edge, condition coverage // false =>(x <= entity.x) for right => IsRight(GameState.Pacman)
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(94, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_PackManDown_Test() // statement, edge, condition coverage // Down //(Y <= entity.Y) IsAbove(GameState.Pacman) => false
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 120);
            _pacman.SetDirection(Direction.Up);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]                        // statement, edge, condition coverage 
        public void Move_MinimizeX_True_Test() // true => IsBelow(GameState.Pacman) // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(97, 140);
            _pacman.SetDirection(Direction.Up);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]                                  // statement, edge, condition coverage  // true => IsBelow(GameState.Pacman) // true => IsLeft(GameState.Pacman)
        public void Move_MinimizeXSecondCase_True_Test() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(95, 120);
            _pacman.SetDirection(Direction.Up);
            _gameState.Pacman = _pacman;
            for (int i = 0; i < 100; i++)
                _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]                                 // statement, edge, condition coverage  // true => IsBelow(GameState.Pacman) // true => IsLeft(GameState.Pacman)
        public void Move_MinimizeXSecond_ORCase_True_Test() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(12, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(95, 120);
            _pacman.SetDirection(Direction.Up);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]                        // statement, edge, condition coverage  // false => IsBelow(GameState.Pacman)
        public void Move_MinimizeX_False_Test() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(97, 110);
            _pacman.SetDirection(Direction.Up);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]                                  // statement, edge, condition coverage // true => IsBelow(GameState.Pacman) // true => IsLeft(GameState.Pacman)
        public void Move_JustFindSomething_FirstElseIf_Test() // false //Math.Abs(Node.X - GameState.Pacman.Node.X) != 0
        {
            _gameState.Blue = _blue;
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(95, 120);
            _pacman.SetDirection(Direction.Right);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_Path_Coverage_1_Test() // path coverage
        {
            _red.SetPosition(90, 110);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_Path_Coverage_2_Test() // path coverage
        {
            _red.SetPosition(150, 100);
            _gameState.Red = _red;
            _pacman.SetPosition(190, 110);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_Path_Coverage_3_Test() // path coverage
        {
            _red.SetPosition(150, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(190, 10);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Move_Path_Coverage_4_Test() // path coverage
        {
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 10);
            _gameState.Pacman = _pacman;
            _blue.Move();
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void CloneTest() // statement coverage 
        {
            Blue expected = new Blue(90, 110, _gameState, 1.8f, 1.5f);
            expected.Clone();
            Blue parent = (Blue)((ICloneable)expected).Clone();
            Assert.AreEqual(expected.ImgX, _blue.ImgX);
            Assert.AreEqual(expected.ImgX, parent.ImgX);
        }
    }
}