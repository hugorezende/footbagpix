using FootbagPix.Models;

namespace FootbagPix.Logic
{
    public class ScoreLogic : IScoreLogic
    {
        ScoreModel score;
        BallModel ball;

        public ScoreLogic(ScoreModel score, BallModel ball)
        {
            this.score = score;
            this.ball = ball;
        }

        public void Increase()
        {
            score.CurrentScore = score.CurrentScore + (Config.scorePerKick * score.ComboCounter);
            if (score.ComboCounter > score.MaxComboCount)
            {
                score.MaxComboCount = score.ComboCounter;
            }
            score.ComboCounter++;
        }

        public void CheckIfBallFell()
        {
            if (ball.Area.Y >= Config.groundPosition)
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
