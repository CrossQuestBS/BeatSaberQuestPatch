using System;
using CrossPatcher.Attributes;
using CrossPatcher.Interfaces;

namespace BeatSaberQuestPatch.Patches
{
    public class HelpersPatch : ICrossPatch
    {
        [CrossPrefix]
        [CrossPatch(typeof(DisableOnNonQuest), "Awake")]
        public static bool DisableOnNonQuest_Awake() {
            return false;
        }

        [CrossPrefix]
        [CrossPatch(typeof(IPAPluginsDirDeleter), "Awake")]
        public static bool IPAPluginsDirDeleter_Awake()
        {
            return false;
        }
    }
}
