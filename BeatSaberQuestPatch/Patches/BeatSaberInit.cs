using System;
using CrossPatcher.Attributes;
using CrossPatcher.Interfaces;

namespace BeatSaberQuestPatch.Patches
{
    public class BeatSaberInitPatch : ICrossPatch
    {  
        [CrossPrefix]
        [CrossPatch(typeof(BeatSaberInit), "get_settingsApplicator")]
        public static bool SettingsApplicator(BeatSaberInit _instance, ref SettingsApplicatorSO __result)
        {
            __result = _instance._questSettingsApplicator;
            return false;
        }
    }
}
