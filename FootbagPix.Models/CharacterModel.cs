// <copyright file="CharacterModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Xml.Serialization;

    public class CharacterModel : ICharacterModel
    {
        public CharacterModel()
        {
            this.SpriteWidth = 95;
            this.SpriteHeight = 214;

            this.ImageBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/character_sprite3.png")))
            {
                Viewbox = new Rect(0, 0, this.SpriteWidth, this.SpriteHeight),
                ViewboxUnits = BrushMappingMode.Absolute,
                Stretch = Stretch.None,
            };

            this.LeftFoot = new Rect((Config.WindowWidth - this.SpriteWidth) / 2, Config.WindowHeight - 100, 40, 40);
            this.RigthFoot = new Rect(((Config.WindowWidth - this.SpriteWidth) / 2) + 50, Config.WindowHeight - 100, 40, 40);

            this.LeftKnee = new Rect(((Config.WindowWidth - this.SpriteWidth) / 2) + 30, Config.WindowHeight - 140, 20, 20);
            this.RigthKnee = new Rect(((Config.WindowWidth - this.SpriteWidth) / 2) + 60, Config.WindowHeight - 140, 20, 20);

            this.PositionX = (Config.WindowWidth - this.SpriteWidth) / 2;
        }

        public Rect LeftFoot { get; set; }

        public Rect RigthFoot { get; set; }

        public Rect LeftKnee { get; set; }

        public Rect RigthKnee { get; set; }

        public int PositionX { get; set; }

        public int SpriteWidth { get; set; }

        public int SpriteHeight { get; set; }

        [XmlIgnore]
        public ImageBrush ImageBrush { get; set; }

        public bool Blocked { get; set; }
    }
}
