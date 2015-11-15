using GalaSoft.MvvmLight;
using System.Windows.Controls;
using Hippocrate.ServiceUser;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Hippocrate.ViewModel
{
    public class PatientListViewModel : ViewModelBase, IUserConnectedChangedEventHandler
    {
        /// <summary>
        /// This class contains properties that a View can data bind to.
        /// <para>
        /// See http://www.galasoft.ch/mvvm
        /// </para>
        /// </summary>
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

        private bool _canadd;

        public bool CanAdd
        {
            get
            {
                return _canadd;
            }
            set
            {
                _canadd = value;
                RaisePropertyChanged("CanAdd");
            }
        }

        private ObservableCollection<ServicePatient.Patient> _patientslist;

        public ObservableCollection<ServicePatient.Patient> PatientsList
        {
            get
            {
                return _patientslist;
            }
            set
            {
                _patientslist = value;
                RaisePropertyChanged("PatientsList");
            }
        }

        private string _search;

        public string Search
        {
            get {
                return _search;
            }
            set {
                _search = value;

                List<ServicePatient.Patient> filters = new List<ServicePatient.Patient>();
                foreach (ServicePatient.Patient p in BusinessManagement.Patient.GetListPatient())
                    if (p.Firstname.Contains(value) || p.Name.Contains(value) || p.Observations.Length.ToString().Contains(value))
                        filters.Add(p);
                PatientsList = new ObservableCollection<ServicePatient.Patient>(filters);

                RaisePropertyChanged("Search");
            }
        }

        private ServicePatient.Patient _selectedrecord;

        public ServicePatient.Patient SelectedRecord
        {
            get
            {
                return _selectedrecord;
            }
            set
            {
                _selectedrecord = value;
                RaisePropertyChanged("SelectedRecord");
            }
        }
        /// <summary>
        /// Initializes a new instance of the PatientListViewModel class.
        /// </summary>
        /// 
        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get { return _backCommand; }
            set { _backCommand = value; }
        }

        private ICommand _patientdetails;

        public ICommand PatientDetails
        {
            get { return _patientdetails; }
            set { _patientdetails = value; }
        }

        public PatientListViewModel()
        {
            WindowContent = new View.PatientListView();
            WindowContent.DataContext = this;

            BackCommand = new RelayCommand(() =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                vm.Window.DataContext = vm.Home;
            });

            PatientDetails = new RelayCommand(() =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                vm.PatientSheet.PatientSelectedEventHandler(SelectedRecord);
                vm.Window.DataContext = vm.PatientSheet;
            });

            PatientsList = null;
            CanAdd = true;
        }

        public void PatientListUpdate()
        {
            ServicePatient.Patient[] patients = BusinessManagement.Patient.GetListPatient();
            PatientsList = new ObservableCollection<ServicePatient.Patient>(new List<ServicePatient.Patient>(patients));
        }
    

        public void UserConnectedChangedEventHandler(object sender, User e)
        {
            CanAdd = e.Role == "Infirmière" ? false : true;

            PatientListUpdate();
        }
    }
}
