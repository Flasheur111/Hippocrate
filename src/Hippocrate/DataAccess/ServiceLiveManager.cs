using Hippocrate.Interface;
using System;
using System.ServiceModel;

namespace Hippocrate.DataAccess
{
    [CallbackBehaviorAttribute(UseSynchronizationContext = false)]
    public class ServiceLiveCallback : IServiceLiveCallback
    {
        public void PushDataHeart(double requestData)
        {
            //Console.WriteLine(requestData);
        }

        public void PushDataTemp(double requestData)
        {
            //Console.WriteLine(requestData);
        }
    }

    public class ServiceLiveManager
    {
        private InstanceContext _ic;
        private ServiceLiveClient _client;
        public ServiceLiveManager()
        {
            this._ic = new InstanceContext(new ServiceLiveCallback());
            this._client = new ServiceLiveClient(this._ic, "WSDualHttpBinding_IServiceLive", "http://localhost:3055/ServiceLive.svc");
            this._client.Subscribe();
        }
    }
}