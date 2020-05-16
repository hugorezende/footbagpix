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
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Used in case a new game is started.
        /// </summary>
        /// <param name="playerName">The name of the player.</param>
        public MainWindow(string playerName)
        {
            this.InitializeComponent();
            this.PlayerName = playerName;
            this.IsNewGame = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// Used in case a saved game is loaded.
        /// </summary>
        /// <param name="gameModel">The GameModel object representing the game to be loaded in.</param>
        public MainWindow(GameModel gameModel)
        {
            this.InitializeComponent();
            this.GameModel = gameModel;
            this.IsNewGame = false;
        }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the GameModel object representing the game to be loaded in.
        /// Used in case a saved game is loaded.
        /// </summary>
        public GameModel GameModel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the game is new or loaded in.
        /// </summary>
        public bool IsNewGame { get; set; }
    }
}
