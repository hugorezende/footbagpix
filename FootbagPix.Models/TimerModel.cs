// <copyright file="TimerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    public class TimerModel : ITimerModel
    {
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

        public TimerModel()
        {
            this.GameOverBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/game_over.png")))
            {
                Opacity = 0,
            };
        }

        public int TimeLeft { get; set; }

        public bool GameOver { get; set; }

        [XmlIgnore]
        public ImageBrush GameOverBrush { get; set; }

        public Brush GameOverTextBrush { get; set; }
    }
}
