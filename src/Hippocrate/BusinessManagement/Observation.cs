using Hippocrate.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippocrate.BusinessManagement
{
    public static class Observation
    {
        public static bool AddObservation(int idPatient, ServiceObservation.Observation o)
        {
            ServiceObservation.ServiceObservationClient c = new ServiceObservation.ServiceObservationClient();
            return c.AddObservation(idPatient, o);
        }
    }
}
