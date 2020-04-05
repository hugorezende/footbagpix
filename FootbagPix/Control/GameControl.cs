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
        BallModel ballModel;
        BallLogic ballLogic;
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
            render = new GameRenderer(gameModel);

            Window win = Window.GetWindow(this);
            if (win != null) // if (!IsInDesignMode)
            {
                tickTimer = new DispatcherTimer();
                tickTimer.Interval = TimeSpan.FromMilliseconds(25);
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
                case Key.Space: ballLogic.KickBall(); break;
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

    }
}



