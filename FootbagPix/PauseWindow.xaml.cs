namespace FootbagPix
{
    using System.Windows;
    using System.Windows.Input;
    using FootbagPix.Control;
    using FootbagPix.Repository;

    /// <summary>
    /// Interaction logic for PauseWindow.xaml
    /// </summary>
    public partial class PauseWindow : Window
    {
        readonly GameControl gameControl;
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
            repository.Add(gameControl.GameModel);
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
