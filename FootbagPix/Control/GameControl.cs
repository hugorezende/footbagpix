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

        public void GoToMainMenu()
        {
            MainMenuWindow mainmenu = new MainMenuWindow();
            Application.Current.Windows[0].Close();
            mainmenu.Show();
        }

        public void ResumeGame()
        {
            this.tickTimer.Start();
            this.tickTimerSeconds.Start();
            this.GameModel.Character.Blocked = false;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.render != null)
            {
                this.render.DrawItems(drawingContext);
            }
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
                this.GameModel.Character.Blocked = false;
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

            this.ballLogic.RefreshScreen += (obj, args) => this.InvalidateVisual();
            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    if (!e.IsRepeat)
                    {
                        this.scoreLogic.Increase(this.characterLogic.TryHitBall());
                    }

                    break;
                case Key.Left:
                    this.characterLogic.MoveLeft(); if (!e.IsRepeat)
                    {
                        this.characterLogic.MovingRight = false;
                        this.characterLogic.MovingLeft = true;
                        this.characterLogic.AnimateWalkLeft();
                    }

                    break;
                case Key.Right:
                    this.characterLogic.MoveRight(); if (!e.IsRepeat)
                    {
                        this.characterLogic.MovingLeft = false;
                        this.characterLogic.MovingRight = true;
                        this.characterLogic.AnimateWalkRight();
                    }

                    break;
                case Key.Up: this.characterLogic.Turn(); break;
                case Key.Escape:
                    if (this.GameModel.Timer.GameOver)
                    {
                        this.GoToMainMenu();
                    }
                    else
                    {
                        this.PauseGame();
                    }

                    break;
                case Key.Enter:
                    if (this.GameModel.Timer.GameOver)
                    {
                        this.StartNewGame();
                    }

                    break;
            }
        }

        private void Win_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: this.characterLogic.MovingLeft = false; break;
                case Key.Right: this.characterLogic.MovingRight = false; break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.ballLogic.DoGravity();
            this.scoreLogic.CheckIfBallFell();
        }

        private void Timer_Tick_Seconds(object sender, EventArgs e)
        {
            this.timerLogic.DecrementTime();
        }

        public void StartNewGame()
        {
            this.ballLogic.Reset();
            this.characterLogic.Reset();
            this.timerLogic.Reset();
            this.scoreLogic.Reset();
        }

        private void PauseGame()
        {
            this.tickTimer.Stop();
            this.tickTimerSeconds.Stop();
            this.GameModel.Character.Blocked = true;
            PauseWindow pauseWindow = new PauseWindow(this)
            {
                Left = Window.GetWindow(this).Left + 200,
                Top = Window.GetWindow(this).Top + 100,
            };
            pauseWindow.Show();
        }
    }
}
