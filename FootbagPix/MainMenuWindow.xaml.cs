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
using System.Windows.Shapes;

namespace FootbagPix
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Play_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Load button clicked!");
        }

        private void Button_Scoreboard_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Scoreboard button clicked!");
        }

        private void Button_Controls_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Controls button clicked!");
        }

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
