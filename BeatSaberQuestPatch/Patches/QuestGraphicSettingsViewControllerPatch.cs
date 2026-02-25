using System;
using System.Linq;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(QuestGraphicSettingsViewController), "ShouldShowStinsonEntries")]
public partial class QuestGraphicSettingsViewControllerPatch : IDisposable
{
    public QuestGraphicSettingsViewControllerPatch()
    {
        Patch();
    }
    
    public MemberInfo MemberMethod { get; } = typeof(QuestGraphicSettingsViewController)
        .GetMember("ShouldShowStinsonEntries", (global::System.Reflection.BindingFlags)~0).FirstOrDefault()!;
    public void Postfix(ref bool returnValue)
    {
        returnValue = true;
    }

    public void Dispose()
    {
        Unpatch();
    }
}