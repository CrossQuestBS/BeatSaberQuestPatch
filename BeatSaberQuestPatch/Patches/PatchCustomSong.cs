using System.IO;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(FileSystemCustomLevelProvider), ".ctor", [])]
[AccordPostfix]
public partial class PatchCustomSongs
{
    public PatchCustomSongs()
    {
        Patch();
    }
    
    public void Postfix(FileSystemCustomLevelProvider instance)
    {
        var path = "/sdcard/CrossQuest/com.beatgames.beatsaber";
        typeof(CustomLevelPathHelper).SetPublicStaticField("baseProjectPath",
            path);
        typeof(CustomLevelPathHelper).SetPublicStaticField("customLevelsDirectoryPath", Path.Join(path, "CustomLevels"));
    }
}