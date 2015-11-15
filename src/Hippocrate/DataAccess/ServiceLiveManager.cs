using Hippocrate.ServiceLive;
using System.ServiceModel;

namespace Hippocrate.DataAccess
{
    public class ServiceLiveManager
    {
        private InstanceContext _ic;
        private ServiceLiveClient _client;
        public ServiceLiveManager(IServiceLiveCallback i)
        {
            this._ic = new InstanceContext(i);
            this._client = new ServiceLiveClient(this._ic);
            this._client.Subscribe();
        }
    }
}