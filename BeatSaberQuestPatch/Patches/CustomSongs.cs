using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(SinglePlayerLevelSelectionFlowCoordinator), 
    "get_enableCustomLevels", [])]
[AccordPrefix]
public partial class EnableCustomSongsPatch
{

    public EnableCustomSongsPatch()
    {
        Patch();
    }
    
    public bool Prefix(SinglePlayerLevelSelectionFlowCoordinator instance, ref bool returnValue)
    {
        returnValue = true;
        return false;
    }
}