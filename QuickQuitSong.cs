using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx;
using HarmonyLib;

namespace TaikoModStuff
{
    [HarmonyPatch]
    public class QuickQuitSong
    {
        [HarmonyPatch(typeof(EnsoGameManager), "ProcExecPause")]
        [HarmonyPrefix]
        static void customProcExecPause()
        {
            bool keyDown = Input.GetKeyDown(KeyCode.Escape);
            if (keyDown)
            {
                TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MySceneManager.ChangeRelayScene("SongSelect", true);
            }
        }
    }
}