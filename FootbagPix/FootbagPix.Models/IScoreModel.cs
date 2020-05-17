// <copyright file="IScoreModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    /// <summary>
    /// Interface of a ScoreModel class.
    /// </summary>
    public interface IScoreModel
    {
        /// <summary>
        /// Gets or sets the current combo count.
        /// </summary>
        int ComboCounter { get; set; }

        /// <summary>
        /// Gets or sets the current score.
        /// </summary>
        int CurrentScore { get; set; }

        /// <summary>
        /// Gets or sets the maximum combo count achieved during the game.
        /// </summary>
        int MaxComboCount { get; set; }

        /// <summary>
        /// Gets or sets extra information about the combo performed.
        /// </summary>
        string ExtraInfo { get; set; }
    }
}