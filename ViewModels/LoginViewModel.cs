using System;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows.Input;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;

namespace WPF_LoginForm.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Se definenn propiedades para enlazar la vista con el modelo de vista
        private string _username;
        private SecureString _password;
        private string _errorMesage;
        private bool _isViewVisible = true;

        private IUserRepository userRepository; // Ésta no es una propiedad sino el modelo de usuario

        // Cada vez que se use un setter, o sea, cada vez que se establezca valor a una propiedad, debemos notificar que el valor de la propiedad ha cambiado, es decir, generar un evento. Para lo cual usamos el método OnPropertyChanged de la clase base ViewModelBase.
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                // El 1er argumento debe ser el nombre de la propiedad. Se puede poner a mano o usando nameof:
                //      "Username"
                //      nameof(Username)
                OnPropertyChanged(nameof(Username));
            }
        }
        public SecureString Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public string ErrorMesage
        {
            get => _errorMesage;
            set
            {
                _errorMesage = value;
                OnPropertyChanged(nameof(ErrorMesage));
            }
        }
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set
            {
                _isViewVisible = value;
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }


        // Se definen propiedades de tipo comando para ejecutar las acciones del usuario. Por ejemplo, un comando para ejecutar el inicio de sesión del usuario. Sólo se define el getter, no el setter, ya que no tiene sentido que la vista establezca la acción del comando.
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }


        // En el constructor inicializamos los comandos.
        public LoginViewModel()
        {
            userRepository = new UserRepository();
            // Al ViewModelCommand() se le envían 2 argumentos: un delegado que contenga la función a ejecutar cuando se dispare el evento, y el predicado, para ver si se puede ejecutar el comando, es decir, la función que verificará si las reglas se cumplen para activar/desactivar el control (por ejemplo, se activará el botón para ingresar hasta que los campos estén completados). Sin embargo, que no necesitan verificar reglas para activar controles, como el de recuperar passwrod que simplemente es un link que dirige al formulario para recuperar contraseña
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
        }

        // Delegados. Estos métodos son los que se delegan a los comandos. El argumento "object obj" es opcional.
        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                return false;
            }
            return true;
        }

        private void ExecuteLoginCommand(object obj)
        {
            var isValidUser = userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            // Si el usuario es válido vamos a registrar y guardar el nombre de usuario para después mostrar sus datos en la vista principal. Para esto se usará la propiedad Thread.CurrentPrincipal. Ésta permite establecer la identidad del usuario que ejecuta el subproceso actual. El 2do argumento de GenericPrincipal es para trabajar los roles. Es decir, en Thread.CurrentPrincipal se guarda el username de quien inicia sesión, ya con ese dato guardado en memoria, más adelante se podrá recuperar de la BD la info del usuario logueado, por ejemplo en el método LoadCurrentUserData de MainViewModel.
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false; // Ocultamos la vista de login
            }
            else
            {
                ErrorMesage = "* El usuario y/o contraseña no son válidos.";
            }
        }
        private void ExecuteRecoverPassCommand(string username, string email)
        {
            throw new NotImplementedException();
        }




    }
}
