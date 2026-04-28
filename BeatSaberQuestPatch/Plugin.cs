using System;
using BeatSaberQuestPatch.Patches;
using BeatSaberQuestPatch.Patches.Transpiler;
using Accord.Common.Interfaces;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using IPA.Logging;
using IPA.PluginInterfaces;

namespace BeatSaberQuestPatch;

[Plugin(RuntimeOptions.DynamicInit)]
public class Plugin
{
    public static Logger log { get; private set; }

    private IAccordPatch[] _patches;

    [Init]
    public Plugin(Logger logger, Config config)
    {
        log = logger;
        
        // PluginConfigImpl is a C# Source Generated class
        PluginConfig.Instance = config.Generated<PluginConfigImpl>();
        
        // This initializes all patches and enables them
        _patches = [
            new DisableEditorButton(),
            new DisableOnNonQuestPatch(),
            new FileSystemStoragePatch(),
            new HardwareCategoriesPatch(),
            new MainSettingsMenuViewControllersInstallerPatch(),
            new SettingsApplicatorSoPatch(),
            new QuestGraphicSettingsViewControllerPatch(),
            new EnableCustomSongsPatch(),
            new PatchCustomSongs(),
            //new SettingsPatch(),
            new StopTryingGettingToken(),
        ];

        BeatSaberInitPatch.Instance = new BeatSaberInitPatch();
    }

    [OnStart]
    public void OnStart()
    {
        log.Notice("Basic plugin starting!");
        // setup that requires game code
    }

    [OnExit]
    public void OnExit()
    {
        foreach (var accordPatch in _patches)
        {
            if (accordPatch is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
        log.Notice("Basic plugin Exit!");
        // teardown
    }
}
