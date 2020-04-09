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
        TimerModel timer;
        ScoreModel score;
        Random random = new Random();

        const int kickForce = 10;

        public CharacterLogic(BallModel ball, CharacterModel character, ScoreModel score, TimerModel timer)
        {
            this.ball = ball;
            this.character = character;
            this.score = score;
            this.timer = timer;
        }

        public void KickLeft()
        {
            throw new NotImplementedException();
        }

        public void KickRight()
        {
            throw new NotImplementedException();
        }

        public async void MoveLeft()
        {
            if (!timer.GameOver && !character.Blocked)
            {
                if (0 < character.PositionX)
                {
                    character.leftFoot.X -= 5;
                    character.rigthFoot.X -= 5;
                    AnimateWalkRight();
                    character.PositionX -= 1;
                    await Task.Delay(100);
                    character.PositionX -= 1;
                    await Task.Delay(100);
                    character.PositionX -= 1;
                    await Task.Delay(100);
                    character.PositionX -= 1;
                    await Task.Delay(100);
                    character.PositionX -= 1;
                    await Task.Delay(100);
                }
            }
        }

        public async void MoveRight()
        {
            if (!timer.GameOver && !character.Blocked)
            {
                if (character.PositionX + character.SpriteWidth < Config.windowWidth)
                {
                    character.leftFoot.X += 5;
                    character.rigthFoot.X += 5;
                    AnimateWalkLeft();
                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);
                }
                
            }

        }

        public bool TryHitBall()
        {
            if (!timer.GameOver && !character.Blocked)
            {
                if (ball.Area.IntersectsWith(character.LeftFoot))
                {
                    AnimateKickLeft();
                    ball.TimeOnAir = 0;
                    ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
                    ball.SpeedY = kickForce;
                    ball.SpeedX = (float)random.Next(-10, 10) / 10;
                    return true;
                }

                if (ball.Area.IntersectsWith(character.RigthFoot))
                {
                    AnimateKickRight();
                    ball.TimeOnAir = 0;
                    ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
                    ball.SpeedY = kickForce;
                    ball.SpeedX = (float)random.Next(-10, 10) / 10;
                    return true;
                }
                AnimateKickLeft();
            }
            BlockControl(100);
            return false;
        }

        private async void AnimateKickRight()
        {
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 2, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 2, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 2, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
        }

        private async void AnimateKickLeft()
        {
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 3, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 3, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 3, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
        }

        private async void AnimateWalkLeft()
        {
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 1, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 3, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 4, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 5, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
        }

        private async void AnimateWalkRight()
        {
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 1, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 3, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 4, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 5, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
        }
        private async void AnimateTurn()
        {
            character.imageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 1, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 3, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 4, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 5, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.imageBrush.Viewbox = new Rect(character.SpriteWidth * 6, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
        }

        public void Turn()
        {
            if (!character.Blocked && !timer.GameOver)
            {
                AnimateTurn();
                BlockControl(600);
                score.ComboCounter++;
            }
        }
        public async void BlockControl(int miliseconds)
        {
            character.Blocked = true;
            await Task.Delay(miliseconds);
            character.Blocked = false;
        }

    }
}
