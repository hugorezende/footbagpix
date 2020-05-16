using FootbagPix.Models;
using FootbagPix.Services;
using System.Windows.Media;

namespace FootbagPix.Logic
{
    public class TimerLogic : ITimerLogic
    {
        TimerModel timer;
        GameModel game;
        ScoreboardService scoreboardService;

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
            timer.gameOverBrush.Opacity = 1;
            timer.gameOverTextBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            game.Score.ComboCounter = 0;
        }

        public void Reset()
        {
            timer.GameOver = false;
            timer.gameOverBrush.Opacity = 0;
            timer.gameOverTextBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            timer.TimeLeft = Config.gameLength;
        }
    }
}
