using System;
using CrossPatcher.Attributes;
using CrossPatcher.Interfaces;

namespace BeatSaberQuestPatch.Patches
{
    public class UpdateSettingsViewController : ICrossPatch
    {
        [CrossPrefix]
        [CrossPatch(typeof(MainSettingsMenuViewControllersInstaller), "InstallBindings", new Type[0])]
        public static bool InstallBindings(MainSettingsMenuViewControllersInstaller _instance)
        {
            _instance._oculusPCSettingsMenuViewController = _instance._questSettingsMenuViewController;
            return true;
        }
        
        [CrossPostfix]
        [CrossPatch(typeof(QuestSettingsApplicatorSO), "ApplyGraphicSettings", new Type[0])]
        public static void ApplyGraphicSettings(QuestSettingsApplicatorSO __instance, in BeatSaber.Settings.Settings settings)
        {
            OVRPlugin.suggestedCpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)settings.quest.cpuLevel - 1;
            OVRPlugin.suggestedGpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)settings.quest.gpuLevel - 1;
            OVRPlugin.systemDisplayFrequency = settings.quality.targetFramerate;
        }
    }
}