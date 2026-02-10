using System;
using CrossPatcher.Attributes;
using CrossPatcher.Extensions;
using CrossPatcher.Interfaces;

namespace BeatSaberQuestPatch.Patches
{
    public class FileSystemStoragePatch : ICrossPatch
    {
        [CrossPostfix]
        [CrossPatch(typeof(FileSystemFileStorage), ".ctor")]
        public static void FileSystemFileStorage_Ctor(FileSystemFileStorage _instance)
        {
            typeof(FileSystemFileStorage).SetPrivateField(_instance, "_persistentDataPath", "/sdcard/CrossQuest/com.beatgames.beatsaber/files");
        }
    }
}