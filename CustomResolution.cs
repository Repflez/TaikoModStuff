using HarmonyLib;
using UnityEngine;

namespace TaikoModStuff
{
    internal class CustomResolution
    {
        // Skip the original method, we're doing magic here
        [HarmonyPatch(typeof(FocusManager), "SetScreenType")]
        [HarmonyPrefix]
        static bool Prefix()
        {
            return false;
        }

        [HarmonyPatch(typeof(FocusManager), "SetScreenType")]
        [HarmonyPrefix]
        static void setCustomResolution(int type)
        {
            int width = 1920;
            int height = 1080;
            int framerate = Plugin.configCustomFramerate.Value;

            if (Plugin.configCustomWindowedWidth.Value > 0) {
                width = Plugin.configCustomWindowedWidth.Value;

                // Set custom height if the width is set first
                if (Plugin.configCustomWindowedHeight.Value > 0) {
                    height = Plugin.configCustomWindowedHeight.Value;
                }
            }

            switch (type) {
                case 1: // Borderless
                    Screen.fullScreen = true;
                    Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow, framerate);
                    break;
                case 2: // Windowed
                    Screen.fullScreen = false;
                    Screen.SetResolution(width, height, FullScreenMode.Windowed, framerate);
                    break;
                default: // Fullscreen
                    Screen.fullScreen = true;
                    Screen.SetResolution(width, height, FullScreenMode.FullScreenWindow, framerate);
                    break;
            }

            // TODO: Fix this
            Traverse.CreateWithType("FocusManager").Field("m_typeScreenMode").SetValue((DataConst.ScreenModeType)type);
        }
    }
}
