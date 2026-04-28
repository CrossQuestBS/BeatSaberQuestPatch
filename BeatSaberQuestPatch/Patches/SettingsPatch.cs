using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BeatSaber.Settings;
using Accord.Common.Attributes;
using OculusStudios.Platform.Oculus;
using UnityEngine;
using QualitySettings = BeatSaber.Settings.QualitySettings;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(SettingValidations), "AdjustQuest3", [typeof(Settings)])]
public partial class SettingsPatch
{
    public SettingsPatch()
    {
        Patch();
    }

    public void Postfix(ref Settings arg1)
    {
        var category = HardwareCategories.GetHardwareCategory();
        arg1 = SettingsManager.GetPlatformPreset(category);
    }
}