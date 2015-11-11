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
    public class PatientSheetViewModel : ViewModelBase
    {
        private UserControl _windowContent;

        public UserControl WindowContent
        {
            get { return _windowContent; }
            set
            {
                _windowContent = value;
                RaisePropertyChanged(nameof(WindowContent));
            }
        }

        /// <summary>
        /// Initializes a new instance of the PatientSheetViewModel class.
        /// </summary>
        public PatientSheetViewModel()
        {
            WindowContent = new View.PatientSheet();
            WindowContent.DataContext = this;
        }
    }
}