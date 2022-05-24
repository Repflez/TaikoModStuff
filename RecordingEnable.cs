using HarmonyLib;
#if !BEPIN_5
using Il2CppMicrosoft.Xbox;
#else
using Microsoft.Xbox;
#endif

namespace TaikoModStuff
{
    internal class RecordingEnable
    {
        // Skip the original method, we're doing magic here
        [HarmonyPatch(typeof(GdkHelpers), "CaptureDisable")]
        [HarmonyPrefix]
        static bool PrefixRecording()
        {
            if (Plugin.configEnableRecording.Value)
                return false;

            else return true;
        }
    }
}
