// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix
{
    using System.Windows;
    using FootbagPix.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(string playerName)
        {
            this.InitializeComponent();
            this.PlayerName = playerName;
            this.IsNewGame = true;
        }

        public MainWindow(GameModel gameModel)
        {
            this.InitializeComponent();
            this.GameModel = gameModel;
            this.IsNewGame = false;
        }

        public string PlayerName { get; set; }

        public GameModel GameModel { get; set; }

        public bool IsNewGame { get; set; }
    }
}
