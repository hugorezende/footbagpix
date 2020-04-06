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

        
        double gravity = 0.01;

        public BallLogic(BallModel ball)
        {
           
            this.ball = ball;
        }

        public void DoGravity()
        {
            if (ball.area.Y < 300)
            {
                ball.TimeOnAir++;
                ball.SpeedY = ball.SpeedY - ((gravity * ball.TimeOnAir ));
                ball.area.X = ball.area.X + ball.SpeedX;
                ball.area.Y = ball.area.Y - ball.SpeedY;

            }
            else
            {
                ball.area.Y = 301;
                ball.SpeedY = 0;
                ball.TimeOnAir = 0;

            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void KickBall()
        {
            ball.TimeOnAir = 0;
            ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
            ball.SpeedY = 10;
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
