using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
namespace EmergencyDispatchSystem.Client
{
    class CallHelper : BaseScript
    {
        private static List<EmergencyCall> CallLog = new List<EmergencyCall>();

        public CallHelper()
        {

        }

        public static void StoreCall(EmergencyCall call)
        {
            if (call != null)
                CallLog.Add(call);
        }

        public static List<EmergencyCall> GetAllCalls()
        {
            return CallLog;
        }
    }
}
