using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix
{
    class Config
    {
        // Window Size

        public const int windowWidth = 800;
        public const int windowHeight = 500;

        // Game Rules

        public const int gameLength = 60; // seconds
        public const int scorePerKick = 10;
        public const int groundPosition = 415;
        public const int kickForce = 10;
        public const double gravity = 0.01;
    }
}
