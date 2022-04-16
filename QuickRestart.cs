using UnityEngine;
using UnityEngine.SceneManagement;
using BepInEx;
using HarmonyLib;

namespace TaikoModStuff
{
    [HarmonyPatch]
    public class QuickRestart
    {
        [HarmonyPatch(typeof(EnsoGameManager), "ProcExecPause")]
        [HarmonyPrefix]
        static void customProcExecPause()
        {
            bool keyDown = Input.GetKeyDown(KeyCode.Backspace);
            if (keyDown)
            {
                //TaikoSingletonMonoBehaviour<EnsoGameManager>.Instance.Invoke("RestartPlay", 1);
                TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MySceneManager.ChangeRelayScene("Enso", true);
            }
        }
    }
}