using HarmonyLib;

namespace TaikoModStuff
{
    internal class FontChanger
    {
        [HarmonyPatch(typeof(WordDataManager), "GetFontType")]
        [HarmonyPostfix]
        static void GetFontType_Patched(ref int __result)
        {
            if (Plugin.configForceFontChange.Value)
                __result = 0; // Force the font to the JP one.
        }
    }
}
