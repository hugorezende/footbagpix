using System.Windows;
using System.Windows.Media;

namespace FootbagPix.Models
{
    public interface IBallModel
    {
        Rect Area { get; set; }
        ImageBrush imageBrush { get; set; }
        double SpeedX { get; set; }
        double SpeedY { get; set; }
        double TimeOnAir { get; set; }
    }
}