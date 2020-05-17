// <copyright file="ICharacterModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Interface of a CharacterModel class.
    /// </summary>
    public interface ICharacterModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether the character is in a blocked state.
        /// </summary>
        bool Blocked { get; set; }

        /// <summary>
        /// Gets or sets the image of the character.
        /// </summary>
        ImageBrush ImageBrush { get; set; }

        /// <summary>
        /// Gets or sets the left foot of the character (hitbox).
        /// </summary>
        Rect LeftFoot { get; set; }

        /// <summary>
        /// Gets or sets the horizontal position of the character.
        /// </summary>
        int PositionX { get; set; }

        /// <summary>
        /// Gets or sets the right foot of the character (hitbox).
        /// </summary>
        Rect RigthFoot { get; set; }

        /// <summary>
        /// Gets or sets the left knee of the character (hitbox).
        /// </summary>
        Rect LeftKnee { get; set; }

        /// <summary>
        /// Gets or sets the right knee of the character (hitbox).
        /// </summary>
        Rect RigthKnee { get; set; }

        /// <summary>
        /// Gets or sets the heigth of the sprite used for the character.
        /// </summary>
        int SpriteHeight { get; set; }

        /// <summary>
        /// Gets or sets the width of the sprite used for the character.
        /// </summary>
        int SpriteWidth { get; set; }
    }
}