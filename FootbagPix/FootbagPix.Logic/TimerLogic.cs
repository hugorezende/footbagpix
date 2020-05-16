// <copyright file="TimerLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Logic
{
    using System.Windows.Media;
    using FootbagPix.Models;
    using FootbagPix.Services;

    public class TimerLogic : ITimerLogic
    {
        private readonly TimerModel timer;
        private readonly GameModel game;
        private readonly ScoreboardService scoreboardService;

        public TimerLogic(TimerModel timer, GameModel game)
        {
            this.timer = timer;
            this.game = game;
            this.scoreboardService = new ScoreboardService();
        }

        public void DecrementTime()
        {
            if (!this.timer.GameOver)
            {
                if (this.timer.TimeLeft > 0)
                {
                    this.timer.TimeLeft--;
                }
                else
                {
                    this.timer.GameOver = true;
                    this.game.Character.Blocked = true;
                    this.scoreboardService.AddScore(this.game.PlayerName, this.game.Score.CurrentScore, this.game.Score.MaxComboCount);
                    this.ShowGameOver();
                }
            }
        }

        public void ShowGameOver()
        {
            this.timer.GameOverBrush.Opacity = 1;
            this.timer.GameOverTextBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            this.game.Score.ComboCounter = 0;
        }

        public void Reset()
        {
            this.timer.GameOver = false;
            this.timer.GameOverBrush.Opacity = 0;
            this.timer.GameOverTextBrush = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            this.timer.TimeLeft = Config.GameLength;
        }
    }
}
