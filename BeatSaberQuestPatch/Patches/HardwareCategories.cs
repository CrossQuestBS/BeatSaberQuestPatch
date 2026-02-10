using System;
using CrossPatcher.Attributes;
using CrossPatcher.Interfaces;

namespace BeatSaberQuestPatch.Patches
{
    public class HardwareCategoriesPatch : ICrossPatch
    {
        [CrossPrefix]
        [CrossPatch(typeof(HardwareCategories), "GetHardwareCategory")]
        public static bool GetHardwareCategory(ref HardwareCategory __result) {
            int headsetType = (int)OVRPlugin.GetSystemHeadsetType() - 8;
            int[] headsetMapping = { 1, 2, 4, 3 };

            __result = headsetType > 3 ? (HardwareCategory)3 : (HardwareCategory)headsetMapping[headsetType];
            return false;
        }
    }
}
