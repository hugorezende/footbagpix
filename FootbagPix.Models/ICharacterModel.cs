// <copyright file="ICharacterModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Models
{
    using System.Windows;
    using System.Windows.Media;

    public interface ICharacterModel
    {
        bool Blocked { get; set; }

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