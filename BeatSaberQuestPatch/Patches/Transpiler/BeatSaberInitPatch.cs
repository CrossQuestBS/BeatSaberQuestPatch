using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches.Transpiler;

[AccordTranspiler]
public partial class BeatSaberInitPatch 
{
    public SettingsApplicatorSO PatchApplicator(BeatSaberInit instance)
    {
        return instance._questSettingsApplicator;
    }
}