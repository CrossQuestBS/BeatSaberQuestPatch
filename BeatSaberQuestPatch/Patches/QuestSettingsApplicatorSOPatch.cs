using System;
using System.Linq;
using System.Reflection;
using BeatSaber.Settings;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(QuestSettingsApplicatorSO), "ApplyGraphicSettings")]
public partial class QuestSettingsApplicatorSoPatch : IDisposable
{

    public QuestSettingsApplicatorSoPatch()
    {
        var infos = typeof(QuestSettingsApplicatorSO)
            .GetMember("ApplyGraphicSettings", (global::System.Reflection.BindingFlags)~0);
        Plugin.log.Info($"Patching! MemberInfos QuestSettingsApplicatorSO: {infos.Length}");
        Patch();
    }
    
    public MemberInfo MemberMethod { get; } = typeof(QuestSettingsApplicatorSO)
        .GetMember("ApplyGraphicSettings", (global::System.Reflection.BindingFlags)~0).FirstOrDefault()!;
    public void Postfix(QuestSettingsApplicatorSO instance, in Settings settings, ref SceneType arg2)
    {
        // TODO: Properly fix this!!
        Plugin.log.Info($"[Postfix] - QuestSettingsApplicatorSO: with targetFramerate {settings.quality.targetFramerate}");
        OVRPlugin.suggestedCpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)SettingPresets.kQuest3.quest.cpuLevel - 1;
        OVRPlugin.suggestedGpuPerfLevel = (OVRPlugin.ProcessorPerformanceLevel)SettingPresets.kQuest3.quest.gpuLevel - 1;
        OVRPlugin.systemDisplayFrequency = 120;
    }

    public void Dispose()
    {
        Unpatch();
    }
}