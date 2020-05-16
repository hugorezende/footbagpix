namespace FootbagPix
{
    using System.Windows;
    using System.Windows.Input;

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
            NewGameWindow newGameWindow = new NewGameWindow
            {
                Left = this.Left,
                Top = this.Top + 150
            };
            newGameWindow.Show();
            this.Close();
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            LoadWindow loadWindow = new LoadWindow
            {
                Left = this.Left,
                Top = this.Top
            };
            loadWindow.Show();
            this.Close();
        }

        private void Button_Scoreboard_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Mouse.OverrideCursor = Cursors.Wait;
            });
            ScoreboardWindow scoreboardWindow = new ScoreboardWindow
            {
                Left = this.Left,
                Top = this.Top
            };
            scoreboardWindow.Show();
            Application.Current.Dispatcher.Invoke(() =>
            {
                Mouse.OverrideCursor = null;
            });
            this.Close();
        }

        private void Button_Controls_Click(object sender, RoutedEventArgs e)
        {
            ControlsWindow controlsWindow = new ControlsWindow
            {
                Left = this.Left,
                Top = this.Top
            };
            controlsWindow.Show();
            this.Close();
        }

        private void Button_Quit_Click(object sender, RoutedEventArgs e)
        {
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
