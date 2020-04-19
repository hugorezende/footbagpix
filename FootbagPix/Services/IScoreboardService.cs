using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Services
{
    public interface IScoreboardService
    {
        void AddScore(string playerName, int score, int maxCombo);
        List<string> ReadScores();
    }
}
