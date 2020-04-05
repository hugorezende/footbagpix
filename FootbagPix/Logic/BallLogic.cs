using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootbagPix.Logic
{
    class BallLogic : IBallLogic
    {
        BallModel ball;
        public event EventHandler RefreshScreen;

        float time = 0;
        double gravity = 0.002;

        public BallLogic(BallModel ball)
        {
            this.ball = ball;
        }

        public void DoGravity()
        {
            if (ball.area.Y < 300)
            {
                time++;
                ball.SpeedY = ball.SpeedY - ((gravity * time * time));
                ball.area.Y = ball.area.Y - ball.SpeedY;

            }
            else
            {
                ball.area.Y = 301;
                ball.SpeedY = 0;
                time = 0;

            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void KickBall()
        {
            ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
            ball.SpeedY = ball.SpeedY + 10;
        }
        public void SetPosition(int x, int y)
        {
            ball.PositionX = x;
            ball.PositionY = y;
        }

        public void SetSpeed()
        {
            throw new NotImplementedException();
        }
    }
}
