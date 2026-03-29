using CrossAccord.Common.Interfaces;

namespace BeatSaberQuestPatch.Patches.Trampoline;

public class BeatSaberInitTrampoline : IAccordTrampolinePatch<BeatSaberInitTrampoline>
{
    public static BeatSaberInitTrampoline Instance { get; set; } = null;
    
    public SettingsApplicatorSO PatchApplicator(BeatSaberInit instance)
    {
        return instance._questSettingsApplicator;
    }
}