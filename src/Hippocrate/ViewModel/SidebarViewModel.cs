using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                RaisePropertyChanged("DisplayName");
            }
        }

        private Bitmap _picture;

        public Bitmap Picture
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

        public SidebarViewModel()
        {
            Connected = false;
            AccountCommand = new RelayCommand(() => { /* Fixme */ }, () => Connected);
            LogoutCommand = new RelayCommand(() => { /* Fixme */}, () => Connected);
        }


    }
}
