using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EmergencyDispatchSystem.Server
{
    class MessageHelper : BaseScript
    {
        public MessageHelper()
        {
            EventHandlers["EDS:DisplayDispatchNotificationForAll"] += new Action<int, string, Vector2>(DisplayDispatchNotificationForAll);
        }

        public void DisplayDispatchNotificationForAll(int serviceType, string message, Vector2 callLocation)
        {
            TriggerClientEvent("EDS:DisplayDispatchNotification", serviceType, message, callLocation);
        }
    }
}
