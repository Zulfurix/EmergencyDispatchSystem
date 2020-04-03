using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;

namespace EmergencyDispatchSystem.Client
{
    class CallMenu : BaseScript
    {
        private string inputValue = "";
        private DispatchNotificationType selectedService;

        public CallMenu()
        {
            ///////////////////////////////////////////////////////////////
            //////////////////////  [ First Screen ] //////////////////////
            ///////////////////////////////////////////////////////////////

            // Align the menu to the left side of the screen
            MenuController.MenuAlignment = MenuController.MenuAlignmentOption.Left;

            MenuController.MenuToggleKey = Control.VehicleBikeWings;

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
            mainCallMenu.AddMenuItem(new MenuItem("Ambulance", "Request EMS assistance")
            {
                Enabled = true
            });

            // Fire
            mainCallMenu.AddMenuItem(new MenuItem("Fire", "Request fire service assistance")
            {
                Enabled = true
            });

            // Events
            EventHandlers["EDS:OpenCallMenu"] += new Action(mainCallMenu.OpenMenu);

            mainCallMenu.OnItemSelect += (_menu, _item, _index) =>
            {
                switch (_index)
                {
                    case 0:
                        DisplayOnscreenKeyboard(0, "What is your emergency?", "", "", "", "", "", 128);
                        selectedService = DispatchNotificationType.POLICE;
                        Tick += GetUserDispatchMessage;
                        break;
                    case 1:
                        DisplayOnscreenKeyboard(0, "What is your emergency?", "", "", "", "", "", 128);
                        selectedService = DispatchNotificationType.AMBULANCE;
                        Tick += GetUserDispatchMessage;
                        break;
                    case 2:
                        DisplayOnscreenKeyboard(0, "What is your emergency?", "", "", "", "", "", 128);
                        selectedService = DispatchNotificationType.FIRE;
                        Tick += GetUserDispatchMessage;
                        break;
                }
            };
        }

        public Task GetUserDispatchMessage()
        {
            HideHudAndRadarThisFrame();
            if (UpdateOnscreenKeyboard() == 3)
            {
                Tick -= GetUserDispatchMessage;
            }
            else if (UpdateOnscreenKeyboard() == 1)
            {
                inputValue = GetOnscreenKeyboardResult();
                if (inputValue.Length > 0)
                {
                    TriggerServerEvent("EDS:DisplayDispatchNotificationForAll", (int)selectedService, inputValue, new Vector2(Game.PlayerPed.Position.X, Game.PlayerPed.Position.Y));
                    Tick -= GetUserDispatchMessage;
                }
                else
                {
                    DisplayOnscreenKeyboard(0, "What is your emergency?", "", "", "", "", "", 128);
                }
            }
            else if (UpdateOnscreenKeyboard() == 1)
            {
                Tick -= GetUserDispatchMessage;
            }
            return Task.FromResult(0);
        }
    }
}
