using FootbagPix.Logic;
using FootbagPix.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Test
{
    [TestFixture]
    class TestScoreLogic
    {
        Mock<IScoreModel> mockScore;
        Mock<IBallModel> mockBall;

        [Test]
        public void TestIncrease()
        {
            mockScore = new Mock<IScoreModel>(MockBehavior.Default);
            mockBall = new Mock<IBallModel>(MockBehavior.Default);

            mockScore.SetupProperty(mock => mock.CurrentScore, 0);
            mockScore.SetupProperty(mock => mock.ComboCounter, 1);

            ScoreLogic scoreLogic = new ScoreLogic(mockScore.Object, mockBall.Object);

            scoreLogic.Increase(ScoreType.FootHit);
            Assert.That(mockScore.Object.CurrentScore, Is.EqualTo(10));
            scoreLogic.Increase(ScoreType.FootHit);
            Assert.That(mockScore.Object.CurrentScore, Is.EqualTo(30));
            scoreLogic.Increase(ScoreType.FootHit);
            Assert.That(mockScore.Object.CurrentScore, Is.EqualTo(60));

        }

    }
}
