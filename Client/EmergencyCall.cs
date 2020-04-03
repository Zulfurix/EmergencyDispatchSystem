using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EmergencyDispatchSystem.Client
{
    class EmergencyCall : BaseScript
    {
        private Vector2 callLocation;
        private string callMessage;
        private DispatchNotificationType serviceType;
        private string callTime;

        public EmergencyCall(Vector2 callLocation, string callMessage, DispatchNotificationType serviceType, string callTime)
        {
            this.callLocation = callLocation;
            this.callMessage = callMessage;
            this.serviceType = serviceType;
            this.callTime = callTime;

            // Store the call in the call log
            CallHelper.StoreCall(this);
        }

        public string GetTime()
        {
            return callTime;
        }

        public Vector2 GetLocation()
        {
            return callLocation;
        }

        public string GetMessage()
        {
            return callMessage;
        }

        public DispatchNotificationType GetServiceType()
        {
            return serviceType;
        }
    }
}
