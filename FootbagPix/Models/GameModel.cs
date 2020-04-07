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
    class GameModel : IGameModel
    {
        public CharacterModel Character { get; set; }
        public BallModel Ball { get; set; }
        public string PlayerName { get; set; }
        public ScoreModel CurrentScore { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public int Gravity { get ; set ; }
        public ImageBrush BackgroundBrush { get; set; }

        public GameModel()
        {
            BackgroundBrush = new ImageBrush(new BitmapImage(new Uri("Resources/ImageResources/bg.png", UriKind.Relative)));

            Ball = new BallModel();
            Character = new CharacterModel();

            Gravity = 1;

        }
    }
}
