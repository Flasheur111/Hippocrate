using GalaSoft.MvvmLight;
using System.Windows.Controls;
using Hippocrate.ServiceUser;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace Hippocrate.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class HomeViewModel : ViewModelBase, IUserConnectedChangedEventHandler
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

        private ICommand _patientconsult;
        public ICommand PatientConsult
        {
            get { return _patientconsult; }
            set
            {
                _patientconsult = value;
                RaisePropertyChanged("PatientConsult");
            }
        }

        /// <summary>
        /// Initializes a new instance of the LoginViewModel class.
        /// </summary>
        public HomeViewModel()
        {
            WindowContent = new View.HomeView();
            WindowContent.DataContext = this;

            PatientConsult = new RelayCommand(() =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                vm.Window.DataContext = vm.PatientList;
            });
        }
        

        public void UserConnectedChangedEventHandler(object sender, User e)
        {
            if (e.Role != "Infirmière")
            {
                DButton1 = "Vous pouvez lire, modifier et supprimer des fiches.";
            }
            else
            {
                DButton2 = "Vous pouvez lire des fiches.";
            }
        }
    }
}