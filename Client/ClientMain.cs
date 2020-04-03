using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace EmergencyDispatchSystem.Client
{
    public class ClientMain : BaseScript
    {
        public ClientMain()
        {
            Debug.WriteLine("Emergency Dispatch System by Zulfurix");
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        public void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            RegisterCommand("911", new Action<int, List<object>, string>((source, args, raw) =>
            {
                TriggerEvent("EDS:OpenCallMenu");
            }), false);
        }

        [Tick]
        public Task OnTick()
        {
            return Task.FromResult(0);
        }
    }
}