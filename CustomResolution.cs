using HarmonyLib;
using OnlineManager;
using System;
using UnityEngine;

namespace TaikoModStuff
{
    internal class CustomResolution
    {
        // Skip the original method, we're doing magic here
        [HarmonyPatch(typeof(FocusManager), "OnApplicationFocus")]
        [HarmonyPrefix]
        static bool PrefixFocus()
        {
            return false;
        }

        // Skip the original method, we're doing magic here
        [HarmonyPatch(typeof(FocusManager), "SetScreenType")]
        [HarmonyPrefix]
        static bool PrefixScreenType()
        {
            return false;
        }

        [HarmonyPatch(typeof(FocusManager), "OnApplicationFocus")]
        [HarmonyPrefix]
        static void setCustomFocus(bool focusStatus)
        {
            if (focusStatus)
            {
                Traverse focusManager = Traverse.CreateWithType("FocusManager");
                DataConst.ScreenModeType m_typeScreenMode = focusManager.Field<DataConst.ScreenModeType>("m_typeScreenMode").Value;
                int width = 1920;
                int height = 1080;
                int framerate = Plugin.configCustomFramerate.Value;

                // Namco does typos
                int hegiht = focusManager.Field<int>("hegiht").Value;

                if (Plugin.configCustomWindowedWidth.Value > 0)
                {
                    width = Plugin.configCustomWindowedWidth.Value;

                    // Set custom height if the width is set first
                    if (Plugin.configCustomWindowedHeight.Value > 0)
                    {
                        height = Plugin.configCustomWindowedHeight.Value;
                    }
                }

                switch ((int)m_typeScreenMode)
                {
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

                if (TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MySceneManager.CurrentSceneName == "RankedMatch")
                {
                    TaikoSingletonMonoBehaviour<XboxLiveOnlineManager>.Instance.GetNetworkTimeOnApplicationFocus();
                }
            }
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

            Traverse.CreateWithType("FocusManager").Method("setScreenModeType", new Type[] { typeof(DataConst.ScreenModeType) }, new object[] { (DataConst.ScreenModeType)type }).ToString();
        }
    }
}
