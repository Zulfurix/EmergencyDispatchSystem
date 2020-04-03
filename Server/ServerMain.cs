using System;
using System.Threading.Tasks;
using CitizenFX.Core;

namespace EmergencyDispatchSystem.Server
{
    public class ServerMain : BaseScript
    {
        public ServerMain()
        {
            Debug.WriteLine("Hi from EmergencyDispatchSystem.Server!");
        }

        [Command("hello_server")]
        public void HelloServer()
        {
            Debug.WriteLine("Sure, hello.");
        }
    }
}