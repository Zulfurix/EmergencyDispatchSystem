using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using System.Collections.Generic;

namespace EmergencyDispatchSystem.Client
{
    class DispatchMenu : BaseScript
    {
        public DispatchMenu()
        {
            ///////////////////////////////////////////////////////////////
            //////////////////////  [ First Screen ] //////////////////////
            ///////////////////////////////////////////////////////////////

            // Align the menu to the left side of the screen
            MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Left;

           // MenuController.MenuToggleKey = Control.VehicleBikeWings;

            // Create the first screen of the menu then add it to the menu controller
            Menu mainDispatchMenu = new Menu("Emergency Services", "What emergency service do you require?");
            MenuController.AddMenu(mainDispatchMenu);

            // Create the options for the first screen

            // View Logged Calls
            mainDispatchMenu.AddMenuItem(new MenuItem("View Call Log", "Shows a list of all previously made calls")
            {
                Enabled = true
            });

            // Events
            EventHandlers["EDS:OpenDispatchMenu"] += new Action(mainDispatchMenu.OpenMenu);

            mainDispatchMenu.OnItemSelect += (_menu, _item, _index) =>
            {
                switch (_index)
                {
                    case 0:
                        break;
                }
            };


            ///////////////////////////////////////////////////////////////
            ////////////////  [ Dispatch Call Log Screen ] ////////////////
            ///////////////////////////////////////////////////////////////

            // Create the menu
            Menu callLogMenu = new Menu("Dispatch Call Log");
            MenuController.AddSubmenu(mainDispatchMenu, callLogMenu);

            // Bind first item of previous menu screen to open this sub menu
            MenuController.BindMenuItem(mainDispatchMenu, callLogMenu, mainDispatchMenu.GetMenuItems()[0]);

            // Events
            callLogMenu.OnMenuOpen += (_menu) =>
            {
                callLogMenu.ClearMenuItems();
                foreach (EmergencyCall ec in CallHelper.GetAllCalls())
                {
                    // Create the menu item, add it to the call log menu
                    MenuItem currCallItem = new MenuItem("[" + ec.GetTime() + "] [" + MessageHelper.ConvertNotificationTypeToString(ec.GetServiceType()) + "] ~w~" + ec.GetMessage());
                    callLogMenu.AddMenuItem(currCallItem);

                    // Create a sub menu for the current call
                    Menu currentCallMenu = new Menu("Dispatch Call at " + ec.GetTime());
                    MenuController.AddSubmenu(callLogMenu, currentCallMenu);

                    // Set up items for current call menu
                    currentCallMenu.AddMenuItem(new MenuItem("Set waypoint to location"));

                    // Bind current call sub menu to the dispatch menu to allow it to be opened
                    MenuController.BindMenuItem(callLogMenu, currentCallMenu, currCallItem);

                    // Event handlers for the call menu's items
                    currentCallMenu.OnItemSelect += (_submenu, _item, _index) =>
                    {
                        SetNewWaypoint(ec.GetLocation().X, ec.GetLocation().Y);
                    };
                }
            };

        }
    }
}
