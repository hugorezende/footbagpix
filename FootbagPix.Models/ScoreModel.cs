// <copyright file="ScoreModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    public class ScoreModel : IScoreModel
    {
        public ScoreModel()
        {
            this.CurrentScore = 0;
            this.ComboCounter = 0;
            this.MaxComboCount = 0;
            this.ExtraInfo = string.Empty;
        }

        public int CurrentScore { get; set; }

        public int ComboCounter { get; set; }

        public int MaxComboCount { get; set; }

        public string ExtraInfo { get; set; }
    }
}
