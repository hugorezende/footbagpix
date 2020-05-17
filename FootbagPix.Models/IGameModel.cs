// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;

    /// <summary>
    /// Interface of a GameModel class.
    /// </summary>
    public interface IGameModel
    {
        /// <summary>
        /// Gets or sets the ID of the game.
        /// </summary>
        Guid GameID { get; set; }

        /// <summary>
        /// Gets or sets the character present in the game.
        /// </summary>
        CharacterModel Character { get; set; }

        /// <summary>
        /// Gets or sets the ball present in the game.
        /// </summary>
        BallModel Ball { get; set; }

        /// <summary>
        /// Gets or sets the timer present in the game.
        /// </summary>
        TimerModel Timer { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the score present in the game.
        /// </summary>
        ScoreModel Score { get; set; }

        /// <summary>
        /// Gets or sets the date at which the game was saved at.
        /// </summary>
        DateTime SavedAt { get; set; }
    }
}