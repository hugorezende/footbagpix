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

        // this is a test comment for hugo branch

        GameModel gameModel;
        BallLogic ballLogic;
        CharacterLogic characterLogic;
        GameRenderer render;
        DispatcherTimer tickTimer;

        public GameControl()
        {
            Loaded += GameScreen_Loaded;
        }

        private void GameScreen_Loaded(object sender, RoutedEventArgs e)
        {
            gameModel = new GameModel();
            ballLogic = new BallLogic(gameModel.Ball);
            characterLogic = new CharacterLogic(gameModel.Ball, gameModel.Character);

            render = new GameRenderer(gameModel);

            Window win = Window.GetWindow(this);
            if (win != null) // if (!IsInDesignMode)
            {
                tickTimer = new DispatcherTimer();
                tickTimer.Interval = TimeSpan.FromMilliseconds(20);
                tickTimer.Tick += timer_Tick;
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
                case Key.Space: characterLogic.TryHitBall(); break;
                case Key.Left: characterLogic.MoveLeft(); break;
                case Key.Right: characterLogic.MoveRight(); break;
                case Key.Escape: goToMainMenu(); break;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (render != null) render.DrawItens(drawingContext);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            ballLogic.DoGravity();
        }

        void goToMainMenu()
        {
            
            MainMenuWindow mainmenu = new MainMenuWindow();
            Application.Current.Windows[0].Close();
            mainmenu.Show();
        }

    }
}



