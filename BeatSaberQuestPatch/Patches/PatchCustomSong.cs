using System.IO;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;


/// <summary>
/// Update the path where customs songs should be loaded from
/// TODO: Integrate into SongCore
/// </summary>
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