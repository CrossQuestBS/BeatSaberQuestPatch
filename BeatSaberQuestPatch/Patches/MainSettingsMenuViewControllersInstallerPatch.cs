using System;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(MainSettingsMenuViewControllersInstaller), "InstallBindings")]
[AccordPrefix]
public partial class MainSettingsMenuViewControllersInstallerPatch : IDisposable
{

    public MainSettingsMenuViewControllersInstallerPatch()
    {
        Patch();
    }
    
    public MethodInfo Method { get; } = typeof(MainSettingsMenuViewControllersInstaller).GetMethod("InstallBindings", (global::System.Reflection.BindingFlags)~0)!;
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