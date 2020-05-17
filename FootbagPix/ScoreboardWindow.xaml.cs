// <copyright file="ScoreboardWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    using System.Windows;
    using System.Windows.Input;
    using FootbagPix.Services;

    /// <summary>
    /// Interaction logic for ScoreboardWindow.xaml.
    /// </summary>
    public partial class ScoreboardWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardWindow"/> class.
        /// </summary>
        public ScoreboardWindow()
        {
            this.InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainmenuWindow = new MainMenuWindow
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = this.Left,
                Top = this.Top,
            };
            mainmenuWindow.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ScoreboardService scoreboardService = new ScoreboardService();
            this.ScoreboardList.ItemsSource = scoreboardService.ReadScores();
        }
    }
}
