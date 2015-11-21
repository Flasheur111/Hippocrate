using GalaSoft.MvvmLight;
using System.Windows.Controls;
using Hippocrate.ServiceUser;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;
using System.Globalization;

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
        /// 
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

        private string _addfirstname;

        public string AddFirstname
        {
            get { return _addfirstname; }
            set { _addfirstname = value; RaisePropertyChanged("AddFirstname"); }
        }

        private string _addname;

        public string AddName
        {
            get { return _addname; }
            set { _addname = value; RaisePropertyChanged("AddName"); }
        }


        private string _addBirthday;

        public string AddBirthday
        {
            get { return _addBirthday; }
            set { _addBirthday = value; RaisePropertyChanged("AddBirthday"); }
        }

        private bool _createerror;

        public bool CreateError
        {
            get { return _createerror; }
            set { _createerror = value; RaisePropertyChanged("CreateError"); }
        }
        #endregion



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

        public PatientListViewModel()
        {
            WindowContent = new View.PatientListView();
            WindowContent.DataContext = this;

            AddFirstname = "";
            AddName = "";
            AddBirthday = "";


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

            AddPatientCommand = new RelayCommand(() =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                CanViewAdd = !CanViewAdd;
            });

            CancelCommand = new RelayCommand(() =>
            {
                CancelPopup();
            });

            ValidateAddCommand = new RelayCommand(() =>
            {
                try
                {
                    DateTime date = DateTime.ParseExact(AddBirthday, "M/d/yyyy", CultureInfo.InvariantCulture);
                    if (AddFirstname != "" && AddName != "")
                    {
                        bool added = BusinessManagement.Patient.AddPatient(AddFirstname, AddName, date);
                        PatientListUpdate();
                        CancelPopup();
                    }
                }
                catch (Exception)
                {
                    CreateError = true;
                }
            });

            PatientsList = null;
            CanAdd = true;
            CanViewAdd = false;
        }

        public void CancelPopup()
        {
            AddFirstname = "";
            AddName = "";
            AddBirthday = "";
            CanViewAdd = false;
            CreateError = false;
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
