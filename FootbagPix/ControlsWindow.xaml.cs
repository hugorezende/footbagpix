// <copyright file="ControlsWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for ControlsWindow.xaml.
    /// </summary>
    public partial class ControlsWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ControlsWindow"/> class.
        /// </summary>
        public ControlsWindow()
        {
            this.InitializeComponent();
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
