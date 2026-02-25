using System;
using System.Linq;
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
    
    public MethodInfo Method { get; } 
    public bool Prefix(DisableOnNonQuest instance)
    {
        return false;
    }

    public void Dispose()
    {
        Unpatch();
    }

    public MemberInfo MemberMethod { get; } = typeof(DisableOnNonQuest).GetMember("Awake", (global::System.Reflection.BindingFlags)~0).FirstOrDefault();
}