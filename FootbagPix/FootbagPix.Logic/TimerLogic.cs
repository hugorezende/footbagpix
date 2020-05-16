namespace FootbagPix.Logic
{
    using System.Windows.Media;
    using FootbagPix.Models;
    using FootbagPix.Services;

    public class TimerLogic : ITimerLogic
    {
        readonly TimerModel timer;
        readonly GameModel game;
        readonly ScoreboardService scoreboardService;

        public TimerLogic(TimerModel timer, GameModel game)
        {
            this.timer = timer;
            this.game = game;
            scoreboardService = new ScoreboardService();
        }

        public void DecrementTime()
        {
            if (!timer.GameOver)
            {
                if (timer.TimeLeft > 0)
                {
                    timer.TimeLeft--;
                }
                else
                {
                    timer.GameOver = true;
                    game.Character.Blocked = true;
                    scoreboardService.AddScore(game.PlayerName, game.Score.CurrentScore, game.Score.MaxComboCount);
                    ShowGameOver();
                }
            }

        }

        public void ShowGameOver()
        {
            timer.GameOverBrush.Opacity = 1;
            timer.GameOverTextBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            game.Score.ComboCounter = 0;
        }

        public void Reset()
        {
            timer.GameOver = false;
            timer.GameOverBrush.Opacity = 0;
            timer.GameOverTextBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            timer.TimeLeft = Config.gameLength;
        }
    }
}
