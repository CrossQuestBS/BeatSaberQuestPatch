using IPA.Config.Stores.Attributes;
using IPA.Config;
using IPA.Config.Stores;

namespace BeatSaberQuestPatch.Patches;

[Config]
public class PluginConfig
{
    public static PluginConfig Instance { get; set; }

    public virtual string Example { get; set; } = "Whatever!";
}