using FootbagPix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootbagPix
{
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
