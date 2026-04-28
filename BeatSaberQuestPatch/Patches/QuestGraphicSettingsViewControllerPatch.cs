using System;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

/// <summary>
/// This enables the 120hz graphic settings
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
        var hardwareCategory = HardwareCategories.GetHardwareCategory();
        returnValue = hardwareCategory is HardwareCategory.Quest3 or HardwareCategory.QuestPro;
    }

    public void Dispose()
    {
        Unpatch();
    }
}