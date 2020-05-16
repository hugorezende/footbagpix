namespace FootbagPix.Models
{
    using System.Windows;
    using System.Windows.Media;

    public interface ICharacterModel
    {
        bool Blocked { get; set; }

        Rect Body { get; }

        Point Head { get; }

        ImageBrush ImageBrush { get; set; }

        Rect LeftFoot { get; set; }

        int PositionX { get; set; }

        Rect RigthFoot { get; set; }

        Rect LeftKnee { get; set; }

        Rect RigthKnee { get; set; }

        int SpriteHeight { get; set; }

        int SpriteWidth { get; set; }
    }
}