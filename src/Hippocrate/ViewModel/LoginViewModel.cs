using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

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
            Password = "";
            _connectionCommand = new RelayCommand(async () =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                bool isConnected = await BusinessManagement.User.ConnectAsync(Login, Password);
                if (isConnected)
                {
                    // Set connected User
                    ServiceUser.User User = await BusinessManagement.User.GetUserAsync(Login);
                    _userChangedEventHandler(this, User);

                    // Switch view to home
                    vm.Window.DataContext = vm.Home;
                }
                else
                {
                    // Wrong pass dude !
                }
            }, () => Password.Length > 0 && Login.Length > 0);
            
            WindowContent = new View.LoginView();
            WindowContent.DataContext = this;
        }
    }
}