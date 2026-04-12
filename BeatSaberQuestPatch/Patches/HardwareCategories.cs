using System;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches
{
    [AccordPatch(typeof(HardwareCategories), "GetHardwareCategory", [])]
    [AccordPrefix]
    public partial class HardwareCategoriesPatch : IDisposable
    {
        public HardwareCategoriesPatch()
        {
            Patch();
        }
        
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
