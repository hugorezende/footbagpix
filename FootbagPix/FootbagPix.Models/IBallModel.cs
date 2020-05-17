// <copyright file="IBallModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Interface of a BallModel class.
    /// </summary>
    public interface IBallModel
    {
        /// <summary>
        /// Gets or sets the area of the rectangle (hitbox).
        /// </summary>
        Rect Area { get; set; }

        /// <summary>
        /// Gets or sets the image of the ball.
        /// </summary>
        ImageBrush ImageBrush { get; set; }

        /// <summary>
        /// Gets or sets the horizontal speed of the ball.
        /// </summary>
        double SpeedX { get; set; }

        /// <summary>
        /// Gets or sets the vertical speed of the ball.
        /// </summary>
        double SpeedY { get; set; }

        /// <summary>
        /// Gets or sets the amount of time the ball spent in the air.
        /// </summary>
        double TimeOnAir { get; set; }
    }
}