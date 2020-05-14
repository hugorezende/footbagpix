using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Models
{
    public class ScoreModel : IScoreModel
    {
        public int CurrentScore { get; set; }
        public int ComboCounter { get; set; }
        public int MaxComboCount { get; set; }
        public string ExtraInfo { get; set; }

        public ScoreModel()
        {
            CurrentScore = 0;
            ComboCounter = 0;
            MaxComboCount = 0;
            ExtraInfo = "";
        }
    }

}
