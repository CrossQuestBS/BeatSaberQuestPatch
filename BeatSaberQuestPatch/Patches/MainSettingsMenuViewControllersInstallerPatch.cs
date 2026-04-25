using System;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

/// <summary>
/// This patch here to use correct Graphic Settings for Quest
/// </summary>
[AccordPatch(typeof(MainSettingsMenuViewControllersInstaller), "InstallBindings", [])]
[AccordPrefix]
public partial class MainSettingsMenuViewControllersInstallerPatch : IDisposable
{

    public MainSettingsMenuViewControllersInstallerPatch()
    {
        Patch();
    }
    
    public bool Prefix(MainSettingsMenuViewControllersInstaller instance)
    {
        instance._oculusPCSettingsMenuViewController = instance._questSettingsMenuViewController;
        return true;
    }

    public void Dispose()
    {
        Unpatch();
    }
}