using System;
using System.Linq;
using System.Reflection;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

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