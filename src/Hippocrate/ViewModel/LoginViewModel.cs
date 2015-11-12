using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

            _connectionCommand = new RelayCommand(async () =>
            {
                bool isConnected = await BusinessManagement.User.ConnectAsync(Login, Password);
                if (isConnected)
                {
                    ServiceUser.User u = await BusinessManagement.User.GetUserAsync(Login);
                    ViewModelLocator vml = new ViewModelLocator();
                    vml.Sidebar.DisplayedName = u.Firstname + " " + u.Name;
                    //vml.Sidebar.Picture = 

                    BitmapImage bitmapImage = new BitmapImage();
                    using (MemoryStream memory = new MemoryStream(u.Picture))
                    {
                        memory.Position = 0;
                        bitmapImage.BeginInit();
                        bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.UriSource = null;
                        bitmapImage.StreamSource = memory;
                        bitmapImage.EndInit();
                    }

                    bitmapImage.Freeze();

                    vml.Sidebar.Picture = bitmapImage;

                    vml.Sidebar.Connected = true;

                    vml.Window.DataContext = vml.Home;
                }
            }, () => Password.Length > 0 && Login.Length > 0);

            WindowContent = new View.LoginView();
            WindowContent.DataContext = this;

        }
    }
}