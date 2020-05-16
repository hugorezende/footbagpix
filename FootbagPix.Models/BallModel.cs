namespace FootbagPix.Models
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    public class BallModel : IBallModel
    {
        const int width = 20;

       // public Rect area;
        public Rect Area { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public double TimeOnAir { get; set; }
        [XmlIgnore]
        public ImageBrush ImageBrush { get; set; }


        public BallModel()
        {
            ImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/ball.png")));

            Area = new Rect((Config.windowWidth - BallModel.width) / 2, 50, 20, 20);
            SpeedX = 0;
            SpeedY = 0;
            TimeOnAir = 0;
        }

    }
}
