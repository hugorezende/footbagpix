// <copyright file="BallLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    using System;
    using System.Windows;
    using FootbagPix.Models;

    public class BallLogic : IBallLogic
    {
        private readonly IBallModel ball;

        public BallLogic(IBallModel ball)
        {
            this.ball = ball;
        }

        public event EventHandler RefreshScreen;

        public void DoGravity()
        {
            if (this.ball.Area.Y < Config.GroundPosition)
            {
                this.ball.TimeOnAir++;
                this.ball.SpeedY -= Config.Gravity * this.ball.TimeOnAir;

                this.ball.Area = Rect.Offset(this.ball.Area, this.ball.SpeedX, -this.ball.SpeedY);
            }
            else
            {
                this.ball.Area = new Rect(this.ball.Area.X, Config.GroundPosition + 1, 20, 20);
                this.ball.TimeOnAir = 0;
            }

            if (this.ball.Area.X < 0 || this.ball.Area.X + this.ball.Area.Width > Config.WindowWidth)
            {
                this.ball.SpeedX *= -1;
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void KickBall()
        {
            this.ball.TimeOnAir = 0;
            this.ball.Area = Rect.Offset(this.ball.Area, this.ball.Area.X, this.ball.Area.Y - 5); // just to remove ball of the area that DoGravity() does not work
            this.ball.SpeedY = 10;
        }

        public void Reset()
        {
            this.ball.Area = new Rect((Config.WindowWidth - this.ball.Area.Width) / 2, 50, 20, 20);
            this.ball.SpeedX = 0;
            this.ball.SpeedY = 0;
            this.ball.TimeOnAir = 0;
        }
    }
}
