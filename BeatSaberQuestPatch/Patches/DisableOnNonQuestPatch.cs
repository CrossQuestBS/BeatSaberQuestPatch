using System;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(DisableOnNonQuest),"Awake")]
[AccordPrefix]
public partial class DisableOnNonQuestPatch : IDisposable
{

    public DisableOnNonQuestPatch()
    {
        Patch();
    }
    
    public MethodInfo Method { get; } = typeof(DisableOnNonQuest).GetMethod("Awake", (global::System.Reflection.BindingFlags)~0)!;
    public bool Prefix(DisableOnNonQuest instance)
    {
        return false;
    }

    public void Dispose()
    {
        Unpatch();
    }
}