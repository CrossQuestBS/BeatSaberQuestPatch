using System;
using BeatSaberQuestPatch.Patches;
using CrossAccord;
using IPA;
using IPA.Logging;
using IPA.PluginInterfaces;

namespace BeatSaberQuestPatch;

[Plugin(RuntimeOptions.DynamicInit)]
public class Plugin
{
    public static Logger log { get; private set; }

    private CrossAccord.Common.Interfaces.IAccordPatch[] _patches;

    [Init]
    public Plugin(Logger logger)
    {
        log = logger;
        log.Notice("Basic plugin running!");
        _patches = [
            new BeatSaberInitPatch(), 
            new DisableEditorButton(),
            new DisableOnNonQuestPatch(),
            new FileSystemStoragePatch(),
            new HardwareCategoriesPatch(),
            new MainSettingsMenuViewControllersInstallerPatch(),
        ];
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
        log.Notice("Basic plugin EXIT!");
        // teardown
    }
}
