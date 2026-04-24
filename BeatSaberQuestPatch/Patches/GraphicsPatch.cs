using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeatSaber.Settings;
using Accord.Common.Attributes;
using OculusStudios.Platform.Oculus;
using UnityEngine;
using QualitySettings = BeatSaber.Settings.QualitySettings;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(PyramidBloomMainEffectSO), "PreRender", [])]
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

[AccordPatch(typeof(MainEffectCore), "SetGlobalShaderValues", [typeof(float), typeof(float)])]
[AccordPrefix]
public partial class MainEffectPatch
{
    private static readonly int QuestWhiteboostMultiplier = Shader.PropertyToID("_QuestWhiteboostMultiplier");
    private static readonly int BloomMultiplier = Shader.PropertyToID("_BloomMultiplier");

    public MainEffectPatch()
    {
        Patch();
    }

    public bool Prefix(ref float arg1, ref float arg2)
    {
        Shader.SetGlobalFloat(QuestWhiteboostMultiplier, 0.0f);
        Shader.SetGlobalFloat(BloomMultiplier, 0.0f);
        arg1 = 0.0f;
        arg2 = 0.0f;
        return true;
    }
}

[AccordPatch(typeof(PlatformUser), "InternalGetAccessTokenAsync", [])]
[AccordPrefix]
public partial class StopTryingGettingToken
{
    public StopTryingGettingToken()
    {
        Patch();
    }

    public bool Prefix(PlatformUser instance, ref Task returnValue)
    {
        returnValue = Task.CompletedTask;
        return false;
    }
}



[AccordPatch(typeof(SettingValidations), "AdjustQuest3", [typeof(Settings)])]
public partial class SettingsPatch
{
    public SettingsPatch()
    {
        Patch();
    }

    public void Postfix(ref Settings arg1)
    {
        ref QualitySettings settings = ref arg1.quality;
        
        settings.mainEffect = QualitySettings.MainEffectOption.Game;
        settings.bloom = QualitySettings.BloomQuality.Game;
        settings.smokeGraphics = false;
        settings.mirror = QualitySettings.MirrorQuality.Off;
        settings.obstacles = QualitySettings.ObstacleQuality.Medium;
        settings.antiAliasingLevel = 0;
        settings.screenDisplacementEffects = false;
        settings.maxShockwaveParticles = 0;
        settings.targetFramerate = 240;
        
        ref QuestSettings quest = ref arg1.quest;
        quest.foveatedRenderingGameplay = QuestSettings.FoveatedRenderingLevel.Medium;
        quest.dynamicFoveatedRendering = true;

    }
}