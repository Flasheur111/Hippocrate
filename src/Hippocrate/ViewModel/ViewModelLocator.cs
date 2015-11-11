/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Hippocrate"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Hippocrate.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<AddPatientViewModel>();
            SimpleIoc.Default.Register<AddStaffViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<PatientSheetViewModel>();
            SimpleIoc.Default.Register<PatientsListViewModel>();
            SimpleIoc.Default.Register<StaffListViewModel>();
            SimpleIoc.Default.Register<StaffSheetViewModel>();
        }

        public AddPatientViewModel AddPatient
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddPatientViewModel>();
            }
        }

        public AddStaffViewModel addStaff
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddStaffViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public PatientSheetViewModel PatientSheet
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PatientSheetViewModel>();
            }
        }

        public StaffListViewModel StaffList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StaffListViewModel>();
            }
        }

        public StaffSheetViewModel StaffSheet
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StaffSheetViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}