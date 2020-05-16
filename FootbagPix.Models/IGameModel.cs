namespace FootbagPix.Models
{
    using System;

    public interface IGameModel
    {
        Guid GameID { get; set; }

        CharacterModel Character { get; set; }

        BallModel Ball { get; set; }

        TimerModel Timer { get; set; }

        string PlayerName { get; set; }

        ScoreModel Score { get; set; }

        DateTime SavedAt { get; set; }
    }
}