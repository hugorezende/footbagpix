using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FootbagPix.Models
{
    public class TimerModel
    {
        public int TimeLeft { get; set; }
        public bool GameOver { get; set; }
        public ImageBrush gameOverBrush { get; set; }
        public Brush gameOverTextBrush { get; set; }
        public TimerModel(int timeLeft)
        {
            TimeLeft = timeLeft;
            GameOver = false;
            gameOverBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/game_over.png")));
            gameOverBrush.Opacity = 0;
            gameOverTextBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }
    }
}
