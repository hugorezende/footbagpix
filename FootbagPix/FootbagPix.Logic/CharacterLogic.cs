// <copyright file="CharacterLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    using System.Threading.Tasks;
    using System.Windows;
    using FootbagPix.Models;

    /// <summary>
    /// Class for Character Logic.
    /// </summary>
    public class CharacterLogic : ICharacterLogic
    {
        /// <summary>
        /// Store if chraracter is moving to the left in that instant.
        /// </summary>
        public bool MovingLeft;

        /// <summary>
        /// Store if chraracter is moving to the right in that instant.
        /// </summary>
        public bool MovingRight;

        private readonly IBallModel ball;
        private readonly ICharacterModel character;
        private readonly ITimerModel timer;
        private readonly IScoreModel score;

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterLogic"/> class.
        /// </summary>
        /// <param name="ball">Ball Model Interface.</param>
        /// <param name="character">Character  Model Interface.</param>
        /// <param name="score">Score Model Interface.</param>
        /// <param name="timer">Timer Model Interface.</param>
        public CharacterLogic(IBallModel ball, ICharacterModel character, IScoreModel score, ITimerModel timer)
        {
            this.ball = ball;
            this.character = character;
            this.score = score;
            this.timer = timer;
        }

        /// <summary>
        /// Move Character and all their elements to the left.
        /// </summary>
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

        /// <summary>
        /// Move Character and all their elements to the right.
        /// </summary>
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

        /// <summary>
        /// Performs a kick and check if character hitted the ball.
        /// </summary>
        /// <returns>Type of hit.</returns>
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

        /// <summary>
        /// Create direction for the ball after character kick.
        /// </summary>
        /// <param name="ball">Ball.</param>
        /// <param name="surface">Hit area.</param>
        /// <returns>Amount of X velocity.</returns>
        public float GenerateBallDirection(IBallModel ball, Rect surface)
        {
            double middleOfBall = ball.Area.X + (ball.Area.Width / 2);
            double middleOfSurface = surface.X + (surface.Width / 2);
            float offset = (float)(middleOfBall - middleOfSurface);
            return offset / Config.KickOffset;
        }

        /// <summary>
        /// Performs Turn for character.
        /// </summary>
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

        /// <summary>
        /// Block character movements and controls for specific amount time.
        /// </summary>
        /// <param name="miliseconds">Period of blocked time.</param>
        public async void BlockControl(int miliseconds)
        {
            this.character.Blocked = true;
            await Task.Delay(miliseconds);
            this.character.Blocked = false;
        }

        /// <summary>
        /// Send character for the initial position.
        /// </summary>
        public void Reset()
        {
            this.character.LeftFoot = new Rect((Config.WindowWidth - this.character.SpriteWidth) / 2, Config.WindowHeight - 100, 40, 40);
            this.character.RigthFoot = new Rect(((Config.WindowWidth - this.character.SpriteWidth) / 2) + 50, Config.WindowHeight - 100, 40, 40);
            this.character.LeftKnee = new Rect(((Config.WindowWidth - this.character.SpriteWidth) / 2) + 30, Config.WindowHeight - 140, 20, 20);
            this.character.RigthKnee = new Rect(((Config.WindowWidth - this.character.SpriteWidth) / 2) + 60, Config.WindowHeight - 140, 20, 20);

            this.character.PositionX = (Config.WindowWidth - this.character.SpriteWidth) / 2;

            this.character.Blocked = false;
        }

        /// <summary>
        /// Sprite Animation for Walk in right direction.
        /// </summary>
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

        /// <summary>
        /// Sprite Animation for Walk in left direction.
        /// </summary>
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

        /// <summary>
        /// Sprite Animation for kick with right foot.
        /// </summary>
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

        /// <summary>
        /// Sprite Animation for kick with left foot.
        /// </summary>
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

        /// <summary>
        /// Sprite Animation for caharter turn.
        /// </summary>
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
