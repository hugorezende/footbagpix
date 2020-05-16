// <copyright file="CharacterLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Test
{
    using System.Threading.Tasks;
    using System.Windows;
    using FootbagPix.Logic;
    using FootbagPix.Models;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    internal class CharacterLogicTests
    {
        private Mock<IBallModel> mockedBall;
        private Mock<ICharacterModel> mockedCharacter;
        private Mock<ITimerModel> mockedTimer;
        private Mock<IScoreModel> mockedScore;

        /// <summary>
        /// Unit test for Move Left method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Test]
        public async Task TestMoveLeftAsync()
        {
            this.mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            this.mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            this.mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            this.mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            this.mockedTimer.Setup(mock => mock.GameOver).Returns(false);
            this.mockedCharacter.Setup(mock => mock.Blocked).Returns(false);
            this.mockedCharacter.SetupProperty(mock => mock.PositionX, 10);
            CharacterLogic characterLogic = new CharacterLogic(
                this.mockedBall.Object,
                this.mockedCharacter.Object,
                this.mockedScore.Object,
                this.mockedTimer.Object);

            characterLogic.MoveLeft();
            this.mockedCharacter.VerifySet(mock => mock.LeftFoot);
            this.mockedCharacter.VerifySet(mock => mock.RigthFoot);
            await Task.Delay(1000);
            Assert.That(this.mockedCharacter.Object.PositionX, Is.EqualTo(5));
        }

        /// <summary>
        /// Unit test for check MoveLeft() when character is blocked.
        /// </summary>
        [Test]
        public void TestMoveLeftBlocked()
        {
            this.mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            this.mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            this.mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            this.mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            this.mockedTimer.Setup(mock => mock.GameOver).Returns(false);
            this.mockedCharacter.Setup(mock => mock.Blocked).Returns(true);
            this.mockedCharacter.SetupProperty(mock => mock.PositionX, 10);

            CharacterLogic characterLogic = new CharacterLogic(
                this.mockedBall.Object,
                this.mockedCharacter.Object,
                this.mockedScore.Object,
                this.mockedTimer.Object);

            characterLogic.MoveLeft();
            this.mockedCharacter.VerifySet(mock => mock.LeftFoot = It.IsAny<Rect>(), Times.Never());
            this.mockedCharacter.VerifySet(mock => mock.RigthFoot = It.IsAny<Rect>(), Times.Never());
            Assert.That(this.mockedCharacter.Object.PositionX, Is.EqualTo(10));
        }

        /// <summary>
        /// Unit test for check MoveLeft() when game is over.
        /// </summary>
        [Test]
        public void TestMoveLeftGameOver()
        {
            this.mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            this.mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            this.mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            this.mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            this.mockedTimer.Setup(mock => mock.GameOver).Returns(true);
            this.mockedCharacter.Setup(mock => mock.Blocked).Returns(false);
            this.mockedCharacter.SetupProperty(mock => mock.PositionX, 10);

            CharacterLogic characterLogic = new CharacterLogic(
                this.mockedBall.Object,
                this.mockedCharacter.Object,
                this.mockedScore.Object,
                this.mockedTimer.Object);

            characterLogic.MoveLeft();
            this.mockedCharacter.VerifySet(mock => mock.LeftFoot = It.IsAny<Rect>(), Times.Never());
            this.mockedCharacter.VerifySet(mock => mock.RigthFoot = It.IsAny<Rect>(), Times.Never());
            Assert.That(this.mockedCharacter.Object.PositionX, Is.EqualTo(10));
        }


        /// <summary>
        /// Unit test for Move Right character.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Test]
        public async Task TestMoveRightAsync()
        {
            this.mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            this.mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            this.mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            this.mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            this.mockedTimer.Setup(mock => mock.GameOver).Returns(false);
            this.mockedCharacter.Setup(mock => mock.Blocked).Returns(false);
            this.mockedCharacter.SetupProperty(mock => mock.PositionX, 10);

            CharacterLogic characterLogic = new CharacterLogic(
                this.mockedBall.Object,
                this.mockedCharacter.Object,
                this.mockedScore.Object,
                this.mockedTimer.Object);

            characterLogic.MoveRight();
            this.mockedCharacter.VerifySet(mock => mock.LeftFoot);
            this.mockedCharacter.VerifySet(mock => mock.RigthFoot);
            await Task.Delay(1000);
            Assert.That(this.mockedCharacter.Object.PositionX, Is.EqualTo(15));
        }

        /// <summary>
        /// Unit Test for try hit the ball.
        /// </summary>
        [Test]
        public void TestTryHitBall()
        {
            this.mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            this.mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            this.mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            this.mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            this.mockedBall.Setup(mock => mock.Area.IntersectsWith(It.IsAny<Rect>())).Returns(true);

            CharacterLogic characterLogic = new CharacterLogic(
                this.mockedBall.Object,
                this.mockedCharacter.Object,
                this.mockedScore.Object,
                this.mockedTimer.Object);

            Assert.That(true, Is.EqualTo(characterLogic.TryHitBall()));
            this.mockedBall.VerifySet(mock => mock.Area);
        }
    }
}
