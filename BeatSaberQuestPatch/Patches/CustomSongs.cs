using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(SinglePlayerLevelSelectionFlowCoordinator), "get_enableCustomLevels")]
[AccordPrefix]
public partial class EnableCustomSongsPatch
{

    public EnableCustomSongsPatch()
    {
        Patch();
    }
    
    public MemberInfo MemberMethod => typeof(SinglePlayerLevelSelectionFlowCoordinator).GetMember("get_enableCustomLevels", (global::System.Reflection.BindingFlags)~0).FirstOrDefault()!;

    public bool Prefix(SinglePlayerLevelSelectionFlowCoordinator instance, ref bool returnValue)
    {
        returnValue = true;
        return false;
    }
}