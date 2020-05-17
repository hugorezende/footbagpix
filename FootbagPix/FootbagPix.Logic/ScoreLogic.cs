// <copyright file="ScoreLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    using FootbagPix.Models;

    /// <summary>
    /// Score Logic Class.
    /// </summary>
    public class ScoreLogic : IScoreLogic
    {
        private readonly IScoreModel score;
        private readonly IBallModel ball;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreLogic"/> class.
        /// </summary>
        /// <param name="score">Score Model Interface.</param>
        /// <param name="ball">Ball Model interface.</param>
        public ScoreLogic(IScoreModel score, IBallModel ball)
        {
            this.score = score;
            this.ball = ball;
        }

        /// <summary>
        /// Method to Increase score.
        /// </summary>
        /// <param name="scoreType">Type of score, respesents what hit was performed.</param>
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

        /// <summary>
        /// Method to check if ball is on ground.
        /// </summary>
        public void CheckIfBallFell()
        {
            if (this.ball.Area.Y >= Config.GroundPosition)
            {
                this.score.ComboCounter = 0;
            }
        }

        /// <summary>
        /// Method to reset score.
        /// </summary>
        public void Reset()
        {
            this.score.CurrentScore = 0;
            this.score.ComboCounter = 0;
            this.score.MaxComboCount = 0;
        }
    }
}
