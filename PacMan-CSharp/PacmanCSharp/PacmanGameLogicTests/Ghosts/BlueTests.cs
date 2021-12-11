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
            _blue.Clone();
            Blue parent = (Blue)((ICloneable)_blue).Clone();
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
        public void Move_IfElseCase_Test() // statement, edge, condition coverage
        {
            _red.SetPosition(12, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
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
    }
}