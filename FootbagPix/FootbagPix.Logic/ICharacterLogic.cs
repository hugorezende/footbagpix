// <copyright file="ICharacterLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    public interface ICharacterLogic
    {
        void MoveLeft();

        void MoveRight();

        ScoreType TryHitBall();

        void Turn();

        void BlockControl(int miliseconds);

        void Reset();
    }
}
