// <copyright file="ITimerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System.Windows.Media;

    /// <summary>
    /// Interface of a TimerModel class.
    /// </summary>
    public interface ITimerModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        bool GameOver { get; set; }

        /// <summary>
        /// Gets or sets the image displayed when the game is over.
        /// </summary>
        ImageBrush GameOverBrush { get; set; }

        /// <summary>
        /// Gets or sets the brush used to display text when the game is over.
        /// </summary>
        Brush GameOverTextBrush { get; set; }

        /// <summary>
        /// Gets or sets the time left before the game ends.
        /// </summary>
        int TimeLeft { get; set; }
    }
}