using FootbagPix.Control;
using FootbagPix.Repository;
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
    /// Interaction logic for PauseWindow.xaml
    /// </summary>
    public partial class PauseWindow : Window
    {
        GameControl gameControl;
        public PauseWindow(GameControl gameControl)
        {
            InitializeComponent();
            this.gameControl = gameControl;
        }

        private void Button_Resume_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            gameControl.ResumeGame();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            GameModelRepository repository = new GameModelRepository("savedgames.xml");
            repository.Add(gameControl.gameModel);
            repository.SaveChanges();
            this.Close();
            gameControl.GoToMainMenu();
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
                gameControl.ResumeGame();
            }
        }
    }
}
