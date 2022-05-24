using HarmonyLib;

namespace TaikoModStuff
{
        [HarmonyPatch]
        public class OfflineSaveLoad
        {
            [HarmonyPatch(typeof(GameTitleManager), "Start")]
            [HarmonyPostfix]
            private static void BootManager_Postfix(GameTitleManager __instance)
            {
                    TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MyDataManager.PlayData.LoadData("x_game_save_default_container", "save_data_blob");
                    TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MyDataManager.PlayData.LoadData("x_game_save_default_container", "system_data_blob");
                    TaikoSingletonMonoBehaviour<CommonObjects>.Instance.MySceneManager.ChangeScene("SongSelect", false);
            }
        }
    }