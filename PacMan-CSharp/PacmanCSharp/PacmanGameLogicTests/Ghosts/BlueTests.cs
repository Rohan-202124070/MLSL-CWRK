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
        private MockRepository mockRepository;

        private Mock<GameState> mockGameState;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockGameState = mockRepository.Create<GameState>(100);

        }

        private Blue CreateBlue()
        {
            return new Blue(
                10,
                10,
                this.mockGameState.Object,
                1.8f,
                1.9f);
        }

        private Red CreateRed()
        {
            return new Red(
                10,
                10,
                this.mockGameState.Object,
                1.8f,
                1.9f);
        }

        private Pacman CreatePacman()
        {
            return new Pacman(
                10,
                10,
                this.mockGameState.Object,
                1.8f);
        }

        private GameState CreateGameState()
        {
            return new GameState(100);
        }

        [TestMethod()]
        public void PacmanDeadTest()
        {
            // Arrange
            var _blue = CreateBlue();

            //Act
            _blue.PacmanDead();
            _blue.Clone();
            _blue = (Blue)((ICloneable)_blue).Clone();

            // Assert
            Assert.AreEqual(_blue.X, Blue.StartX);
            Assert.AreEqual(_blue.Y, Blue.StartY);
            this.mockRepository.VerifyAll();

        }

        [TestMethod()]
        public void First_Move_Test()
        {
            // Arrange
            var _red = CreateRed();
            var _gameState = CreateGameState();
            var _pacman = CreatePacman();
            _red.SetPosition(90, 110);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _gameState.Pacman = _pacman;

            //Act
            _gameState.Blue.Move();

            //Assert
            this.mockGameState.VerifyAll();
        }

        [TestMethod()]
        public void Second_Move_Test()
        {
            // Arrange
            var _red = CreateRed();
            var _gameState = CreateGameState();
            var _pacman = CreatePacman();
            _red.SetPosition(12, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(90, 110);
            _gameState.Pacman = _pacman;

            //Act
            _gameState.Blue.Move();

            //Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Third_Move_Test()
        {
            // Arrange
            var _red = CreateRed();
            var _gameState = CreateGameState();
            var _pacman = CreatePacman();
            _red.SetPosition(10, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(97, 140);
            _gameState.Pacman = _pacman;

            //Act
            _gameState.Blue.Move();

            //Assert
            this.mockRepository.VerifyAll();
        }

        [TestMethod()]
        public void Fourth_Move_Test()
        {
            // Arrange
            var _red = CreateRed();
            var _gameState = CreateGameState();
            var _pacman = CreatePacman();
            _red.SetPosition(12, 10);
            _gameState.Red = _red;
            _pacman.SetPosition(95, 120); ;
            _gameState.Pacman = _pacman;

            //Act
            _gameState.Blue.Move();

            //Assert
            this.mockRepository.VerifyAll();
        }
    }
}