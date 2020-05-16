// <copyright file="CharacterLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    using System.Threading.Tasks;
    using System.Windows;
    using FootbagPix.Models;

    public class CharacterLogic : ICharacterLogic
    {
        public bool MovingLeft;
        public bool MovingRight;
        private readonly IBallModel ball;
        private readonly ICharacterModel character;
        private readonly ITimerModel timer;
        private readonly IScoreModel score;

        public CharacterLogic(IBallModel ball, ICharacterModel character, IScoreModel score, ITimerModel timer)
        {
            this.ball = ball;
            this.character = character;
            this.score = score;
            this.timer = timer;
        }

        public async void MoveLeft()
        {
            if (!this.timer.GameOver && !this.character.Blocked)
            {
                if (this.character.PositionX > 0)
                {
                    this.character.PositionX -= 1;
                    await Task.Delay(100);
                    this.character.PositionX -= 1;
                    await Task.Delay(100);

                    this.character.LeftFoot = Rect.Offset(this.character.LeftFoot, -5, 0);
                    this.character.RigthFoot = Rect.Offset(this.character.RigthFoot, -5, 0);
                    this.character.LeftKnee = Rect.Offset(this.character.LeftKnee, -5, 0);
                    this.character.RigthKnee = Rect.Offset(this.character.RigthKnee, -5, 0);

                    this.character.PositionX -= 1;
                    await Task.Delay(100);
                    this.character.PositionX -= 1;
                    await Task.Delay(100);
                    this.character.PositionX -= 1;
                    await Task.Delay(100);
                }
            }
        }

        public async void MoveRight()
        {
            if (!this.timer.GameOver && !this.character.Blocked)
            {
                if (this.character.PositionX + this.character.SpriteWidth < Config.WindowWidth)
                {
                    this.character.PositionX += 1;
                    await Task.Delay(100);
                    this.character.PositionX += 1;
                    await Task.Delay(100);

                    this.character.LeftFoot = Rect.Offset(this.character.LeftFoot, 5, 0);
                    this.character.RigthFoot = Rect.Offset(this.character.RigthFoot, 5, 0);
                    this.character.LeftKnee = Rect.Offset(this.character.LeftKnee, 5, 0);
                    this.character.RigthKnee = Rect.Offset(this.character.RigthKnee, 5, 0);

                    this.character.PositionX += 1;
                    await Task.Delay(100);
                    this.character.PositionX += 1;
                    await Task.Delay(100);
                    this.character.PositionX += 1;
                    await Task.Delay(100);
                }
            }
        }

        public ScoreType TryHitBall()
        {
            if (!this.timer.GameOver && !this.character.Blocked)
            {
                if (this.ball.Area.IntersectsWith(this.character.LeftFoot))
                {
                    this.AnimateKickLeft();
                    this.ball.TimeOnAir = 0;
                    this.ball.Area = Rect.Offset(this.ball.Area, 0, -5);
                    this.ball.SpeedY = Config.KickForce;
                    this.ball.SpeedX = this.GenerateBallDirection(this.ball, this.character.LeftFoot);
                    return ScoreType.FootHit;
                }

                if (this.ball.Area.IntersectsWith(this.character.RigthFoot))
                {
                    this.AnimateKickRight();
                    this.ball.TimeOnAir = 0;
                    this.ball.Area = Rect.Offset(this.ball.Area, 0, -5);
                    this.ball.SpeedY = Config.KickForce;
                    this.ball.SpeedX = this.GenerateBallDirection(this.ball, this.character.RigthFoot);
                    return ScoreType.FootHit;
                }

                if (this.ball.Area.IntersectsWith(this.character.LeftKnee))
                {
                    this.AnimateKickLeft();
                    this.ball.TimeOnAir = 0;
                    this.ball.Area = Rect.Offset(this.ball.Area, 0, -5);
                    this.ball.SpeedY = Config.KickForce + 2;
                    this.ball.SpeedX = this.GenerateBallDirection(this.ball, this.character.LeftKnee);
                    return ScoreType.KneeHit;
                }

                if (this.ball.Area.IntersectsWith(this.character.RigthKnee))
                {
                    this.AnimateKickRight();
                    this.ball.TimeOnAir = 0;
                    this.ball.Area = Rect.Offset(this.ball.Area, 0, -5); // just to remove ball of the area that DoGravity() does not work
                    this.ball.SpeedY = Config.KickForce + 2;
                    this.ball.SpeedX = this.GenerateBallDirection(this.ball, this.character.RigthKnee);
                    return ScoreType.KneeHit;
                }

                this.AnimateKickLeft();
            }

            this.BlockControl(100);
            return ScoreType.Miss;
        }

        public float GenerateBallDirection(IBallModel ball, Rect surface)
        {
            double middleOfBall = ball.Area.X + (ball.Area.Width / 2);
            double middleOfSurface = surface.X + (surface.Width / 2);
            float offset = (float)(middleOfBall - middleOfSurface);
            return offset / Config.KickOffset;
        }

        public void Turn()
        {
            if (!this.character.Blocked && !this.timer.GameOver)
            {
                this.AnimateTurn();
                this.BlockControl(600);
                this.score.ExtraInfo = "Turn!";
                this.score.ComboCounter++;
            }
        }

        public async void BlockControl(int miliseconds)
        {
            this.character.Blocked = true;
            await Task.Delay(miliseconds);
            this.character.Blocked = false;
        }

        public void Reset()
        {
            this.character.LeftFoot = new Rect((Config.WindowWidth - this.character.SpriteWidth) / 2, Config.WindowHeight - 100, 40, 40);
            this.character.RigthFoot = new Rect(((Config.WindowWidth - this.character.SpriteWidth) / 2) + 50, Config.WindowHeight - 100, 40, 40);
            this.character.LeftKnee = new Rect(((Config.WindowWidth - this.character.SpriteWidth) / 2) + 30, Config.WindowHeight - 140, 20, 20);
            this.character.RigthKnee = new Rect(((Config.WindowWidth - this.character.SpriteWidth) / 2) + 60, Config.WindowHeight - 140, 20, 20);

            this.character.PositionX = (Config.WindowWidth - this.character.SpriteWidth) / 2;

            this.character.Blocked = false;
        }

        public async void AnimateWalkRight()
        {
            while (this.MovingRight && !this.character.Blocked)
            {
                this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 1, this.character.SpriteHeight * 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 2, this.character.SpriteHeight * 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 3, this.character.SpriteHeight * 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 4, this.character.SpriteHeight * 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 5, this.character.SpriteHeight * 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
            }
        }

        public async void AnimateWalkLeft()
        {
            while (this.MovingLeft && !this.character.Blocked)
            {
                this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 1, this.character.SpriteHeight * 1, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 2, this.character.SpriteHeight * 1, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 3, this.character.SpriteHeight * 1, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 4, this.character.SpriteHeight * 1, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
                this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 5, this.character.SpriteHeight * 1, this.character.SpriteWidth, this.character.SpriteHeight);
                await Task.Delay(50);
            }
        }

        private async void AnimateKickRight()
        {
            this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth, this.character.SpriteHeight * 2, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 2, this.character.SpriteHeight * 2, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth, this.character.SpriteHeight * 2, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
        }

        private async void AnimateKickLeft()
        {
            this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth, this.character.SpriteHeight * 3, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 2, this.character.SpriteHeight * 3, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth, this.character.SpriteHeight * 3, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
            this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
        }

        private async void AnimateTurn()
        {
            this.character.ImageBrush.Viewbox = new Rect(0, 0, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(80);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 1, this.character.SpriteHeight * 4, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(80);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 2, this.character.SpriteHeight * 4, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(80);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 3, this.character.SpriteHeight * 4, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(80);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 4, this.character.SpriteHeight * 4, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(80);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 5, this.character.SpriteHeight * 4, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(80);
            this.character.ImageBrush.Viewbox = new Rect(this.character.SpriteWidth * 6, this.character.SpriteHeight * 4, this.character.SpriteWidth, this.character.SpriteHeight);
            await Task.Delay(50);
        }
    }
}
