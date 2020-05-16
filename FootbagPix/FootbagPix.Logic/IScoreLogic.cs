// <copyright file="IScoreLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    public interface IScoreLogic
    {
        void Increase(ScoreType scoreType);

        void CheckIfBallFell();

        void Reset();
    }
}
