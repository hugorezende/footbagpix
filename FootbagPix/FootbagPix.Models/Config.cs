// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    /// <summary>
    /// A config class, containing constant values wich define the window size and game rules.
    /// </summary>
    public class Config
    {
        // Window Size

        /// <summary>
        /// The width of the game window.
        /// </summary>
        public const int WindowWidth = 800;

        /// <summary>
        /// The height of the game window.
        /// </summary>
        public const int WindowHeight = 500;

        // Game Rules

        /// <summary>
        /// The length of the game in seconds.
        /// </summary>
        public const int GameLength = 60; // seconds

        /// <summary>
        /// The score gained per successful kick.
        /// </summary>
        public const int ScorePerKick = 10;

        /// <summary>
        /// The position of the ground.
        /// </summary>
        public const int GroundPosition = 415;

        /// <summary>
        /// The force by which the ball gets kicked.
        /// </summary>
        public const int KickForce = 10;

        /// <summary>
        /// The amount of offset in ball direction generation.
        /// </summary>
        public const int KickOffset = 10; // The smaller this number, the harder the game. 15 = Easy, 10 = Normal, 1 = You have chosen.. death!

        /// <summary>
        /// Gravity.
        /// </summary>
        public const double Gravity = 0.01;
    }
}
