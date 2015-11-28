using GalaSoft.MvvmLight;
using System.Windows.Controls;
using Hippocrate.ServiceUser;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Hippocrate.ViewModel
{
    public class PatientListViewModel : ViewModelBase, IUserConnectedChangedEventHandler
    {
        #region get/set
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

        private UserControl _addpatientcontent;

        public UserControl AddPatientContent
        {
            get { return _addpatientcontent; }
            set
            {
                _addpatientcontent = value;
                RaisePropertyChanged("AddPatientContent");
            }
        }

        private bool _canviewadd;

        public bool CanViewAdd
        {
            get { return _canviewadd; }
            set
            {
                _canviewadd = value;
                RaisePropertyChanged("CanViewAdd");
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
            get
            {
                return _search;
            }
            set
            {
                _search = value;

                List<ServicePatient.Patient> filters = new List<ServicePatient.Patient>();
                foreach (ServicePatient.Patient p in BusinessManagement.Patient.GetListPatient())
                    if (p.Firstname.Contains(value) || p.Name.Contains(value) || (p.Observations != null && p.Observations.Length.ToString().Contains(value)))
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


        private ICommand _addpatientcommand;

        public ICommand AddPatientCommand
        {
            get { return _addpatientcommand; }
            set { _addpatientcommand = value; }
        }

        private ICommand _cancelcommand;

        public ICommand CancelCommand
        {
            get { return _cancelcommand; }
            set { _cancelcommand = value; }
        }

        private ICommand _validateaddcommand;

        public ICommand ValidateAddCommand
        {
            get { return _validateaddcommand; }
            set { _validateaddcommand = value; }
        }

        private ViewModelLocator vml;
        #endregion

        public PatientListViewModel()
        {
            vml = new ViewModelLocator();

            BackCommand = new RelayCommand(() =>
            {
                vml.Window.DataContext = vml.Home;
            });

            PatientDetails = new RelayCommand(() =>
            {
                vml.PatientSheet.PatientSelectedEventHandler(SelectedRecord);
                vml.Window.DataContext = vml.PatientSheet;
            });

            AddPatientCommand = new RelayCommand(() =>
            {
                CanViewAdd = !CanViewAdd;
            });

            PatientsList = null;
            CanAdd = true;
            CanViewAdd = false;
            
            View.AddPatientView addPatientView = new View.AddPatientView();
            AddPatientContent = addPatientView;
            addPatientView.DataContext = vml.AddPatient;

            WindowContent = new View.PatientListView();
            WindowContent.DataContext = this;
        }
        
        public void PatientListUpdate()
        {
            ServicePatient.Patient[] patients = BusinessManagement.Patient.GetListPatient();
            if (patients != null)
                PatientsList = new ObservableCollection<ServicePatient.Patient>(new List<ServicePatient.Patient>(patients));
        }

        public void DissmissPopup()
        {
            CanViewAdd = false;
        }

        public void UserConnectedChangedEventHandler(object sender, User e)
        {
            CanAdd = e.Role == "Infirmière" ? false : true;
            PatientListUpdate();
        }
    }
}
