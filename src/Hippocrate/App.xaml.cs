using Hippocrate.DataAccess;
using Hippocrate.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;

namespace Hippocrate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    /// 

    public partial class App : Application
    {
        public App()
        {}

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModelLocator vm = new ViewModelLocator();

            #region event handling init
            vm.Login.UserChangedEventHandler += vm.Account.UserConnectedChangedEventHandler;
            vm.Login.UserChangedEventHandler += vm.Home.UserConnectedChangedEventHandler;
            vm.Login.UserChangedEventHandler += vm.PatientSheet.UserConnectedChangedEventHandler;
            vm.Login.UserChangedEventHandler += vm.Sidebar.UserConnectedChangedEventHandler;
            vm.Login.UserChangedEventHandler += vm.StaffListView.UserConnectedChangedEventHandler;
            vm.Login.UserChangedEventHandler += vm.StaffSheet.UserConnectedChangedEventHandler;
            vm.Login.UserChangedEventHandler += vm.PatientList.UserConnectedChangedEventHandler;
            #endregion

            LoginViewModel loginViewModel = vm.Login;

            vm.Window.sidebar.DataContext = vm.Sidebar;
            vm.Window.DataContext = loginViewModel;
            vm.Window.Show();
        }
        
    }
}
