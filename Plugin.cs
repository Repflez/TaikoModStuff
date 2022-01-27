using BepInEx;
using HarmonyLib;

namespace TaikoModStuff
{
    [BepInPlugin("com.github.Repflez.TaikoModStuff", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {

            var instance = new Harmony(PluginInfo.PLUGIN_NAME);
            instance.PatchAll(typeof(FontChanger));

            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }
    }
}
