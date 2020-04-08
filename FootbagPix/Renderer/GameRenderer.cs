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
        static SolidColorBrush colorBlue = new SolidColorBrush(Color.FromArgb(0, 0, 0, 255));
        static Pen defaultPen = new Pen(colorBlue, 0);

        private Rect bgArea;

        public GameRenderer(GameModel gameModel)
        {
            this.gameModel = gameModel;
            bgArea = new Rect(0, 0, Config.windowWidth, Config.windowHeight);
        }

        public void DrawItems(DrawingContext ctx, DpiScale dpiScale)
        {

            ctx.DrawRectangle(gameModel.BackgroundBrush, defaultPen, bgArea);
            DrawCharacter(ctx);
            DrawScore(ctx, dpiScale);
            ctx.DrawRectangle(gameModel.Ball.imageBrush, defaultPen, gameModel.Ball.Area);

        }

        private void DrawCharacter(DrawingContext ctx)
        {
            
            ctx.DrawRectangle(colorBlue, defaultPen, new RectangleGeometry(gameModel.Character.LeftFoot).Rect);
            ctx.DrawRectangle(colorBlue, defaultPen, new RectangleGeometry(gameModel.Character.RigthFoot).Rect);
            ctx.DrawRectangle(gameModel.Character.imageBrush, defaultPen, new Rect(gameModel.Character.PositionX, Config.windowHeight - 280, 95, 214));
        }

        private void DrawScore(DrawingContext ctx, DpiScale dpiScale)
        {
            DrawingGroup scoreDrawing = new DrawingGroup();
            DrawingGroup comboDrawing = new DrawingGroup();

            FormattedText formattedScoreText = new FormattedText("Score: " +gameModel.Score.CurrentScore.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Segoe UI"),
                32,
                Brushes.White,
                dpiScale.PixelsPerDip);
            formattedScoreText.SetFontSize(28, 0, 5);
            GeometryDrawing scoreText = new GeometryDrawing(Brushes.White, new Pen(Brushes.White, 2),
                formattedScoreText.BuildGeometry(new Point(Config.windowWidth - formattedScoreText.Width - 5, -5)));
            scoreDrawing.Children.Add(scoreText);

            
            if ((gameModel.Score.ComboCounter - 1) > 0)
            {
                FormattedText formattedComboText = new FormattedText((gameModel.Score.ComboCounter - 1).ToString() + "x !",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Segoe UI"),
                    32,
                    Brushes.White,
                    dpiScale.PixelsPerDip);
                formattedComboText.SetFontWeight(FontWeights.ExtraBold, 0, formattedComboText.Text.Length);
                GeometryDrawing comboText = new GeometryDrawing(Brushes.Red, new Pen(Brushes.Black, 1),
                    formattedComboText.BuildGeometry(new Point(Config.windowWidth - formattedComboText.Width - 10, -100)));
                comboDrawing.Children.Add(comboText);
                comboDrawing.Transform = new RotateTransform(10);
            }
            
            ctx.DrawDrawing(scoreDrawing);
            ctx.DrawDrawing(comboDrawing);
        }
    }
}
