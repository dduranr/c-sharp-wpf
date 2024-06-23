using FontAwesome.Sharp;
using System.Threading;
using System.Windows.Input;
using WPF_LoginForm.Models;
using WPF_LoginForm.Repositories;

namespace WPF_LoginForm.ViewModels
{
    /// <summary>
    /// Esta clase corresponde con el modelo de vista de la ventana principal.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private UserAccountModel _currentUserAccount;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        private IUserRepository userRepository;

        // Propiedades
        public UserAccountModel CurrentUserAccount
        {
            get
            {
                return _currentUserAccount;
            }

            set
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                // Cada vez que se establece el valor, notificamos que la propiedad ha cambiado para así actualizar la vista 
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        // COMANDOS. Cada vez que se ejecuta un comando se crea una nueva instancia en la propiedad vista secundaria actual. Esto implica que se pierdan/borran todos los cambios hechos en una sección del admin, por ejemplo si se pone texto en un campo de texto, ese texto se borra
        // Comando 1. Para mostrar la vista de inicio
        public ICommand ShowHomeViewCommand { get; }
        // Comando 2. Para mostrar la vista de clientes
        public ICommand ShowCustomerViewCommand { get; }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();

            // Se inicializan comandos (en estos casos no hay razón para poner reglas de validación para mostrar las vistas)
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

            // Se establece la vista predeterminada
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            CurrentChildView = new HomeViewModel();
            Caption = "Dashboard";
            Icon = IconChar.Home;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            CurrentChildView = new CustomerViewModel();
            Caption = "Clientes";
            Icon = IconChar.UserGroup;
        }

        private void LoadCurrentUserData()
        {
            // En el método ExecuteLoginCommand de LoginViewModel.cs se guardó el username del usuario que inicia sesión, en Thread.CurrentPrincipal. Con este dato ya podemos aquí recuperar todos los datos del usuario logueado.
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Bienvenido, {user.Name} {user.LastName}";
                CurrentUserAccount.ProfilePicture = null;
            }
            else
            {
                CurrentUserAccount.DisplayName = "Usuario inválido, no logueado";
                //Hide child views.
            }
        }
    }
}