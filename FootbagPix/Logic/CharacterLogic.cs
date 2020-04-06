using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FootbagPix.Logic
{
    class CharacterLogic : ICharacterLogic
    {
        BallModel ball;
        CharacterModel character;
        Random random = new Random();

        const int kickForce = 10;

        public CharacterLogic(BallModel ball, CharacterModel character)
        {
            this.ball = ball;
            this.character = character;
        }

        public void KickLeft()
        {
            throw new NotImplementedException();
        }

        public void KickRight()
        {
            throw new NotImplementedException();
        }

        public void MoveLeft()
        {
            character.PositionX -= 5;
            character.head.X -= 5;
            character.leftFoot.X -= 5;
            character.rigthFoot.X -= 5;
            character.body.X -= 5;
        }

        public void MoveRight()
        {
            character.PositionX += 5;
            character.head.X += 5;
            character.leftFoot.X += 5;
            character.rigthFoot.X += 5;
            character.body.X += 5;
        }

        public void TryHitBall()
        {
            AnimateKick();
            if (ball.Area.IntersectsWith(character.LeftFoot))
            {
                ball.TimeOnAir = 0;
                ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
                ball.SpeedY = kickForce;
                ball.SpeedX = (float)random.Next(-10, 10) / 10;
            }

            if (ball.Area.IntersectsWith(character.RigthFoot))
            {
                ball.TimeOnAir = 0;
                ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
                ball.SpeedY = kickForce;
                ball.SpeedX = (float)random.Next(-10, 10) / 10;
            }
        }

        private async void AnimateKick()
        {
            character.imageBrush.Viewbox = new Rect(-56, 0, 280, 213);
            await Task.Delay(100);
            character.imageBrush.Viewbox = new Rect(0, 0, 280, 213);
            await Task.Delay(100);
            character.imageBrush.Viewbox = new Rect(-56, 0, 280, 213);
            await Task.Delay(100);
            character.imageBrush.Viewbox = new Rect(-112, 0, 280, 213);
            
        }

        public void Turn()
        {
            throw new NotImplementedException();
        }
    }
}
