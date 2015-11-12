using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Controls;
using System.Windows.Input;

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
                }
            }
        }


        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public LoginViewModel()
        {
            Login = "";
            Password = "";

            _connectionCommand = new RelayCommand(async () => {
                bool isConnected = await BusinessManagement.User.ConnectAsync(Login, Password);
                if (isConnected)
                {
                    ViewModelLocator vml = new ViewModelLocator();
                    vml.Sidebar.DisplayedName = "lol";
                    vml.Sidebar.Picture = new System.Drawing.Bitmap(100, 100);
                    vml.Sidebar.Connected = true;

                    vml.Window.DataContext = vml.Home;
                }
            }, () => Password.Length > 0 && Login.Length > 0);

            WindowContent = new View.LoginView();
            WindowContent.DataContext = this;
            
        }
    }
}