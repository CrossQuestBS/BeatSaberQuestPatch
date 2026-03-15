using System;
using System.Linq;
using System.Reflection;
using BeatSaber.Settings;
using CrossAccord.Common.Attributes;
using UnityEngine;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(QuestSettingsApplicatorSO), "ApplyGraphicSettings")]
public partial class QuestSettingsApplicatorSoPatch : IDisposable
{

    public QuestSettingsApplicatorSoPatch()
    {
        Patch();
    }
    
    public MemberInfo MemberMethod { get; } = typeof(QuestSettingsApplicatorSO)
        .GetMember("ApplyGraphicSettings", (global::System.Reflection.BindingFlags)~0).FirstOrDefault()!;
    public void Postfix(QuestSettingsApplicatorSO instance, in Settings settings, ref SceneType arg2)
    {
        OVRPlugin.suggestedCpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)SettingPresets.kQuest3.quest.cpuLevel - 1;
        OVRPlugin.suggestedGpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)SettingPresets.kQuest3.quest.gpuLevel - 1;
        OVRPlugin.systemDisplayFrequency = 120;
        Screen.SetResolution(16, 16, FullScreenMode.FullScreenWindow, new RefreshRate() { numerator = 120, denominator = 1});
    }

    public void Dispose()
    {
        Unpatch();
    }
}