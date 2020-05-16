// <copyright file="NewGameWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for NewGameWindow.xaml.
    /// </summary>
    public partial class NewGameWindow : Window
    {
        public NewGameWindow()
        {
            this.InitializeComponent();
            this.PlayerName = string.Empty;
        }

        public string PlayerName { get; set; }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainmenuWindow = new MainMenuWindow
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = this.Left,
                Top = this.Top - 150,
            };
            mainmenuWindow.Show();
            this.Close();
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            if (this.PlayerName.Length > 2)
            {
                MainWindow mainWindow = new MainWindow(this.PlayerName)
                {
                    Left = this.Left,
                    Top = this.Top - 150,
                };
                mainWindow.Show();
                this.Close();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.NewGameTextBox.Text = string.Concat(this.NewGameTextBox.Text.Where(char.IsLetterOrDigit));
            this.NewGameTextBox.SelectionStart = this.NewGameTextBox.Text.Length + 1;
            this.PlayerName = this.NewGameTextBox.Text.ToUpper();
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
            if (e.Key == Key.Enter)
            {
                if (this.PlayerName.Length > 2)
                {
                    MainWindow mainWindow = new MainWindow(this.PlayerName)
                    {
                        Left = this.Left,
                        Top = this.Top - 150,
                    };
                    mainWindow.Show();
                    this.Close();
                }
            }
        }

        private void NewGameTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            this.NewGameTextBox.Focus();
        }
    }
}
