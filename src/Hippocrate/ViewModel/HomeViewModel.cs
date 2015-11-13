using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace Hippocrate.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class HomeViewModel : ViewModelBase
    {
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

        private string _tbutton1;
        public string TButton1
        {
            get { return _tbutton1; }
            set
            {
                _tbutton1 = value;
                RaisePropertyChanged("TButton1");
            }
        }

        private string _dbutton1;
        public string DButton1
        {
            get { return _dbutton1; }
            set
            {
                _dbutton1 = value;
                RaisePropertyChanged("DButton1");
            }
        }

        private string _tbutton2;
        public string TButton2
        {
            get { return _tbutton2; }
            set
            {
                _tbutton2 = value;
                RaisePropertyChanged("TButton2");
            }
        }

        private string _dbutton2;
        public string DButton2
        {
            get { return _dbutton2; }
            set
            {
                _dbutton2 = value;
                RaisePropertyChanged("DButton2");
            }
        }

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public HomeViewModel()
        {
            TButton1 = "";
            TButton2 = "";
            DButton1 = "";
            DButton2 = "";
            WindowContent = new View.HomeView();
            WindowContent.DataContext = this;
        }
    }
}