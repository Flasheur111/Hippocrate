using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using Hippocrate.ServiceUser;
using System.IO;

namespace Hippocrate.ViewModel
{
    public class SidebarViewModel : ViewModelBase, IUserConnectedChangedEventHandler
    {
        #region get/set
        private bool _connected;

        public bool Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                RaisePropertyChanged("Connected");
            }
        }

        private bool _canWrite;

        public bool CanWrite
        {
            get { return _canWrite; }
            set
            {
                if (_canWrite != value)
                {
                    _canWrite = value;
                    RaisePropertyChanged("CanWrite");
                }
            }
        }

        private string _displayedName;

        public string DisplayedName
        {
            get { return _displayedName; }
            set
            {
                _displayedName = value;
                RaisePropertyChanged("DisplayedName");
            }
        }

        private BitmapImage _picture;

        public BitmapImage Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                RaisePropertyChanged("Picture");
            }
        }

        private ICommand _accountCommand;

        public ICommand AccountCommand
        {
            get { return _accountCommand; }
            set { _accountCommand = value; }
        }

        private ICommand _logoutCommand;

        public ICommand LogoutCommand
        {
            get { return _logoutCommand; }
            set { _logoutCommand = value; }
        }

        private ICommand _homeCommand;

        public ICommand HomeCommand
        {
            get { return _homeCommand; }
            set { _homeCommand = value; }
        }

        private ViewModelLocator vml;
        #endregion

        public SidebarViewModel()
        {
            vml = new ViewModelLocator();
            Connected = false;

            AccountCommand = new RelayCommand(() =>
            {
                vml.Window.DataContext = vml.Account;
            }, () => Connected);

            LogoutCommand = new RelayCommand(() =>
            {
                vml.Window.DataContext = vml.Login;
                Connected = false;
            }, () => Connected);

            HomeCommand = new RelayCommand(() =>
            {
                vml.Window.DataContext = vml.Home;
            }, () => Connected);
        }

        public void UserConnectedChangedEventHandler(object sender, User e)
        {
            Connected = true;
            // Update name displayed
            DisplayedName = e.Firstname + " " + e.Name;

            // Update image displayed
            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream memory = new MemoryStream(e.Picture))
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
            // Update user image
            Picture = bitmapImage;

            // Update user rights
            CanWrite = !(e.Role == "Infirmière");
        }
    }
}
