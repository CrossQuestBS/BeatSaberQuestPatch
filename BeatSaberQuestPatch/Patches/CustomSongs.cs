using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;


/// <summary>
/// This enables official CustomSongs implementation which is normally not available in Quest code
/// TODO: Move this to SongCore
/// </summary>
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