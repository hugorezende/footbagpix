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
        Rect LeftFoot { get; set; }
        int PositionX { get; set; }
        Rect RigthFoot { get; set; }
        Rect LeftKnee { get; set; }
        Rect RigthKneee { get; set; }
        int SpriteHeight { get; set; }
        int SpriteWidth { get; set; }
    }
}