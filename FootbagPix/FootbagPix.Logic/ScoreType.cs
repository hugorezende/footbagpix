// <copyright file="ScoreType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    /// <summary>
    /// ScoreType Enum.
    /// </summary>
    public enum ScoreType
    {
        /// <summary>
        /// Represents a Missed Hit.
        /// </summary>
        Miss = -1,

        /// <summary>
        /// Represents a Foot Hit.
        /// </summary>
        FootHit = 0,

        /// <summary>
        /// Represents a Knee Hit.
        /// </summary>
        KneeHit = 1,

        /// <summary>
        /// Represents a Head Hit.
        /// </summary>
        HeadHit = 2,
    }
}