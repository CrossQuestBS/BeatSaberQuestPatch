using IPA;
using IPA.Logging;
using IPA.PluginInterfaces;

namespace BeatSaberQuestPatch;

[Plugin(RuntimeOptions.DynamicInit)]
public class Plugin
{
    public static Logger log { get; private set; }

    [Init]
    public Plugin(Logger logger)
    {
        log = logger;
        log.Notice("Basic plugin running!");
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
        log.Notice("Basic plugin EXIT!");
        // teardown
    }
}
