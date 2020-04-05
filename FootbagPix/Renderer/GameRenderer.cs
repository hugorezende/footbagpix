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
        
        public GameRenderer(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public void DrawItens(DrawingContext ctx)
        {
            
            DrawingGroup drawingGroup = new DrawingGroup();
            SolidColorBrush colorRed = new SolidColorBrush(Color.FromArgb(255, 255, 0,0));

            GeometryDrawing ball = new GeometryDrawing(colorRed,
            new Pen(colorRed, 0),
            new RectangleGeometry(gameModel.Ball.Area) 
            );

            drawingGroup.Children.Add(ball);

            ctx.DrawDrawing(drawingGroup);
        }
    }
}
