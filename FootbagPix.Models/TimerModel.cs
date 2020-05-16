namespace FootbagPix.Models
{
    using System;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    public class TimerModel : ITimerModel
    {
        public int TimeLeft { get; set; }

        public bool GameOver { get; set; }

        [XmlIgnore]
        public ImageBrush GameOverBrush { get; set; }

        public Brush GameOverTextBrush { get; set; }

        public TimerModel(int timeLeft)
        {
            TimeLeft = timeLeft;
            GameOver = false;
            GameOverBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/game_over.png")))
            {
                Opacity = 0
            };
            GameOverTextBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
        }

        public TimerModel()
        {
            GameOverBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/game_over.png")))
            {
                Opacity = 0
            };
        }
    }
}
