// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Control
{
    using System;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using FootbagPix.Logic;
    using FootbagPix.Models;
    using FootbagPix.Renderer;

    public class GameControl : FrameworkElement
    {
        public GameModel GameModel;
        private BallLogic ballLogic;
        private CharacterLogic characterLogic;
        private TimerLogic timerLogic;
        private ScoreLogic scoreLogic;
        private GameRenderer render;
        private DispatcherTimer tickTimer;
        private DispatcherTimer tickTimerSeconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameScreen_Loaded;
        }

        private void GameScreen_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);

            if (win.IsNewGame)
            {
                this.GameModel = new GameModel(win.PlayerName);
                this.ballLogic = new BallLogic(this.GameModel.Ball);
                this.characterLogic = new CharacterLogic(this.GameModel.Ball, this.GameModel.Character, this.GameModel.Score, this.GameModel.Timer);
                this.scoreLogic = new ScoreLogic(this.GameModel.Score, this.GameModel.Ball);
                this.timerLogic = new TimerLogic(this.GameModel.Timer, this.GameModel);
            }
            else
            {
                this.GameModel = win.GameModel;
                this.ballLogic = new BallLogic(this.GameModel.Ball);
                this.characterLogic = new CharacterLogic(this.GameModel.Ball, this.GameModel.Character, this.GameModel.Score, this.GameModel.Timer);
                this.scoreLogic = new ScoreLogic(this.GameModel.Score, this.GameModel.Ball);
                this.timerLogic = new TimerLogic(this.GameModel.Timer, this.GameModel);
            }

            this.render = new GameRenderer(this.GameModel);

            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.tickTimerSeconds = new DispatcherTimer
                {
                    Interval = TimeSpan.FromMilliseconds(1000),
                };
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(20);

                this.tickTimer.Tick += this.Timer_Tick;
                this.tickTimerSeconds.Tick += this.Timer_Tick_Seconds;

                this.tickTimerSeconds.Start();
                this.tickTimer.Start();

                win.KeyDown += this.Win_KeyDown;
                win.KeyUp += this.Win_KeyUp;
            }

            ballLogic.RefreshScreen += (obj, args) => InvalidateVisual();
            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space: if (!e.IsRepeat) { scoreLogic.Increase(characterLogic.TryHitBall()); } break;
                case Key.Left: characterLogic.MoveLeft(); if (!e.IsRepeat) { characterLogic.movingRight = false; characterLogic.movingLeft = true; characterLogic.AnimateWalkLeft(); } break;
                case Key.Right: characterLogic.MoveRight(); if (!e.IsRepeat) { characterLogic.movingLeft = false; characterLogic.movingRight = true; characterLogic.AnimateWalkRight(); } break;
                case Key.Up: characterLogic.Turn(); break;
                case Key.Escape: if (GameModel.Timer.GameOver) { GoToMainMenu(); } else { PauseGame(); } break;
                case Key.Enter: if (GameModel.Timer.GameOver) StartNewGame(); break;
            }

        }
        private void Win_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: characterLogic.movingLeft = false; break;
                case Key.Right: characterLogic.movingRight = false; break;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (render != null) render.DrawItems(drawingContext);
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            ballLogic.DoGravity();
            scoreLogic.CheckIfBallFell();
        }
        void Timer_Tick_Seconds(object sender, EventArgs e)
        {
            timerLogic.DecrementTime();
        }

        public void GoToMainMenu()
        {

            MainMenuWindow mainmenu = new MainMenuWindow();
            Application.Current.Windows[0].Close();
            mainmenu.Show();
        }

        void StartNewGame()
        {
            ballLogic.Reset();
            characterLogic.Reset();
            timerLogic.Reset();
            scoreLogic.Reset();
        }

        void PauseGame()
        {
            tickTimer.Stop();
            tickTimerSeconds.Stop();
            GameModel.Character.Blocked = true;
            PauseWindow pauseWindow = new PauseWindow(this)
            {
                Left = Window.GetWindow(this).Left + 104,
                Top = Window.GetWindow(this).Top + 160
            };
            pauseWindow.Show();
        }

        public void ResumeGame()
        {
            tickTimer.Start();
            tickTimerSeconds.Start();
            GameModel.Character.Blocked = false;
        }

    }
}



