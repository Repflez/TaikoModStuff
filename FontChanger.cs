using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaikoModStuff
{
    internal class FontChanger
    {
        [HarmonyPatch(typeof(WordDataManager), "GetFontType")]
        [HarmonyPostfix]
        static void GetFontType_Patched(ref int __result)
        {
            __result = 0; // Force the font to the JP one.
        }
    }
}
