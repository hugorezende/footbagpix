namespace FootbagPix
{
    public class Config
    {
        // Window Size
        public const int windowWidth = 800;
        public const int windowHeight = 500;

        // Game Rules
        public const int gameLength = 60; // seconds
        public const int scorePerKick = 10;
        public const int groundPosition = 415;
        public const int kickForce = 10;
        public const int kickOffset = 10; // The smaller this number, the harder the game. 15 = Easy, 10 = Normal, 1 = You have chosen.. death!
        public const double gravity = 0.01;
    }
}
