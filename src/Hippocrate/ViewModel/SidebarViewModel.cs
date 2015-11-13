using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Hippocrate.ViewModel
{
    public class SidebarViewModel : ViewModelBase
    {
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

        private string _backcolor;

        public string BackColor
        {
            get { return _backcolor; }
            set
            {
                _backcolor = value;
                RaisePropertyChanged("BackColor");
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

        public SidebarViewModel()
        {
            BackColor = "#404040";
            Connected = false;
            AccountCommand = new RelayCommand(() => { /* Fixme */ }, () => Connected);
            LogoutCommand = new RelayCommand(() => {
                ViewModelLocator vm = new ViewModelLocator();
                vm.Login.User = null;
                vm.Login.Login = "";
                vm.Login.Password = "";
                BackColor = "#404040";
                vm.Window.DataContext = vm.Login;
                Connected = false; }, () => Connected);
            
        }


    }
}
