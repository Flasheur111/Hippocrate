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
        {
            ServiceLiveManager liveManager = new ServiceLiveManager();
            ServiceObservationManager observationManager = new ServiceObservationManager();
            ServicePatientManager patientManager = new ServicePatientManager();
            ServiceUserManager userManager = new ServiceUserManager();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginViewModel loginViewModel = new ViewModelLocator().Login;
            View.MainView view = new View.MainView();

            view.DataContext = loginViewModel;
            view.Show();
        }
    }
}
