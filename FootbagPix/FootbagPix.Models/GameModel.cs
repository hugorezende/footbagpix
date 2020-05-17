// <copyright file="GameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;

    /// <summary>
    /// Represents a game, holds the data of all game elements.
    /// </summary>
    public class GameModel : IGameModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        public GameModel(string playerName)
        {
            this.GameID = Guid.NewGuid();
            this.Character = new CharacterModel();
            this.Ball = new BallModel();
            this.Timer = new TimerModel(Config.GameLength);
            this.PlayerName = playerName;
            this.Score = new ScoreModel();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameModel"/> class.
        /// Necessary for serialization.
        /// </summary>
        public GameModel()
        {
        }

        /// <summary>
        /// Gets or sets the ID of the game.
        /// </summary>
        public Guid GameID { get; set; }

        /// <summary>
        /// Gets or sets the character present in the game.
        /// </summary>
        public CharacterModel Character { get; set; }

        /// <summary>
        /// Gets or sets the ball present in the game.
        /// </summary>
        public BallModel Ball { get; set; }

        /// <summary>
        /// Gets or sets the timer present in the game.
        /// </summary>
        public TimerModel Timer { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the score present in the game.
        /// </summary>
        public ScoreModel Score { get; set; }

        /// <summary>
        /// Gets or sets the date at which the game was saved at.
        /// </summary>
        public DateTime SavedAt { get; set; }

        /// <summary>
        /// Override of the ToString() method.
        /// </summary>
        /// <returns>A clearly readable string representing the game.</returns>
        public override string ToString()
        {
            return string.Format("{0,-10} {1,-3} {2,6} {3,19}", this.PlayerName, this.Score.CurrentScore.ToString(), "0:" + this.Timer.TimeLeft, this.SavedAt.ToString("MM/dd/yyyy HH:mm"));
        }
    }
}