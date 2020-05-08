using FootbagPix.Logic;
using FootbagPix.Models;
using FootbagPix.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace FootbagPix.Control
{
    public class GameControl : FrameworkElement
    {
        GameModel gameModel;
        BallLogic ballLogic;
        CharacterLogic characterLogic;
        TimerLogic timerLogic;
        ScoreLogic scoreLogic;
        GameRenderer render;
        DispatcherTimer tickTimer, tickTimerSeconds;

        public GameControl()
        {
            Loaded += GameScreen_Loaded;
        }

        private void GameScreen_Loaded(object sender, RoutedEventArgs e)
        {
            MainWindow win = (MainWindow)Window.GetWindow(this);

            gameModel = new GameModel(win.PlayerName);
            ballLogic = new BallLogic(gameModel.Ball);
            characterLogic = new CharacterLogic(gameModel.Ball, gameModel.Character, gameModel.Score, gameModel.Timer);
            scoreLogic = new ScoreLogic(gameModel.Score, gameModel.Ball);
            timerLogic = new TimerLogic(gameModel.Timer, gameModel);

            render = new GameRenderer(gameModel);

            if (win != null) // if (!IsInDesignMode)
            {
                tickTimer = new DispatcherTimer();
                tickTimerSeconds = new DispatcherTimer();
                tickTimerSeconds.Interval = TimeSpan.FromMilliseconds(1000);
                tickTimer.Interval = TimeSpan.FromMilliseconds(20);

                tickTimer.Tick += timer_Tick;
                tickTimerSeconds.Tick += timer_Tick_Seconds;

                tickTimerSeconds.Start();
                tickTimer.Start();

                win.KeyDown += Win_KeyDown;
            }
            ballLogic.RefreshScreen += (obj, args) => InvalidateVisual();
            InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.Space: if (!e.IsRepeat) { scoreLogic.Increase( characterLogic.TryHitBall() );  } break;
                case Key.Left: characterLogic.MoveLeft(); break;
                case Key.Right: characterLogic.MoveRight(); break;
                case Key.Up: characterLogic.Turn(); break;
                case Key.Escape: goToMainMenu(); break;
                case Key.Enter: if (gameModel.Timer.GameOver) startNewGame(); break;
            }

        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (render != null) render.DrawItems(drawingContext);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            ballLogic.DoGravity();
            scoreLogic.CheckIfBallFell();
        }
        void timer_Tick_Seconds(object sender, EventArgs e)
        {
            timerLogic.DecrementTime();
        }

        void goToMainMenu()
        {

            MainMenuWindow mainmenu = new MainMenuWindow();
            Application.Current.Windows[0].Close();
            mainmenu.Show();
        }

        void startNewGame()
        {
            ballLogic.Reset();
            characterLogic.Reset();
            timerLogic.Reset();
            scoreLogic.Reset();
        }

    }
}



