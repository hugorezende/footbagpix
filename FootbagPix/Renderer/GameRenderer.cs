// <copyright file="GameRenderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Renderer
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using FootbagPix.Models;

    internal class GameRenderer
    {
        private static readonly SolidColorBrush ColorBlue = new SolidColorBrush(Color.FromArgb(100, 0, 0, 255));
        private static readonly Pen DefaultPen = new Pen(ColorBlue, 0);
        private static readonly ImageBrush BackgroundBrush = new ImageBrush(new BitmapImage(new Uri("pack://application:,,,/Resources/ImageResources/bg.png")));

        private readonly GameModel gameModel;

        private readonly Typeface joystixFont = new Typeface(new FontFamily(new Uri("pack://application:,,,/"), "./Resources/FontResources/#Joystix Monospace"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
        private Rect bgArea;

        public GameRenderer(GameModel gameModel)
        {
            this.gameModel = gameModel;
            this.bgArea = new Rect(0, 0, Config.WindowWidth, Config.WindowHeight);
        }

        public void DrawItems(DrawingContext ctx)
        {
            ctx.DrawRectangle(BackgroundBrush, DefaultPen, this.bgArea);
            this.DrawCharacter(ctx);
            this.DrawScore(ctx);
            ctx.DrawRectangle(this.gameModel.Ball.ImageBrush, DefaultPen, this.gameModel.Ball.Area);
            this.DrawTimer(ctx);
            this.DrawPlayerName(ctx);
        }

        private void DrawCharacter(DrawingContext ctx)
        {
            ctx.DrawRectangle(this.gameModel.Character.ImageBrush, DefaultPen, new Rect(this.gameModel.Character.PositionX, Config.WindowHeight - 280, 95, 214));
        }

        private void DrawTimer(DrawingContext ctx)
        {
            DrawingGroup dg = new DrawingGroup();
            FormattedText formattedText = new FormattedText(
                this.gameModel.Timer.TimeLeft.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                this.joystixFont,
                40,
                Brushes.Transparent,
                96);
            GeometryDrawing text = new GeometryDrawing(
                Brushes.Black,
                new Pen(Brushes.Black, 2),
                formattedText.BuildGeometry(new Point((Config.WindowWidth - formattedText.Width) / 2, 5)));
            dg.Children.Add(text);
            ctx.DrawDrawing(dg);

            // Game over image
            ctx.DrawRectangle(this.gameModel.Timer.GameOverBrush, DefaultPen, new Rect(
                    (Config.WindowWidth - this.gameModel.Timer.GameOverBrush.ImageSource.Width) / 2,
                    100,
                    this.gameModel.Timer.GameOverBrush.ImageSource.Width,
                    this.gameModel.Timer.GameOverBrush.ImageSource.Height));

            // Game over text
            DrawingGroup gameOverTextDrawing = new DrawingGroup();

            FormattedText formattedEnterToNewGame = new FormattedText(
                "Press 'Enter' to start a new game!",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                this.joystixFont,
                20,
                Brushes.Transparent,
                96);
            GeometryDrawing enterToNewGameText = new GeometryDrawing(
                this.gameModel.Timer.GameOverTextBrush,
                new Pen(this.gameModel.Timer.GameOverTextBrush, 2),
                formattedEnterToNewGame.BuildGeometry(
                    new Point((Config.WindowWidth - formattedEnterToNewGame.Width) / 2, 120 + this.gameModel.Timer.GameOverBrush.ImageSource.Height)));

            FormattedText formattedEscToLeaveGame = new FormattedText(
                "Press 'ESC' to leave the game!",
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                this.joystixFont,
                20,
                Brushes.Transparent,
                96);
            GeometryDrawing escToLeaveGameText = new GeometryDrawing(
                this.gameModel.Timer.GameOverTextBrush,
                new Pen(this.gameModel.Timer.GameOverTextBrush, 2),
                formattedEscToLeaveGame.BuildGeometry(
                    new Point((Config.WindowWidth - formattedEscToLeaveGame.Width) / 2, 120 + this.gameModel.Timer.GameOverBrush.ImageSource.Height + formattedEnterToNewGame.Height)));

            // Game over max combo
            FormattedText formattedMaxCombo = new FormattedText(
                "Max combo:" + this.gameModel.Score.MaxComboCount,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                this.joystixFont,
                20,
                Brushes.Transparent,
                96);
            GeometryDrawing maxComboText = new GeometryDrawing(
                this.gameModel.Timer.GameOverTextBrush,
                new Pen(this.gameModel.Timer.GameOverTextBrush, 1),
                formattedMaxCombo.BuildGeometry(
                    new Point(Config.WindowWidth - formattedMaxCombo.Width - 5, formattedMaxCombo.Height + 20)));

            gameOverTextDrawing.Children.Add(enterToNewGameText);
            gameOverTextDrawing.Children.Add(escToLeaveGameText);
            gameOverTextDrawing.Children.Add(maxComboText);
            ctx.DrawDrawing(gameOverTextDrawing);
        }

        private void DrawScore(DrawingContext ctx)
        {
            DrawingGroup scoreDrawing = new DrawingGroup();
            DrawingGroup comboDrawing = new DrawingGroup();

            FormattedText formattedScoreText = new FormattedText(
                "Score:" + this.gameModel.Score.CurrentScore.ToString(),
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                this.joystixFont,
                40,
                Brushes.White,
                96);
            formattedScoreText.SetFontSize(24, 0, 6);
            GeometryDrawing scoreText = new GeometryDrawing(
                Brushes.Black,
                new Pen(Brushes.Black, 2),
                formattedScoreText.BuildGeometry(new Point(Config.WindowWidth - formattedScoreText.Width - 5, -5)));
            scoreDrawing.Children.Add(scoreText);

            if ((this.gameModel.Score.ComboCounter - 1) > 0)
            {
                FormattedText formattedComboText = new FormattedText(
                    this.gameModel.Score.ExtraInfo + " " + (this.gameModel.Score.ComboCounter - 1).ToString() + "x!",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.joystixFont,
                    24,
                    Brushes.White,
                    96);
                formattedComboText.SetFontWeight(FontWeights.ExtraBold, 0, formattedComboText.Text.Length);
                GeometryDrawing comboText = new GeometryDrawing(
                    Brushes.Red,
                    new Pen(Brushes.Black, 1),
                    formattedComboText.BuildGeometry(new Point(Config.WindowWidth - formattedComboText.Width - 10, -30)));
                comboDrawing.Children.Add(comboText);
                comboDrawing.Transform = new RotateTransform(7);
            }

            ctx.DrawDrawing(scoreDrawing);
            ctx.DrawDrawing(comboDrawing);
        }

        private void DrawPlayerName(DrawingContext ctx)
        {
            DrawingGroup playerNameDrawing = new DrawingGroup();

            FormattedText formattedPlayerNameText = new FormattedText(
                this.gameModel.PlayerName,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                this.joystixFont,
                24,
                Brushes.White,
                96);
            GeometryDrawing playerNameText = new GeometryDrawing(
                Brushes.Black,
                new Pen(Brushes.Black, 2),
                formattedPlayerNameText.BuildGeometry(new Point(5, 11)));
            playerNameDrawing.Children.Add(playerNameText);
            ctx.DrawDrawing(playerNameDrawing);
        }
    }
}
