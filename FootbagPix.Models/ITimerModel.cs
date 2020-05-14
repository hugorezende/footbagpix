using System.Windows.Media;

namespace FootbagPix.Models
{
    public interface ITimerModel
    {
        bool GameOver { get; set; }
        ImageBrush gameOverBrush { get; set; }
        Brush gameOverTextBrush { get; set; }
        int TimeLeft { get; set; }
    }
}