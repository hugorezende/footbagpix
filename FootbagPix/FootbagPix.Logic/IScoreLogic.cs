// <copyright file="IScoreLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    /// <summary>
    /// Interface for Score Logic.
    /// </summary>
    public interface IScoreLogic
    {
        /// <summary>
        /// Increase Score.
        /// </summary>
        /// <param name="scoreType">Type of hit. Depends on which area was hit.</param>
        void Increase(ScoreType scoreType);

        /// <summary>
        /// Methos to perform action when ball fall.
        /// </summary>
        void CheckIfBallFell();

        /// <summary>
        /// Method to reset Score.
        /// </summary>
        void Reset();
    }
}
