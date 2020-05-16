// <copyright file="ScoreLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    using FootbagPix.Models;

    public class ScoreLogic : IScoreLogic
    {
        private readonly IScoreModel score;
        private readonly IBallModel ball;

        public ScoreLogic(IScoreModel score, IBallModel ball)
        {
            this.score = score;
            this.ball = ball;
        }

        public void Increase(ScoreType scoreType)
        {
            if (scoreType == ScoreType.FootHit)
            {
                this.score.CurrentScore += Config.ScorePerKick * this.score.ComboCounter;
                if (this.score.ComboCounter > this.score.MaxComboCount)
                {
                    this.score.MaxComboCount = this.score.ComboCounter;
                }

                this.score.ExtraInfo = "Foot Hit";
                this.score.ComboCounter++;
            }

            if (scoreType == ScoreType.KneeHit)
            {
                this.score.CurrentScore += Config.ScorePerKick * this.score.ComboCounter;
                if (this.score.ComboCounter > this.score.MaxComboCount)
                {
                    this.score.MaxComboCount = this.score.ComboCounter;
                }

                this.score.ExtraInfo = "Knee Hit!";
                this.score.ComboCounter++;
            }
        }

        public void CheckIfBallFell()
        {
            if (this.ball.Area.Y >= Config.GroundPosition)
            {
                this.score.ComboCounter = 0;
            }
        }

        public void Reset()
        {
            this.score.CurrentScore = 0;
            this.score.ComboCounter = 0;
            this.score.MaxComboCount = 0;
        }
    }
}
