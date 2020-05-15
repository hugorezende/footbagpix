using FootbagPix.Logic;
using FootbagPix.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootbagPix.Test
{
    [TestFixture]
    class CharacterLogicTests
    {
        Mock<IBallModel> mockedBall;
        Mock<ICharacterModel> mockedCharacter;
        Mock<ITimerModel> mockedTimer;
        Mock<IScoreModel> mockedScore;

        [Test]
        public async Task TestMoveLeftAsync()
        {
            mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            mockedTimer.Setup(mock => mock.GameOver).Returns(false);
            mockedCharacter.Setup(mock => mock.Blocked).Returns(false);
            mockedCharacter.SetupProperty(mock => mock.PositionX, 10);
            CharacterLogic characterLogic = new CharacterLogic(
                mockedBall.Object,
                mockedCharacter.Object,
                mockedScore.Object,
                mockedTimer.Object);

            characterLogic.MoveLeft();
            mockedCharacter.VerifySet(mock => mock.LeftFoot);
            mockedCharacter.VerifySet(mock => mock.RigthFoot);
            await Task.Delay(1000);
            Assert.That(mockedCharacter.Object.PositionX, Is.EqualTo(5));


        }

        [Test]
        public void TestMoveLeftBlocked()
        {
            mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            mockedTimer.Setup(mock => mock.GameOver).Returns(false);
            mockedCharacter.Setup(mock => mock.Blocked).Returns(true);
            mockedCharacter.SetupProperty(mock => mock.PositionX, 10);

            CharacterLogic characterLogic = new CharacterLogic(
                mockedBall.Object,
                mockedCharacter.Object,
                mockedScore.Object,
                mockedTimer.Object);

            characterLogic.MoveLeft();
            mockedCharacter.VerifySet(mock => mock.LeftFoot = It.IsAny<Rect>(), Times.Never());
            mockedCharacter.VerifySet(mock => mock.RigthFoot = It.IsAny<Rect>(), Times.Never());
            Assert.That(mockedCharacter.Object.PositionX, Is.EqualTo(10));

        }

        [Test]
        public void TestMoveLeftGameOver()
        {
            mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            mockedTimer.Setup(mock => mock.GameOver).Returns(true);
            mockedCharacter.Setup(mock => mock.Blocked).Returns(false);
            mockedCharacter.SetupProperty(mock => mock.PositionX, 10);

            CharacterLogic characterLogic = new CharacterLogic(
                mockedBall.Object,
                mockedCharacter.Object,
                mockedScore.Object,
                mockedTimer.Object);

            characterLogic.MoveLeft();
            mockedCharacter.VerifySet(mock => mock.LeftFoot = It.IsAny<Rect>(), Times.Never());
            mockedCharacter.VerifySet(mock => mock.RigthFoot = It.IsAny<Rect>(), Times.Never());
            Assert.That(mockedCharacter.Object.PositionX, Is.EqualTo(10));

        }

        [Test]
        public async Task TestMoveRightAsync()
        {
            mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            mockedTimer.Setup(mock => mock.GameOver).Returns(false);
            mockedCharacter.Setup(mock => mock.Blocked).Returns(false);
            mockedCharacter.SetupProperty(mock => mock.PositionX, 10);

            CharacterLogic characterLogic = new CharacterLogic(
                mockedBall.Object,
                mockedCharacter.Object,
                mockedScore.Object,
                mockedTimer.Object);

            characterLogic.MoveRight();
            mockedCharacter.VerifySet(mock => mock.LeftFoot);
            mockedCharacter.VerifySet(mock => mock.RigthFoot);
            await Task.Delay(1000);
            Assert.That(mockedCharacter.Object.PositionX, Is.EqualTo(15));
        }

        [Test]
        public void TestTryHitBall()
        {
            mockedBall = new Mock<IBallModel>(MockBehavior.Default);
            mockedCharacter = new Mock<ICharacterModel>(MockBehavior.Default);
            mockedTimer = new Mock<ITimerModel>(MockBehavior.Default);
            mockedScore = new Mock<IScoreModel>(MockBehavior.Default);

            mockedBall.Setup(mock => mock.Area.IntersectsWith(It.IsAny<Rect>())).Returns(true);

            CharacterLogic characterLogic = new CharacterLogic(
                mockedBall.Object,
                mockedCharacter.Object,
                mockedScore.Object,
                mockedTimer.Object);

            Assert.That(true, Is.EqualTo(characterLogic.TryHitBall()));
            mockedBall.VerifySet(mock => mock.Area);

        }
    }
}
