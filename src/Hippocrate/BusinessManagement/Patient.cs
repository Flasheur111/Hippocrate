using Hippocrate.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hippocrate.BusinessManagement
{
    public static class Patient
    {
        public static ServicePatient.Patient[] GetListPatient()
        {
            try
            {
                ServicePatientManager s = new ServicePatientManager();
                return s.GetListPatient();
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return null;
            }
        }

        public static bool DeletePatient(int id)
        {
            try
            {
                ServicePatientManager s = new ServicePatientManager();
                return s.DeletePatient(id);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return false;
            }
        }

        public static bool AddPatient(string firstname, string name, DateTime birthday)
        {
            try
            {
                ServicePatientManager s = new ServicePatientManager();

                ServicePatient.Patient p = new ServicePatient.Patient();
                p.Firstname = firstname;
                p.Name = name;
                p.Birthday = birthday;
                p.Observations = new ServicePatient.Observation[0];
                return s.AddPatient(p);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return false;
            }
        }

        public static ServicePatient.Patient GetPatient(int idPatient)
        {
            try
            {
                ServicePatientManager s = new ServicePatientManager();
                return s.GetPatient(idPatient);
            }
            catch (EndpointNotFoundException)
            {
                MessageBox.Show("Le serveur ne répond pas.", "Erreur");
                return null;
            }
        }

    }
}
