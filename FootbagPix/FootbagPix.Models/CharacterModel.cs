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

    /// <summary>
    /// Represents a character.
    /// </summary>
    public class CharacterModel : ICharacterModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterModel"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the left foot of the character (hitbox).
        /// </summary>
        public Rect LeftFoot { get; set; }

        /// <summary>
        /// Gets or sets the right foot of the character (hitbox).
        /// </summary>
        public Rect RigthFoot { get; set; }

        /// <summary>
        /// Gets or sets the left knee of the character (hitbox).
        /// </summary>
        public Rect LeftKnee { get; set; }

        /// <summary>
        /// Gets or sets the right knee of the character (hitbox).
        /// </summary>
        public Rect RigthKnee { get; set; }

        /// <summary>
        /// Gets or sets the horizontal position of the character.
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// Gets or sets the width of the sprite used for the character.
        /// </summary>
        public int SpriteWidth { get; set; }

        /// <summary>
        /// Gets or sets the heigth of the sprite used for the character.
        /// </summary>
        public int SpriteHeight { get; set; }

        /// <summary>
        /// Gets or sets the image of the character.
        /// </summary>
        [XmlIgnore]
        public ImageBrush ImageBrush { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the character is in a blocked state.
        /// </summary>
        public bool Blocked { get; set; }
    }
}
