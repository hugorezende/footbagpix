namespace FootbagPix.Services
{
    using System.Collections.Generic;

    public interface IScoreboardService
    {
        void AddScore(string playerName, int score, int maxCombo);

        List<string> ReadScores();
    }
}
