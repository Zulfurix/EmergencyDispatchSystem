using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;

namespace EmergencyDispatchSystem.Client
{
    class MessageHelper : BaseScript
    {
        public MessageHelper()
        {
            EventHandlers["EDS:DisplayDispatchNotification"] += new Action<int, string>(DisplayDispatchNotification);
        }

        public static void DisplayDispatchNotification(int notificationType, string dispatchMessage)
        {
            string recordedTime = GetClockHours() + ":" + GetClockMinutes();
            SetNotificationTextEntry("STRING");
            AddTextComponentString(dispatchMessage);
            SetNotificationMessageClanTag_2("CHAR_CALL911", "CHAR_CALL911", false, 7, "~y~Dispatch", ConvertNotificationTypeToString((DispatchNotificationType)notificationType) + " (" + recordedTime + ")", 1.0f, "", 8, 1);
            DrawNotification(false, true);
        }

        public static string ConvertNotificationTypeToString(DispatchNotificationType type)
        {
            switch (type)
            {
                case DispatchNotificationType.POLICE:
                    return "Police";
                case DispatchNotificationType.AMBULANCE:
                    return "EMS";
                case DispatchNotificationType.FIRE:
                    return "Fire";
            }
            return "Error";
        }
    }

    enum DispatchNotificationType
    {
        POLICE,
        AMBULANCE,
        FIRE
    }
}
