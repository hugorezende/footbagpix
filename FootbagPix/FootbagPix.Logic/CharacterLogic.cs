namespace FootbagPix.Logic
{
    using System.Threading.Tasks;
    using System.Windows;
    using FootbagPix.Models;

    public class CharacterLogic : ICharacterLogic
    {
        readonly IBallModel ball;
        readonly ICharacterModel character;
        readonly ITimerModel timer;
        readonly IScoreModel score;
        public bool movingLeft;
        public bool movingRight;

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
                    character.PositionX -= 1;
                    await Task.Delay(100);
                    character.PositionX -= 1;
                    await Task.Delay(100);

                    character.LeftFoot = Rect.Offset(character.LeftFoot, -5, 0);
                    character.RigthFoot = Rect.Offset(character.RigthFoot, -5, 0);
                    character.LeftKnee = Rect.Offset(character.LeftKnee, -5, 0);
                    character.RigthKnee = Rect.Offset(character.RigthKnee, -5, 0);

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
                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);

                    character.LeftFoot = Rect.Offset(character.LeftFoot, 5, 0);
                    character.RigthFoot = Rect.Offset(character.RigthFoot, 5, 0);
                    character.LeftKnee = Rect.Offset(character.LeftKnee, 5, 0);
                    character.RigthKnee = Rect.Offset(character.RigthKnee, 5, 0);

                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);
                    character.PositionX += 1;
                    await Task.Delay(100);

                }
                
            }

        }

        public ScoreType TryHitBall()
        {
            if (!timer.GameOver && !character.Blocked)
            {
                if (ball.Area.IntersectsWith(character.LeftFoot))
                {
                    AnimateKickLeft();
                    ball.TimeOnAir = 0;
                    ball.Area = Rect.Offset(ball.Area, 0, -5);
                    ball.SpeedY = Config.kickForce;
                    ball.SpeedX = GenerateBallDirection(ball, character.LeftFoot);
                    return ScoreType.FootHit;
                }

                if (ball.Area.IntersectsWith(character.RigthFoot))
                {
                    AnimateKickRight();
                    ball.TimeOnAir = 0;
                    ball.Area = Rect.Offset(ball.Area, 0, -5);
                    ball.SpeedY = Config.kickForce;
                    ball.SpeedX = GenerateBallDirection(ball, character.RigthFoot);
                    return ScoreType.FootHit;
                }

                if (ball.Area.IntersectsWith(character.LeftKnee))
                {
                    AnimateKickLeft();
                    ball.TimeOnAir = 0;
                    ball.Area = Rect.Offset(ball.Area, 0, -5);
                    ball.SpeedY = Config.kickForce + 2;
                    ball.SpeedX = GenerateBallDirection(ball, character.LeftKnee);
                    return ScoreType.KneeHit;
                }

                if (ball.Area.IntersectsWith(character.RigthKnee))
                {
                    AnimateKickRight();
                    ball.TimeOnAir = 0;
                    ball.Area = Rect.Offset(ball.Area, 0, -5); //just to remove ball of the area that DoGravity() does not work
                    ball.SpeedY = Config.kickForce + 2;
                    ball.SpeedX = GenerateBallDirection(ball, character.RigthKnee);
                    return ScoreType.KneeHit;
                }

                AnimateKickLeft();
            }
            BlockControl(100);
            return ScoreType.Miss;
        }

        public float GenerateBallDirection(IBallModel ball, Rect surface)
        {
            double middleOfBall = ball.Area.X + (ball.Area.Width / 2);
            double middleOfSurface = surface.X + surface.Width / 2;
            float offset = (float)(middleOfBall - middleOfSurface);
            return offset / Config.kickOffset; 
        }

        public void Turn()
        {
            if (!character.Blocked && !timer.GameOver)
            {
                AnimateTurn();
                BlockControl(600);
                score.ExtraInfo = "Turn!";
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
            character.LeftKnee = new Rect(((Config.windowWidth - character.SpriteWidth) / 2) + 30, Config.windowHeight - 140, 20, 20);
            character.RigthKnee = new Rect(((Config.windowWidth - character.SpriteWidth) / 2) + 60, Config.windowHeight - 140, 20, 20);

            character.PositionX = (Config.windowWidth - character.SpriteWidth) / 2;

            character.Blocked = false;
        }
        private async void AnimateKickRight()
        {
            character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 2, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 2, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 2, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
        }

        private async void AnimateKickLeft()
        {
            character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 3, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 3, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth, character.SpriteHeight * 3, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
            character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
        }

        public async void AnimateWalkRight()
        {
            while (movingRight && !character.Blocked)
            {
                character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 1, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 3, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 4, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 5, character.SpriteHeight * 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
            }
            
        }

        public async void AnimateWalkLeft()
        {
            while (movingLeft && !character.Blocked)
            {
                character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 1, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 3, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 4, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
                character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 5, character.SpriteHeight * 1, character.SpriteWidth, character.SpriteHeight);
                await Task.Delay(50);
            }
            
        }
        private async void AnimateTurn()
        {
            character.ImageBrush.Viewbox = new Rect(0, 0, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 1, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 2, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 3, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 4, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 5, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(80);
            character.ImageBrush.Viewbox = new Rect(character.SpriteWidth * 6, character.SpriteHeight * 4, character.SpriteWidth, character.SpriteHeight);
            await Task.Delay(50);
        }

    }
}
