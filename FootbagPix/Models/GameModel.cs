using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Models
{
    class GameModel : IGameModel
    {
        public CharacterModel Character { get; set; }
        public BallModel Ball { get; set; }
        public string PlayerName { get; set; }
        public ScoreModel CurrentScore { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public int Gravity { get ; set ; }

        public GameModel()
        {
            Ball = new BallModel();
            Character = new CharacterModel();

            Gravity = 1;

        }
    }
}
