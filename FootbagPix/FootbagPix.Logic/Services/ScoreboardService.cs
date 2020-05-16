// <copyright file="ScoreboardService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Services
{
    using System.Collections.Generic;
    using System.Net;

    public class ScoreboardService : IScoreboardService
    {
        private const string PrivateURL = "http://dreamlo.com/lb/A1bG9M-W70GThtBQTVl-AA44FEVXFiYUWvWtufLd2f6w";
        private const string PublicURL = "http://dreamlo.com/lb/5e8caa74403c2d12b8c4827a";

        public void AddScore(string playerName, int score, int maxCombo)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(PrivateURL + "/add/" + playerName + "/" + score + "/" + maxCombo);
            _ = (HttpWebResponse)request.GetResponse();
        }

        public List<string> ReadScores()
        {
            List<ScoreboardEntry> scoreboardEntries = ScoreboardEntry.Load(PublicURL + "/xml");
            List<string> formattedScoreboardEntries = new List<string>();
            for (int i = 0; i < scoreboardEntries.Count; i++)
            {
                formattedScoreboardEntries.Add(i + 1 + ". " + scoreboardEntries[i].ToString());
            }

            return formattedScoreboardEntries;
        }
    }
}
