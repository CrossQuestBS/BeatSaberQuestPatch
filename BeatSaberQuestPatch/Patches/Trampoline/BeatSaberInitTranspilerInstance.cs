using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches.Trampoline;

[AccordTranspiler]
public partial class BeatSaberInitTranspilerInstance 
{
    public SettingsApplicatorSO PatchApplicator(BeatSaberInit instance)
    {
        return instance._questSettingsApplicator;
    }
}