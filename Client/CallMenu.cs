using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;

namespace EmergencyDispatchSystem.Client
{
    class CallMenu : BaseScript
    {
        public CallMenu()
        {
            ///////////////////////////////////////////////////////////////
            //////////////////////  [ First Screen ] //////////////////////
            ///////////////////////////////////////////////////////////////

            // Align the menu to the left side of the screen
            MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Left;

            // Create the first screen of the menu then add it to the menu controller
            Menu mainCallMenu = new Menu("Emergency Services", "What emergency service do you require?");
            MenuController.AddMenu(mainCallMenu);

            // Create the options for the first screen

            // Police
            mainCallMenu.AddMenuItem(new MenuItem("Police", "Request police assistance")
            {
                Enabled = true
            });

            // Ambulance
            mainCallMenu.AddMenuItem(new MenuItem("Ambulance", "Request police assistance")
            {
                Enabled = false
            });

            // Fire
            mainCallMenu.AddMenuItem(new MenuItem("Fire", "Request police assistance")
            {
                Enabled = false
            });

            // Events
            EventHandlers["EDS:OpenCallMenu"] += new Action(mainCallMenu.OpenMenu);

            mainCallMenu.OnItemSelect += (_menu, _item, _index) =>
            {
                switch (_index)
                {
                    case 0:
                        Debug.WriteLine("Dispatch police!");
                        break;
                }
            };
        }
    }
}
