using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Models
{
    public class ScoreModel
    {
        public int CurrentScore { get; set; }
        public int ComboCounter { get; set; }

        public ScoreModel()
        {
            CurrentScore = 0;
            ComboCounter = 0;
        }
    }

}
