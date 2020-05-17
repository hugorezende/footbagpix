// <copyright file="ICharacterLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    /// <summary>
    /// Interface for Character Logic.
    /// </summary>
    public interface ICharacterLogic
    {
        /// <summary>
        /// Move Character and all their elements to the left.
        /// </summary>
        void MoveLeft();

        /// <summary>
        /// Move Character and all their elements to the right.
        /// </summary>
        void MoveRight();

        /// <summary>
        /// Performs a kick and check if character hitted the ball.
        /// </summary>
        /// <returns>Type of hit.</returns>
        ScoreType TryHitBall();

        /// <summary>
        /// Performs Character Turn.
        /// </summary>
        void Turn();

        /// <summary>
        /// Block character movements and controls for specific amount time.
        /// </summary>
        /// <param name="miliseconds">Period of blocked time.</param>
        void BlockControl(int miliseconds);

        /// <summary>
        /// Send character for the initial position.
        /// </summary>
        void Reset();
    }
}
