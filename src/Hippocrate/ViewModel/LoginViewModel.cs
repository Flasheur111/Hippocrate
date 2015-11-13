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

        private ServiceUser.User _user;

        public ServiceUser.User User
        {
            get { return _user; }
            set
            {
                if (_user != value)
                {
                    _user = value;
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
            User = null;

            _connectionCommand = new RelayCommand(async () =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                bool isConnected = await BusinessManagement.User.ConnectAsync(Login, Password);
                if (isConnected)
                {
                    // Set connected User
                    User = await BusinessManagement.User.GetUserAsync(Login);
                    vm.Sidebar.Connected = true;
                    // Update name displayed
                    vm.Sidebar.DisplayedName = User.Firstname + " " + User.Name;

                    // Update image displayed
                    BitmapImage bitmapImage = new BitmapImage();
                    using (MemoryStream memory = new MemoryStream(User.Picture))
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
                    vm.Sidebar.Picture = bitmapImage;

                    // Update Sidebar backcolor
                    if (User.Role == "Infirmière")
                    {
                        vm.Sidebar.BackColor = "#0097B6";

                        vm.Home.TButton1 = "Consulter les fiches du personnel";
                        vm.Home.DButton1 = "Vous pouvez lire des fiches.";

                        vm.Home.TButton2 = "Consulter les fiches des patients";
                        vm.Home.DButton2 = "Vous pouvez lire des fiches.";
                    }
                    else
                    {
                        vm.Sidebar.BackColor = "#B60000";

                        vm.Home.TButton1 = "Consulter les fiches du personnel";
                        vm.Home.DButton1 = "Vous pouvez lire, modifier et supprimer des fiches.";

                        vm.Home.TButton2 = "Consulter les fiches des patients";
                        vm.Home.DButton2 = "Vous pouvez lire, modifier et supprimer des fiches.";
                    }
                    

                    // Switch view to home
                    vm.Window.DataContext = vm.Home;
                }
            }, () => Password.Length > 0 && Login.Length > 0);

           

            WindowContent = new View.LoginView();
            WindowContent.DataContext = this;

        }
    }
}