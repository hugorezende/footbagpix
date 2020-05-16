// <copyright file="PauseWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    using System.Windows;
    using System.Windows.Input;
    using FootbagPix.Control;
    using FootbagPix.Repository;

    /// <summary>
    /// Interaction logic for PauseWindow.xaml.
    /// </summary>
    public partial class PauseWindow : Window
    {
        private readonly GameControl gameControl;

        public PauseWindow(GameControl gameControl)
        {
            this.InitializeComponent();
            this.gameControl = gameControl;
        }

        private void Button_Resume_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.gameControl.ResumeGame();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            GameModelRepository repository = new GameModelRepository("savedgames.xml");
            repository.Add(this.gameControl.GameModel);
            repository.SaveChanges();
            this.Close();
            this.gameControl.GoToMainMenu();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
                this.gameControl.ResumeGame();
            }
        }
    }
}
