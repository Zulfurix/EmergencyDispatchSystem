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
            EventHandlers["EDS:DisplayDispatchNotificationForAll"] += new Action<int, string>(DisplayDispatchNotificationForAll);
        }

        public void DisplayDispatchNotificationForAll(int serviceType, string message)
        {
            TriggerClientEvent("EDS:DisplayDispatchNotification", serviceType, message);
        }
    }
}
