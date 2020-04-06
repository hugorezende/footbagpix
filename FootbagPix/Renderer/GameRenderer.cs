using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FootbagPix.Renderer
{
    class GameRenderer
    {
        GameModel gameModel;

        static SolidColorBrush colorRed = new SolidColorBrush(Color.FromArgb(10, 255, 0, 0));
        static SolidColorBrush colorBlue = new SolidColorBrush(Color.FromArgb(10, 0, 0, 255));
        static Pen defaultPen = new Pen(colorBlue, 0);

        public GameRenderer(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public void DrawItens(DrawingContext ctx)
        {

            
            DrawCharacter(ctx);
            ctx.DrawRectangle(gameModel.Ball.imageBrush, defaultPen, gameModel.Ball.Area);

        }

        private void DrawCharacter(DrawingContext ctx)
        {
            
            ctx.DrawRectangle(colorBlue, defaultPen, new RectangleGeometry(gameModel.Character.LeftFoot).Rect);
            ctx.DrawRectangle(colorBlue, defaultPen, new RectangleGeometry(gameModel.Character.RigthFoot).Rect);
            
            ctx.DrawRectangle(gameModel.Character.imageBrush, defaultPen, new Rect(gameModel.Character.PositionX, 100, 95, 214));
        }
    }
}
