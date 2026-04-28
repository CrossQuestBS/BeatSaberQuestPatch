using System;
using System.Text;
using BeatSaber.Settings;
using Accord.Common.Attributes;
using UnityEngine;

namespace BeatSaberQuestPatch.Patches;

/// <summary>
/// The following patch make sure correct performance level is set on Quest, and display resolution
/// </summary>
[AccordPatch(typeof(SettingsApplicatorSO), "ApplyGraphicSettings", [typeof(Settings), typeof(SceneType)])]
public partial class SettingsApplicatorSoPatch : IDisposable
{

    public SettingsApplicatorSoPatch()
    {
        Patch();
    }
    
    public void Postfix(SettingsApplicatorSO instance, ref Settings settings, ref SceneType arg2)
    {
        OVRPlugin.suggestedCpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)settings.quest.cpuLevel - 1;
        OVRPlugin.suggestedGpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)settings.quest.gpuLevel - 1;
        OVRPlugin.systemDisplayFrequency = settings.quality.targetFramerate;
        Screen.SetResolution(16, 16, FullScreenMode.FullScreenWindow, new RefreshRate() { numerator = (uint)settings.quality.targetFramerate, denominator = 1});
    }

    public void Dispose()
    {
        Unpatch();
    }
}