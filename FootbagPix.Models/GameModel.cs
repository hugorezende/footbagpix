// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;

    public class GameModel : IGameModel
    {
        public GameModel(string playerName)
        {
            this.GameID = Guid.NewGuid();
            this.Character = new CharacterModel();
            this.Ball = new BallModel();
            this.Timer = new TimerModel(Config.GameLength);
            this.PlayerName = playerName;
            this.Score = new ScoreModel();
        }

        public GameModel()
        {
        }

        public Guid GameID { get; set; }

        public CharacterModel Character { get; set; }

        public BallModel Ball { get; set; }

        public TimerModel Timer { get; set; }

        public string PlayerName { get; set; }

        public ScoreModel Score { get; set; }

        public DateTime SavedAt { get; set; }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-3} {2,6} {3,19}", this.PlayerName, this.Score.CurrentScore.ToString(), "0:" + this.Timer.TimeLeft, this.SavedAt.ToString("MM/dd/yyyy HH:mm"));
        }
    }
}