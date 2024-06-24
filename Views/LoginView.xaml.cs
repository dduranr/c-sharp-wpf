using System.Windows;
using System.Windows.Input;

namespace WPF_LoginForm.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Iniciando sesión...");
        }

        /// <summary>
        /// Este método gestiona la siguiente funcionalidad: Si el foco está sobre el campo USUARIO del formulario y se da enter, entonces se ejecuta la función asignada al submit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (btnLogin.Command != null && btnLogin.Command.CanExecute(null))
                {
                    btnLogin.Command.Execute(null);
                }
            }
        }
    }
}
