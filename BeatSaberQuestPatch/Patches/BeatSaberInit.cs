using System;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches
{
    [AccordPatch(typeof(BeatSaberInit), "get_settingsApplicator")]
    [AccordPrefix]
    public partial class BeatSaberInitPatch : IDisposable
    {
        public BeatSaberInitPatch()
        {
            Patch();   
        }
        
        public MethodInfo Method { get; } =
            typeof(BeatSaberInit).GetMethod("get_settingsApplicator", (global::System.Reflection.BindingFlags)~0)!;
        
        public bool Prefix(BeatSaberInit instance, ref SettingsApplicatorSO returnValue)
        {
            returnValue = instance._questSettingsApplicator;
            return false;
        }

        public void Dispose()
        {
            Unpatch();
        }
    }
}
