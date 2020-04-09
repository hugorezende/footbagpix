using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Logic
{
    class ScoreLogic
    {
        ScoreModel score;
        BallModel ball;
        int groundPosition = 415;

        public ScoreLogic(ScoreModel score, BallModel ball)
        {
            this.score = score;
            this.ball = ball;
        }

        public const int scorePerKick = 10; // later put into config.cs ?

        public void Increase()
        {
            score.CurrentScore = score.CurrentScore + (scorePerKick * score.ComboCounter);
            if (score.ComboCounter > score.MaxComboCount)
            {
                score.MaxComboCount = score.ComboCounter;
            }
            score.ComboCounter++;
        }

        public void CheckIfBallFell()
        {
            if (ball.area.Y >= groundPosition)
            {
                score.ComboCounter = 0;
            }
        }

        public void Reset()
        {
            score.CurrentScore = 0;
            score.ComboCounter = 0;
            score.MaxComboCount = 0;
        }

        public void IncreaseCombo()
        {
            score.ComboCounter++;
        }

    }
}
