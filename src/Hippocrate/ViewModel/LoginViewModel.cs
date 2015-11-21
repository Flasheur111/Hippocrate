using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Windows.Controls;

namespace Hippocrate.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LoginViewModel : ViewModelBase
    {

        #region user changed event handler
        public event EventHandler<ServiceUser.User> UserChangedEventHandler
        {
            add { _userChangedEventHandler += value; }
            remove { _userChangedEventHandler -= value; }
        }
        private event EventHandler<ServiceUser.User> _userChangedEventHandler;
        #endregion

        private bool _loginError;

        public bool LoginError
        {
            get { return _loginError; }
            set
            {
                if (_loginError != value)
                {
                    _loginError = value;
                    RaisePropertyChanged("LoginError");
                }
            }
        }

        private RelayCommand _connectionCommand;

        public RelayCommand ConnectionCommand
        {
            get { return _connectionCommand; }
            set { _connectionCommand = value; }
        }


        private UserControl _windowContent;

        public UserControl WindowContent
        {
            get { return _windowContent; }
            set
            {
                _windowContent = value;
                RaisePropertyChanged("WindowContent");
            }
        }
        
        private string _login;

        public string Login
        {
            get { return _login; }
            set
            {
                if (_login != value)
                {
                    _login = value;
                    LoginError = false;
                }
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set
            {
                if (_password != value)
                {
                    _password = value;
                    LoginError = false;
                }
            }
        }
    

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel()
        {
            LoginError = false;

            //Debug hack
            Login = "fred";
            Password = "fred";

            _connectionCommand = new RelayCommand(async () =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                bool isConnected = await BusinessManagement.User.ConnectAsync(Login, Password);
                if (isConnected)
                {
                    // Set connected User
                    ServiceUser.User User = await BusinessManagement.User.GetUserAsync(Login);
                    _userChangedEventHandler(this, User);

                    // Reset error handling
                    LoginError = false;

                    // Switch view to home
                    vm.Window.DataContext = vm.Home;
                }
                else
                {
                    // Wrong pass dude !
                    LoginError = true;
                }
            }, () => CanLogin);

            WindowContent = new View.LoginView();
            WindowContent.DataContext = this;
        }

        public bool CanLogin
        {
            get { return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password); }
        }


    }
}