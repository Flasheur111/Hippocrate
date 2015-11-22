using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Windows.Input;

namespace Hippocrate.ViewModel
{
    public class AddPatientViewModel : ViewModelBase
    {
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


        private DateTime _addBirthday;

        public DateTime AddBirthday
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

        public AddPatientViewModel()
        {
            CancelCommand = new RelayCommand(() =>
            {
                CancelPopup();
            });

            ValidateAddCommand = new RelayCommand(() =>
            {
                    if (AddFirstname != "" && AddName != "" && AddBirthday != null)
                    {
                        bool added = BusinessManagement.Patient.AddPatient(AddFirstname, AddName, AddBirthday);
                        PatientListUpdate();
                        CancelPopup();
                    }
                    else
                        CreateError = true;
            });
        }

        public void CancelPopup()
        {
                        ViewModelLocator vml = new ViewModelLocator();
            AddFirstname = "";
            AddName = "";
            CreateError = false;

            vml.PatientList.DissmissPopup();
        }

        public void PatientListUpdate()
        {
            ViewModelLocator vml = new ViewModelLocator();
            vml.PatientList.PatientListUpdate();
        }
    }
}
