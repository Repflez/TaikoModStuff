using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace TaikoModStuff
{
    [BepInPlugin("TaikoModStuff", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> configForceFontChange;

        public static ConfigEntry<int> configCustomWindowedWidth;
        public static ConfigEntry<int> configCustomWindowedHeight;

        public static ConfigEntry<int> configCustomFramerate;

        private void Awake()
        {
            // Add configurations
            configForceFontChange = Config.Bind("General.Toggles",
                                                "ForceFontChange",
                                                false,
                                                "Force the game font to the JP font");

            configCustomWindowedWidth = Config.Bind("General.Resolution",
                                                     "CustomWidth",
                                                     1920,
                                                     "Custom width to use. Set to 0 to disable setting the custom resolution");

            configCustomWindowedHeight = Config.Bind("General.Resolution",
                                                     "CustomHeight",
                                                     1080,
                                                     "Custom height to use");

            configCustomFramerate = Config.Bind("General.Framerate",
                                                     "CustomFramerate",
                                                     60,
                                                     "Custom framerate. Use with caution");

            var instance = new Harmony(PluginInfo.PLUGIN_NAME);
            instance.PatchAll(typeof(FontChanger));
            instance.PatchAll(typeof(CustomResolution));

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
