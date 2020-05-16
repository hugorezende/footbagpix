namespace FootbagPix.Models
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    public class CharacterModel : ICharacterModel
    {
        public Rect leftFoot;
        public Rect rigthFoot;
        public Rect body;
        public Point head;

        public Rect LeftFoot { get; set; }

        public Rect RigthFoot { get; set; }

        public Rect Body { get { return body; } }

        public Point Head { get { return head; } }

        public Rect LeftKnee { get; set; }

        public Rect RigthKnee { get; set; }

        public int PositionX { get; set; }

        public int SpriteWidth { get; set; }

        public int SpriteHeight { get; set; }

        [XmlIgnore]
        public ImageBrush ImageBrush { get; set; }

        public bool Blocked { get; set; }

        public CharacterModel()
        {
            SpriteWidth = 95;
            SpriteHeight = 214;

            ImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/character_sprite3.png")))
            {
                Viewbox = new Rect(0, 0, SpriteWidth, SpriteHeight),
                ViewboxUnits = BrushMappingMode.Absolute,
                Stretch = Stretch.None
            };

            LeftFoot = new Rect((Config.windowWidth - SpriteWidth) / 2, Config.windowHeight - 100, 40, 40);
            RigthFoot = new Rect(((Config.windowWidth - SpriteWidth) / 2) + 50, Config.windowHeight - 100, 40, 40);

            LeftKnee = new Rect(((Config.windowWidth - SpriteWidth) / 2) + 30, Config.windowHeight - 140, 20, 20);
            RigthKnee = new Rect(((Config.windowWidth - SpriteWidth) / 2) + 60, Config.windowHeight - 140, 20, 20);

            PositionX = (Config.windowWidth - SpriteWidth) / 2;
        }

    }
}
