using System.Windows;
using System.Windows.Media;

namespace FootbagPix.Models
{
    public interface ICharacterModel
    {
        bool Blocked { get; set; }
        Rect Body { get; }
        Point Head { get; }
        ImageBrush imageBrush { get; set; }
        Rect LeftFoot { get; }
        int PositionX { get; set; }
        Rect RigthFoot { get; }
        int SpriteHeight { get; set; }
        int SpriteWidth { get; set; }
    }
}