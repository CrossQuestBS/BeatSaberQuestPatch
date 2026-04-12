using System;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

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