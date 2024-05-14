using BepInEx;

namespace SPT_Client_Mod_Template
{
    [BepInPlugin("com.YourName.ModName", "Mod name", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin is loaded!");
        }
    }
}
