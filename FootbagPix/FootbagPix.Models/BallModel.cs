// <copyright file="BallModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a ball.
    /// </summary>
    public class BallModel : IBallModel
    {
        private const int Width = 20;

        /// <summary>
        /// Initializes a new instance of the <see cref="BallModel"/> class.
        /// </summary>
        public BallModel()
        {
            this.ImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/ball.png")));

            this.Area = new Rect((Config.WindowWidth - BallModel.Width) / 2, 50, 20, 20);
            this.SpeedX = 0;
            this.SpeedY = 0;
            this.TimeOnAir = 0;
        }

        /// <summary>
        /// Gets or sets the area of the rectangle (hitbox).
        /// </summary>
        public Rect Area { get; set; }

        /// <summary>
        /// Gets or sets the horizontal speed of the ball.
        /// </summary>
        public double SpeedX { get; set; }

        /// <summary>
        /// Gets or sets the vertical speed of the ball.
        /// </summary>
        public double SpeedY { get; set; }

        /// <summary>
        /// Gets or sets the amount of time the ball spent in the air.
        /// </summary>
        public double TimeOnAir { get; set; }

        /// <summary>
        /// Gets or sets the image of the ball.
        /// </summary>
        [XmlIgnore]
        public ImageBrush ImageBrush { get; set; }
    }
}
