// <copyright file="TestScoreLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Test
{
    using FootbagPix.Logic;
    using FootbagPix.Models;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Test TestScoreLogic Class.
    /// </summary>
    [TestFixture]
    internal class TestScoreLogic
    {
        private Mock<IScoreModel> mockScore;
        private Mock<IBallModel> mockBall;

        /// <summary>
        /// Unit test for Inscrease score.
        /// </summary>
        [Test]
        public void TestIncrease()
        {
            this.mockScore = new Mock<IScoreModel>(MockBehavior.Default);
            this.mockBall = new Mock<IBallModel>(MockBehavior.Default);

            this.mockScore.SetupProperty(mock => mock.CurrentScore, 0);
            this.mockScore.SetupProperty(mock => mock.ComboCounter, 1);

            ScoreLogic scoreLogic = new ScoreLogic(this.mockScore.Object, this.mockBall.Object);

            scoreLogic.Increase(ScoreType.FootHit);
            Assert.That(this.mockScore.Object.CurrentScore, Is.EqualTo(10));
            scoreLogic.Increase(ScoreType.FootHit);
            Assert.That(this.mockScore.Object.CurrentScore, Is.EqualTo(30));
            scoreLogic.Increase(ScoreType.FootHit);
            Assert.That(this.mockScore.Object.CurrentScore, Is.EqualTo(60));
        }
    }
}
