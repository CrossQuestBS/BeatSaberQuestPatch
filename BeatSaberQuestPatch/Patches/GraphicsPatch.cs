using System.Linq;
using System.Reflection;
using BeatSaber.Settings;
using CrossAccord.Common.Attributes;
using UnityEngine;
using QualitySettings = BeatSaber.Settings.QualitySettings;

namespace BeatSaberQuestPatch.Patches;

/*[AccordPatch(typeof(PyramidBloomMainEffectSO), "PreRender")]
[AccordPrefix]
public partial class GraphicsPatch
{
    public GraphicsPatch()
    {
        Patch();
    }
    
    private static readonly int BaseColorBoost = Shader.PropertyToID("_BaseColorBoost");
    private static readonly int BaseColorBoostThreshold = Shader.PropertyToID("_BaseColorBoostThreshold");
    public MemberInfo MemberMethod => typeof(PyramidBloomMainEffectSO).GetMember("PreRender", (BindingFlags)~0).FirstOrDefault()!;
    public bool Prefix(PyramidBloomMainEffectSO instance)
    {
        instance._mainEffectMaterial.SetFloat(BaseColorBoost, 0.95f);
        instance._mainEffectMaterial.SetFloat(BaseColorBoostThreshold, 0.0f);
        instance._baseColorBoost = 0.0f;
        instance._baseColorBoostThreshold = 0.0f;
        return true;
    }
}

[AccordPatch(typeof(MainEffectCore), "SetGlobalShaderValues")]
[AccordPrefix]
public partial class MainEffectPatch
{
    private static readonly int QuestWhiteboostMultiplier = Shader.PropertyToID("_QuestWhiteboostMultiplier");
    private static readonly int BloomMultiplier = Shader.PropertyToID("_BloomMultiplier");

    public MainEffectPatch()
    {
        Patch();
    }
    
    public MemberInfo MemberMethod =>
        typeof(MainEffectCore).GetMember("SetGlobalShaderValues", (BindingFlags)~0).FirstOrDefault()!;
    
    public bool Prefix(ref float arg1, ref float arg2)
    {
        Shader.SetGlobalFloat(QuestWhiteboostMultiplier, 0.0f);
        Shader.SetGlobalFloat(BloomMultiplier, 0.0f);
        arg1 = 0.0f;
        arg2 = 0.0f;
        return true;
    }
}

[AccordPatch(typeof(SettingValidations), "AdjustQuest3")]
public partial class SettingsPatch
{
    public SettingsPatch()
    {
        Patch();
    }
    
    public MemberInfo MemberMethod =>
        typeof(SettingValidations).GetMember("AdjustQuest3", (BindingFlags)~0).FirstOrDefault()!;

    public void Postfix(ref Settings arg1)
    {
        arg1.quality.mainEffect = QualitySettings.MainEffectOption.Game;
        arg1.quality.bloom = QualitySettings.BloomQuality.Game;
        arg1.quality.smokeGraphics = true;
        arg1.quality.mirror = QualitySettings.MirrorQuality.Off;
        arg1.quality.obstacles = QualitySettings.ObstacleQuality.Low;
        arg1.quality.antiAliasingLevel = 4;
        arg1.quality.vrResolutionScale = 1.0f;
        arg1.quality.screenDisplacementEffects = false;
        arg1.quality.maxShockwaveParticles = 0;
        arg1.quality.targetFramerate = -1;
        arg1.quality.maxQueuedFrames = -1;
    }
}*/