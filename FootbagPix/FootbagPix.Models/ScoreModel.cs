// <copyright file="ScoreModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    /// <summary>
    /// Represents score.
    /// </summary>
    public class ScoreModel : IScoreModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreModel"/> class.
        /// </summary>
        public ScoreModel()
        {
            this.CurrentScore = 0;
            this.ComboCounter = 0;
            this.MaxComboCount = 0;
            this.ExtraInfo = string.Empty;
        }

        /// <summary>
        /// Gets or sets the current score.
        /// </summary>
        public int CurrentScore { get; set; }

        /// <summary>
        /// Gets or sets the current combo count.
        /// </summary>
        public int ComboCounter { get; set; }

        /// <summary>
        /// Gets or sets the maximum combo count achieved during the game.
        /// </summary>
        public int MaxComboCount { get; set; }

        /// <summary>
        /// Gets or sets extra information about the combo performed.
        /// </summary>
        public string ExtraInfo { get; set; }
    }
}
