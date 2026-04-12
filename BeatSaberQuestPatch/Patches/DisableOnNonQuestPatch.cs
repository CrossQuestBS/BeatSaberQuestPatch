using System;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(DisableOnNonQuest),"Awake", [])]
[AccordPrefix]
public partial class DisableOnNonQuestPatch : IDisposable
{
    public DisableOnNonQuestPatch()
    {
        Patch();
    }
    
    public bool Prefix(DisableOnNonQuest instance)
    {
        return false;
    }

    public void Dispose()
    {
        Unpatch();
    }

}