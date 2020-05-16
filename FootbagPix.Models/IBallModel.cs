// <copyright file="IBallModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System.Windows;
    using System.Windows.Media;

    public interface IBallModel
    {
        Rect Area { get; set; }

        ImageBrush ImageBrush { get; set; }

        double SpeedX { get; set; }

        double SpeedY { get; set; }

        double TimeOnAir { get; set; }
    }
}