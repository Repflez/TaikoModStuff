using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Configuration;
using HarmonyLib;

namespace TaikoModStuff
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public static ConfigEntry<bool> configForceFontChange;

        public static ConfigEntry<int> configCustomWindowedWidth;
        public static ConfigEntry<int> configCustomWindowedHeight;

        public static ConfigEntry<int> configCustomFramerate;
        public static ConfigEntry<bool> configToggleVSync;

        public static ConfigEntry<bool> configEnableRecording;

        public override void Load()
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
                                                     "Custom framerate.");

            configToggleVSync = Config.Bind("General.Graphics",
                                             "EnableVSync",
                                             true,
                                             "Enable VSync.");

            configEnableRecording = Config.Bind("General.Toggles",
                                             "EnableGameBarRecording",
                                             true,
                                             "Enables Game Recording from the Xbox Game Bar where it was previously disabled.");


            var instance = new Harmony(PluginInfo.PLUGIN_NAME);
            instance.PatchAll(typeof(FontChanger));
            instance.PatchAll(typeof(CustomResolution));
            instance.PatchAll(typeof(ForceFramerate));
            instance.PatchAll(typeof(RecordingEnable));

            // Plugin startup logic
            Log.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
