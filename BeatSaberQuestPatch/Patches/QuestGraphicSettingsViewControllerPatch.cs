using System;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

/// <summary>
/// This enables the 120hz graphic settings
/// TODO: Add a check for non Quest 3 devices
/// </summary>
[AccordPatch(typeof(QuestGraphicSettingsViewController), "ShouldShowStinsonEntries", [])]
public partial class QuestGraphicSettingsViewControllerPatch : IDisposable
{
    public QuestGraphicSettingsViewControllerPatch()
    {
        Patch();
    }

    public void Postfix(ref bool returnValue)
    {
        returnValue = true;
    }

    public void Dispose()
    {
        Unpatch();
    }
}