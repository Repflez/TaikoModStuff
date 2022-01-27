using HarmonyLib;
using UnityEngine;

namespace TaikoModStuff
{
    internal class ForceFramerate
    {
        // Skip the original method, we're doing magic here
        [HarmonyPatch(typeof(ForceRenderRate), "Start")]
        [HarmonyPrefix]
        static bool PrefixFocus()
        {
            return false;
        }

        // Skip the original method, we're doing magic here
        [HarmonyPatch(typeof(ForceRenderRate), "Update")]
        [HarmonyPrefix]
        static bool PrefixScreenType()
        {
            return false;
        }

        [HarmonyPatch(typeof(ForceRenderRate), "Start")]
        [HarmonyPrefix]
        static void customStart()
        {
            // Force vsync at all times
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = Plugin.configCustomFramerate.Value;
        }

        [HarmonyPatch(typeof(ForceRenderRate), "Update")]
        [HarmonyPrefix]
        static void customUpdate()
        {
            // Force vsync at all times
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = Plugin.configCustomFramerate.Value;
        }
    }
}
