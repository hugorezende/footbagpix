namespace FootbagPix
{
    using System.Windows;
    using FootbagPix.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string PlayerName { get; set; }
        public GameModel GameModel { get; set; }
        public bool IsNewGame { get; set; }
        public MainWindow(string playerName)
        {
            InitializeComponent();
            PlayerName = playerName;
            IsNewGame = true;
        }

        public MainWindow(GameModel gameModel)
        {
            InitializeComponent();
            GameModel = gameModel;
            IsNewGame = false;
        }
    }
}
