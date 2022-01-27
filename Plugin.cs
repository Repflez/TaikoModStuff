using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace TaikoModStuff
{
    [BepInPlugin("com.github.Repflez.TaikoModStuff", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> configForceFontChange;

        private void Awake()
        {
            // Add configurations
            configForceFontChange = Config.Bind("General.Toggles",
                                                "ForceFontChange",
                                                false,
                                                "Force the game font to the JP font");

            var instance = new Harmony(PluginInfo.PLUGIN_NAME);
            instance.PatchAll(typeof(FontChanger));

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
