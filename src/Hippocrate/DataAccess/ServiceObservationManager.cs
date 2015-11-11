using Hippocrate.Interface;
using System;
using System.ServiceModel;
using Hippocrate.Dbo;
using System.Threading.Tasks;

namespace Hippocrate.DataAccess
{
    public class ServiceObservationManager : IServiceObservation
    {
        private ServiceObservationClient _client;
        public ServiceObservationManager()
        {
            this._client = new ServiceObservationClient("WSDualHttpBinding_IServiceObservation", "http://localhost:3055/ServiceObservation.svc");
        }

        public bool AddObservation(int idPatient, Observation obs)
        {
            return this._client.AddObservation(idPatient, obs);
        }

        public Task<bool> AddObservationAsync(int idPatient, Observation obs)
        {
            return this.AddObservationAsync(idPatient, obs);
        }
    }
}