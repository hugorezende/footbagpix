// <copyright file="TimerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    /// <summary>
    /// Represents a timer.
    /// </summary>
    public class TimerModel : ITimerModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerModel"/> class.
        /// </summary>
        /// <param name="timeLeft">The number of seconds left.</param>
        public TimerModel(int timeLeft)
        {
            this.TimeLeft = timeLeft;
            this.GameOver = false;
            this.GameOverBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/game_over.png")))
            {
                Opacity = 0,
            };
            this.GameOverTextBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimerModel"/> class.
        /// Necessary for serialization.
        /// </summary>
        public TimerModel()
        {
            this.GameOverBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/game_over.png")))
            {
                Opacity = 0,
            };
        }

        /// <summary>
        /// Gets or sets the time left before the game ends.
        /// </summary>
        public int TimeLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is over.
        /// </summary>
        public bool GameOver { get; set; }

        /// <summary>
        /// Gets or sets the image displayed when the game is over.
        /// </summary>
        [XmlIgnore]
        public ImageBrush GameOverBrush { get; set; }

        /// <summary>
        /// Gets or sets the brush used to display text when the game is over.
        /// </summary>
        public Brush GameOverTextBrush { get; set; }
    }
}
