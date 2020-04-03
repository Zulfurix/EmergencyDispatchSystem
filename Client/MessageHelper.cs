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
            EventHandlers["EDS:DisplayDispatchNotification"] += new Action<int, string, Vector2>(DisplayDispatchNotification);
        }

        public static void DisplayDispatchNotification(int notificationType, string dispatchMessage, Vector2 callLocation)
        {
            // Get time call was made
            string recordedTime = GetClockHours() + ":" + GetClockMinutes();

            // Create the call object
            new EmergencyCall(callLocation, dispatchMessage, (DispatchNotificationType)notificationType, recordedTime);

            // Output information as notification
            SetNotificationTextEntry("STRING");
            AddTextComponentString(dispatchMessage);
            SetNotificationMessageClanTag_2("CHAR_CALL911", "CHAR_CALL911", false, 7, "~y~Dispatch", ConvertNotificationTypeToString((DispatchNotificationType)notificationType) + " ~w~(" + recordedTime + ")", 1.0f, "", 8, 1);
            DrawNotification(false, true);
        }

        public static string ConvertNotificationTypeToString(DispatchNotificationType type)
        {
            switch (type)
            {
                case DispatchNotificationType.POLICE:
                    return "~b~Police";
                case DispatchNotificationType.AMBULANCE:
                    return "~r~E~w~M~r~S";
                case DispatchNotificationType.FIRE:
                    return "~r~Fire";
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
