namespace FootbagPix.Logic
{
    using FootbagPix.Models;

    public class ScoreLogic : IScoreLogic
    {
        readonly IScoreModel score;
        readonly IBallModel ball;

        public ScoreLogic(IScoreModel score, IBallModel ball)
        {
            this.score = score;
            this.ball = ball;
        }

        public void Increase(ScoreType scoreType)
        {
            if (scoreType == ScoreType.FootHit)
            {
                score.CurrentScore += (Config.scorePerKick * score.ComboCounter);
                if (score.ComboCounter > score.MaxComboCount)
                {
                    score.MaxComboCount = score.ComboCounter;
                }
                score.ExtraInfo = "Foot Hit";
                score.ComboCounter++;
            }

            if (scoreType == ScoreType.KneeHit)
            {
                score.CurrentScore += (Config.scorePerKick * score.ComboCounter);
                if (score.ComboCounter > score.MaxComboCount)
                {
                    score.MaxComboCount = score.ComboCounter;
                }
                score.ExtraInfo = "Knee Hit!";
                score.ComboCounter++;
            }
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
    }
}
