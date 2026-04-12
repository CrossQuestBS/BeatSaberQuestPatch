using System;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches
{
    [AccordPatch(typeof(FileSystemFileStorage), ".ctor", [])]
    [AccordPostfix]
    public partial class FileSystemStoragePatch : IDisposable
    {
        public FileSystemStoragePatch()
        {
            Patch();
        }
        
        public void Postfix(FileSystemFileStorage instance)
        {
            typeof(FileSystemFileStorage).SetPrivateField(instance, "_persistentDataPath", "/sdcard/CrossQuest/com.beatgames.beatsaber/files");
        }

        public void Dispose()
        {
            Unpatch();
        }
    }
}