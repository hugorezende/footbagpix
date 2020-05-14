using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Services
{
    public class ScoreboardService : IScoreboardService
    {
        private const string privateURL = "http://dreamlo.com/lb/A1bG9M-W70GThtBQTVl-AA44FEVXFiYUWvWtufLd2f6w";
        private const string publicURL = "http://dreamlo.com/lb/5e8caa74403c2d12b8c4827a";

        public void AddScore(string playerName, int score, int maxCombo)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(privateURL + "/add/" + playerName + "/" + score + "/" + maxCombo);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        public List<string> ReadScores()
        {
            List<ScoreboardEntry> scoreboardEntries = ScoreboardEntry.Load(publicURL + "/xml");
            List<string> formattedScoreboardEntries = new List<string>();
            for (int i = 0; i < scoreboardEntries.Count; i++)
            {
                formattedScoreboardEntries.Add((i + 1) + ". " + scoreboardEntries[i].ToString());
            }
            return formattedScoreboardEntries;
        }
    }
}
