namespace FootbagPix.Logic
{
    public interface IScoreLogic
    {
        void Increase(ScoreType scoreType);

        void CheckIfBallFell();

        void Reset();
    }
}
