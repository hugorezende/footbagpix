using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
        public ImageBrush BackgroundBrush { get; set; }

        public GameModel(string playerName)
        {
            GameID = Guid.NewGuid();
            Character = new CharacterModel();
            Ball = new BallModel();
            Timer = new TimerModel(Config.gameLength);
            PlayerName = playerName;
            Score = new ScoreModel();
            BackgroundBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/bg.png")));
        }
    }
}