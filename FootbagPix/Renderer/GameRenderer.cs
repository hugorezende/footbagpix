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

        Typeface GameplayFont = new Typeface(new FontFamily(new Uri("pack://application:,,,/"), "./Resources/FontResources/#Gameplay"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        Typeface GameOverFont = new Typeface(new FontFamily(new Uri("pack://application:,,,/"), "./Resources/FontResources/#Game Over"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        Typeface JoystixFont = new Typeface(new FontFamily(new Uri("pack://application:,,,/"), "./Resources/FontResources/#Joystix Monospace"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);

        public GameRenderer(GameModel gameModel)
        {
            this.gameModel = gameModel;
            bgArea = new Rect(0, 0, Config.windowWidth, Config.windowHeight);
        }

        public void DrawItems(DrawingContext ctx)
        {

            ctx.DrawRectangle(gameModel.BackgroundBrush, defaultPen, bgArea);
            DrawCharacter(ctx);
            DrawScore(ctx);
            ctx.DrawRectangle(gameModel.Ball.imageBrush, defaultPen, gameModel.Ball.Area);
            DrawTimer(ctx);
            DrawPlayerName(ctx);

        }

        private void DrawCharacter(DrawingContext ctx)
        {
            ctx.DrawRectangle(colorBlue, defaultPen, new RectangleGeometry(gameModel.Character.LeftFoot).Rect);
            ctx.DrawRectangle(colorBlue, defaultPen, new RectangleGeometry(gameModel.Character.RigthFoot).Rect);
            ctx.DrawRectangle(gameModel.Character.imageBrush, defaultPen, new Rect(gameModel.Character.PositionX, Config.windowHeight - 280, 95, 214));
        }
        private void DrawTimer(DrawingContext ctx)
        {
            DrawingGroup dg = new DrawingGroup();
            FormattedText formattedText = new FormattedText(gameModel.Timer.TimeLeft.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                JoystixFont,
                40,
                Brushes.Transparent,
                96);
            GeometryDrawing text = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 2),
                formattedText.BuildGeometry(new Point((Config.windowWidth - formattedText.Width) / 2, 5)));
            dg.Children.Add(text);
            ctx.DrawDrawing(dg);

            // Game over image

            ctx.DrawRectangle(gameModel.Timer.gameOverBrush, defaultPen,
                new Rect((Config.windowWidth - gameModel.Timer.gameOverBrush.ImageSource.Width) / 2,
                100,
                gameModel.Timer.gameOverBrush.ImageSource.Width,
                gameModel.Timer.gameOverBrush.ImageSource.Height));

            // Game over text

            DrawingGroup GameOverTextDrawing = new DrawingGroup();

            FormattedText formattedEnterToNewGame = new FormattedText("Press 'Enter' to start a new game!",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                JoystixFont,
                20,
                Brushes.Transparent,
                96);
            GeometryDrawing enterToNewGameText = new GeometryDrawing(gameModel.Timer.gameOverTextBrush, new Pen(gameModel.Timer.gameOverTextBrush, 2),
                formattedEnterToNewGame.BuildGeometry(new Point((Config.windowWidth - formattedEnterToNewGame.Width) / 2,
                120 + gameModel.Timer.gameOverBrush.ImageSource.Height)));

            FormattedText formattedEscToLeaveGame = new FormattedText("Press 'ESC' to leave the game!",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                JoystixFont,
                20,
                Brushes.Transparent,
                96);
            GeometryDrawing escToLeaveGameText = new GeometryDrawing(gameModel.Timer.gameOverTextBrush, new Pen(gameModel.Timer.gameOverTextBrush, 2),
                formattedEscToLeaveGame.BuildGeometry(new Point((Config.windowWidth - formattedEscToLeaveGame.Width) / 2,
                120 + gameModel.Timer.gameOverBrush.ImageSource.Height + formattedEnterToNewGame.Height)));

            // Game over max combo 

            FormattedText formattedMaxCombo = new FormattedText("Max combo:" + gameModel.Score.MaxComboCount,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                JoystixFont,
                20,
                Brushes.Transparent,
                96);
            GeometryDrawing maxComboText = new GeometryDrawing(gameModel.Timer.gameOverTextBrush, new Pen(gameModel.Timer.gameOverTextBrush, 1),
                formattedMaxCombo.BuildGeometry(new Point(Config.windowWidth - formattedMaxCombo.Width - 5,
                formattedMaxCombo.Height + 20)));

            GameOverTextDrawing.Children.Add(enterToNewGameText);
            GameOverTextDrawing.Children.Add(escToLeaveGameText);
            GameOverTextDrawing.Children.Add(maxComboText);
            ctx.DrawDrawing(GameOverTextDrawing);
        }


        private void DrawScore(DrawingContext ctx)
        {
            DrawingGroup scoreDrawing = new DrawingGroup();
            DrawingGroup comboDrawing = new DrawingGroup();

            FormattedText formattedScoreText = new FormattedText("Score:" +gameModel.Score.CurrentScore.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                JoystixFont,
                40,
                Brushes.White,
                96);
            formattedScoreText.SetFontSize(24, 0, 6);
            GeometryDrawing scoreText = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 2),
                formattedScoreText.BuildGeometry(new Point(Config.windowWidth - formattedScoreText.Width - 5, -5)));
            scoreDrawing.Children.Add(scoreText);

            
            if ((gameModel.Score.ComboCounter - 1) > 0)
            {
                FormattedText formattedComboText = new FormattedText((gameModel.Score.ComboCounter - 1).ToString() + "x!",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    JoystixFont,
                    30,
                    Brushes.White,
                    96);
                formattedComboText.SetFontWeight(FontWeights.ExtraBold, 0, formattedComboText.Text.Length);
                GeometryDrawing comboText = new GeometryDrawing(Brushes.Red, new Pen(Brushes.Black, 1),
                    formattedComboText.BuildGeometry(new Point(Config.windowWidth - formattedComboText.Width - 10, -80)));
                comboDrawing.Children.Add(comboText);
                comboDrawing.Transform = new RotateTransform(10);
            }
            
            ctx.DrawDrawing(scoreDrawing);
            ctx.DrawDrawing(comboDrawing);
        }

        private void DrawPlayerName(DrawingContext ctx)
        {
            DrawingGroup playerNameDrawing = new DrawingGroup();

            FormattedText formattedPlayerNameText = new FormattedText(gameModel.PlayerName,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                JoystixFont,
                24,
                Brushes.White,
                96);
            GeometryDrawing playerNameText = new GeometryDrawing(Brushes.Black, new Pen(Brushes.Black, 2),
                formattedPlayerNameText.BuildGeometry(new Point(5, 11)));
            playerNameDrawing.Children.Add(playerNameText);
            ctx.DrawDrawing(playerNameDrawing);
        }
    }
}
