using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootbagPix.Logic
{
    class BallLogic : IBallLogic
    {
        BallModel ball;
        public event EventHandler RefreshScreen;
        public BallLogic(BallModel ball)
        {
            this.ball = ball;
        }
        public void DoGravity()
        {
            if (ball.area.Y < Config.groundPosition)
            {
                ball.TimeOnAir++;
                ball.SpeedY = ball.SpeedY - ((Config.gravity * ball.TimeOnAir));
                ball.area.X = ball.area.X + ball.SpeedX;
                ball.area.Y = ball.area.Y - ball.SpeedY;
            }
            else
            {
                ball.area.Y = Config.groundPosition + 1;
                ball.SpeedY = 0;
                ball.TimeOnAir = 0;
            }
            if (ball.area.X < 0 || ball.area.X + ball.Area.Width > Config.windowWidth)
            {
                ball.SpeedX *= -1;
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void KickBall()
        {
            ball.TimeOnAir = 0;
            ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
            ball.SpeedY = 10;
        }

        public void Reset()
        {
            ball.area = new Rect((Config.windowWidth - ball.Area.Width) / 2, 50, 20, 20);
            ball.SpeedX = 0;
            ball.SpeedY = 0;
            ball.TimeOnAir = 0;
        }
    }
}
