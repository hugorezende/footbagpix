// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    public class Config
    {
        // Window Size
        public const int WindowWidth = 800;
        public const int WindowHeight = 500;

        // Game Rules
        public const int GameLength = 60; // seconds
        public const int ScorePerKick = 10;
        public const int GroundPosition = 415;
        public const int KickForce = 10;
        public const int KickOffset = 10; // The smaller this number, the harder the game. 15 = Easy, 10 = Normal, 1 = You have chosen.. death!
        public const double Gravity = 0.01;
    }
}
