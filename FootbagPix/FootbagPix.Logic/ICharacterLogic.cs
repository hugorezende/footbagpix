namespace FootbagPix.Logic
{
    public interface ICharacterLogic
    {
        void MoveLeft();

        void MoveRight();

        ScoreType TryHitBall();

        void Turn();

        void BlockControl(int miliseconds);

        void Reset();
    }
}
