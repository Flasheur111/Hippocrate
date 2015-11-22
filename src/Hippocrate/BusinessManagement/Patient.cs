using Hippocrate.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippocrate.BusinessManagement
{
    public static class Patient
    {
        public static ServicePatient.Patient[] GetListPatient()
        {
            ServicePatientManager s = new ServicePatientManager();
            return s.GetListPatient();
        }

        public static bool DeletePatient(int id)
        {
            ServicePatientManager s = new ServicePatientManager();
            return s.DeletePatient(id);
        }

        public static bool AddPatient(string firstname, string name, DateTime birthday)
        {
            ServicePatientManager s = new ServicePatientManager();

            ServicePatient.Patient p = new ServicePatient.Patient();
            p.Firstname = firstname;
            p.Name = name;
            p.Birthday = birthday;
            p.Observations = new ServicePatient.Observation[0];
            return s.AddPatient(p);
        }

    }
}
