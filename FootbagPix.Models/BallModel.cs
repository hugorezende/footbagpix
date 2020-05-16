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

    public class BallModel : IBallModel
    {
        private const int Width = 20;

        public BallModel()
        {
            this.ImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/ball.png")));

            this.Area = new Rect((Config.WindowWidth - BallModel.Width) / 2, 50, 20, 20);
            this.SpeedX = 0;
            this.SpeedY = 0;
            this.TimeOnAir = 0;
        }

        // public Rect area;
        public Rect Area { get; set; }

        public double SpeedX { get; set; }

        public double SpeedY { get; set; }

        public double TimeOnAir { get; set; }

        [XmlIgnore]
        public ImageBrush ImageBrush { get; set; }
    }
}
