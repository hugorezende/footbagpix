using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace FootbagPix.Models
{
    public class GameModel : IGameModel
    {
        public Guid GameID { get; set; }
        public CharacterModel Character { get; set; }
        public BallModel Ball { get; set; }
        public TimerModel Timer { get; set; }
        public string PlayerName { get; set; }
        public ScoreModel Score { get; set; }
        public DateTime SavedAt { get; set; }

        public GameModel(string playerName)
        {
            GameID = Guid.NewGuid();
            Character = new CharacterModel();
            Ball = new BallModel();
            Timer = new TimerModel(Config.gameLength);
            PlayerName = playerName;
            Score = new ScoreModel();
        }

        public GameModel()
        {

        }

        public override string ToString()
        {
            return string.Format("{0,-10} {1,-3} {2,6} {3,19}", PlayerName, Score.CurrentScore.ToString(), "0:" + Timer.TimeLeft, SavedAt.ToString("MM/dd/yyyy HH:mm"));
        }
    }
}