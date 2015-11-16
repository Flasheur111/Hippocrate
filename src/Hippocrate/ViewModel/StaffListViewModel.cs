﻿using GalaSoft.MvvmLight;
using System.Windows.Controls;
using Hippocrate.ServiceUser;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
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
    public class StaffListViewModel : ViewModelBase, IUserConnectedChangedEventHandler
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

        private ObservableCollection<ServiceUser.User> _stafflist;

        public ObservableCollection<ServiceUser.User>  StaffList
        {
            get
            {
                return _stafflist;
            }
            set
            {
                _stafflist = value;
                RaisePropertyChanged("StaffList");
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

                List<ServiceUser.User> filters = new List<ServiceUser.User>();
                foreach (ServiceUser.User u in BusinessManagement.User.GetUserList())
                    if (u.Firstname.Contains(value) || u.Name.Contains(value) || u.Role.ToString().Contains(value))
                        filters.Add(u);
                StaffList = new ObservableCollection<ServiceUser.User>(filters);

                RaisePropertyChanged("Search");
            }
        }

        private ServiceUser.User _selectedrecord;

        public ServiceUser.User SelectedRecord
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

        private ICommand _staffdetails;

        public ICommand StaffDetails
        {
            get { return _staffdetails; }
            set { _staffdetails = value; }
        }
        private string LoginUser;
        
        public StaffListViewModel()
        {
            WindowContent = new View.StaffListView();
            WindowContent.DataContext = this;

            BackCommand = new RelayCommand(() =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                vm.Window.DataContext = vm.Home;
            });

            StaffDetails = new RelayCommand(() =>
            {
                ViewModelLocator vm = new ViewModelLocator();
                vm.StaffSheet.UserSelectedEventHandler(SelectedRecord);
                vm.Window.DataContext = vm.StaffSheet;
            });

            StaffList = null;
            CanAdd = true;
        }

        

        public void UserListUpdate()
        {
            ServiceUser.User[] staff = BusinessManagement.User.GetUserList();
            StaffList = new ObservableCollection<ServiceUser.User>();
            foreach (ServiceUser.User u in staff)
            {
                if (u.Login != LoginUser)
                    StaffList.Add(u);
            }
        }

        public void UserConnectedChangedEventHandler(object sender, User e)
        {
            CanAdd = e.Role == "Infirmière" ? false : true;
            LoginUser = e.Login;

            UserListUpdate();
        }
    }
}