using BepInEx;
using KSP.Game;
using System;
using UnityEngine;

namespace KSP2_TestPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Logger.LogInfo($"We are in...");
        }

        private GameInstance gameInstance = null;

        public void Update()
        {
            if (gameInstance == null)
                // It is slow to use FindObjectOfType<>() as it has to traverse the entire scene, so we cache what we can
                gameInstance = FindObjectOfType<GameInstance>();

            // Not everything you want to access is actually available or instantiated at any given point in time.
            // Need to always be programming defensively
            if (gameInstance != null && Input.GetKeyDown(KeyCode.F2))
            {
                NotificationData notificationData = new NotificationData
                {
                    Tier = NotificationTier.Alert,
                    Importance = NotificationImportance.Medium,
                    AlertTitle =
                    {
                        LocKey = "Success!"
                    },
                    FirstLine =
                    {
                        LocKey = "You have a game instance!"
                    },
                    IsTimerActive = true,
                    TimerDuration = 3f,
                    TimeStamp = DateTime.Now
                };

                gameInstance.Notifications.ProcessNotification(notificationData);
            }

        }
    }
}
