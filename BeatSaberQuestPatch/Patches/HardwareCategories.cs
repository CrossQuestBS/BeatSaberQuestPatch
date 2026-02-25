using System;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches
{
    [AccordPatch(typeof(HardwareCategories), "GetHardwareCategory")]
    [AccordPrefix]
    public partial class HardwareCategoriesPatch : IDisposable
    {
        public HardwareCategoriesPatch()
        {
            Patch();
        }
        
        public MethodInfo Method { get; } = typeof(HardwareCategories).GetMethod("GetHardwareCategory", (global::System.Reflection.BindingFlags)~0)!;
        public bool Prefix(ref HardwareCategory returnValue)
        {
            int headsetType = (int)OVRPlugin.GetSystemHeadsetType() - 8;
            int[] headsetMapping = { 1, 2, 4, 3 };

            returnValue = headsetType > 3 ? (HardwareCategory)3 : (HardwareCategory)headsetMapping[headsetType];
            return false;
        }

        public void Dispose()
        {
            Unpatch();
        }
    }
}
