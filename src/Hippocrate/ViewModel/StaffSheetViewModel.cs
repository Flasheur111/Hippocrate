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
    public class StaffSheetViewModel : ViewModelBase
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
        /// <summary>
        /// Initializes a new instance of the StaffSheetViewModel class.
        /// </summary>
        public StaffSheetViewModel()
        {
            // WindowContent = new StaffSheetView();
            // WindowContent.DataContext = this;
        }
    }
}