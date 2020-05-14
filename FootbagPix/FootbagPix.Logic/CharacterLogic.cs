using FootbagPix.Models;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace FootbagPix.Logic
{
    public class CharacterLogic : ICharacterLogic
    {
        IBallModel ball;
        ICharacterModel character;
        ITimerModel timer;
        IScoreModel score;
        Random random = new Random();

        public CharacterLogic(IBallModel ball, ICharacterModel character, IScoreModel score, ITimerModel timer)
        {
            this.ball = ball;
            this.character = character;
            this.score = score;
            this.timer = timer;
        }

        public async void MoveLeft()
        {
            if (!timer.GameOver && !character.Blocked)
            {
                if (0 < character.PositionX)
                {
                    character.LeftFoot = Rect.Offset(character.LeftFoot, -5, 0);
                    character.RigthFoot = Rect.Offset(character.RigthFoot, -5, 0);
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
                    character.LeftFoot = Rect.Offset(character.LeftFoot, 5, 0);
                    character.RigthFoot = Rect.Offset(character.RigthFoot, 5, 0);
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
                    ball.Area = Rect.Offset(ball.Area, 0, -5);
                    ball.SpeedY = Config.kickForce;
                    ball.SpeedX = (float)random.Next(-10, 10) / 10;
                    return true;
                }

                if (ball.Area.IntersectsWith(character.RigthFoot))
                {
                    AnimateKickRight();
                    ball.TimeOnAir = 0;
                    ball.Area = Rect.Offset(ball.Area, 0, -5);
                    //ball.area.Y = ball.area.Y - 5; //just to remove ball of the area that DoGravity() does not work
                    ball.SpeedY = Config.kickForce;
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

        public void Reset()
        {
            character.LeftFoot = new Rect((Config.windowWidth - character.SpriteWidth) / 2, Config.windowHeight - 100, 40, 40);
            character.RigthFoot = new Rect(((Config.windowWidth - character.SpriteWidth) / 2) +50, Config.windowHeight - 100, 40, 40);
            character.PositionX = (Config.windowWidth - character.SpriteWidth) / 2;
        }

    }
}
