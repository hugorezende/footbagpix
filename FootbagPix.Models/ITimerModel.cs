// <copyright file="ITimerModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System.Windows.Media;

    public interface ITimerModel
    {
        bool GameOver { get; set; }

        ImageBrush GameOverBrush { get; set; }

        Brush GameOverTextBrush { get; set; }

        int TimeLeft { get; set; }
    }
}