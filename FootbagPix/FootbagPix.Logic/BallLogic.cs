using FootbagPix.Models;
using System;
using System.Windows;

namespace FootbagPix.Logic
{
    public class BallLogic : IBallLogic
    {
        IBallModel ball;
        public event EventHandler RefreshScreen;
        public BallLogic(IBallModel ball)
        {
            this.ball = ball;
        }
        public void DoGravity()
        {
            Console.WriteLine(ball.Area.Y);
            if (ball.Area.Y < Config.groundPosition)
            {
                ball.TimeOnAir++;
                ball.SpeedY = ball.SpeedY - ((Config.gravity * ball.TimeOnAir));

                ball.Area = Rect.Offset(ball.Area, ball.SpeedX, -ball.SpeedY) ;
                
            }
            else
            {
                ball.Area = new Rect(ball.Area.X, Config.groundPosition + 1, 20, 20);
                ball.TimeOnAir = 0;
            }
            if (ball.Area.X < 0 || ball.Area.X + ball.Area.Width > Config.windowWidth)
            {
                ball.SpeedX *= -1;
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void KickBall()
        {
            ball.TimeOnAir = 0;
            ball.Area = Rect.Offset(ball.Area, ball.Area.X, ball.Area.Y - 5); //just to remove ball of the area that DoGravity() does not work
            ball.SpeedY = 10;
        }

        public void Reset()
        {
            ball.Area = new Rect((Config.windowWidth - ball.Area.Width) / 2, 50, 20, 20);
            ball.SpeedX = 0;
            ball.SpeedY = 0;
            ball.TimeOnAir = 0;
        }
    }
}
