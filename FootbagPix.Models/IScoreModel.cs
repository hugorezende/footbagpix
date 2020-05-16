// <copyright file="IScoreModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    public interface IScoreModel
    {
        int ComboCounter { get; set; }

        int CurrentScore { get; set; }

        int MaxComboCount { get; set; }

        string ExtraInfo { get; set; }
    }
}