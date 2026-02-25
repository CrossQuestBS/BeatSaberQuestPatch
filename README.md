# BeatSaberQuestPatch

Patches PC Beat Saber to use Quest related code

## Patches

### Use Quest Settings
QuestSettingsApplier instead of PC specific.
This is to make sure correct settings are set for Quest.

### Disable Editor Button
Editor button is not useful on Quest version, so the mod disables it.

### Use external storage folder for saving settings.
FileSystemStorage is patched to use `/sdcard/CrossQuest/com.beatgames.beatsaber/files` as a persistentDataPath.

### Get correct Quest specific settings
GetHardwareCategory is patched to use Oculus SDK code to fetch which headset the game is running on.

### Use Quest Specific Settings UI
MainSettingsMenuViewControllersInstaller is patched to use Quest settings UI instead of PC settings UI.

### Show option for 120hz for headsets that support it
Graphics UI is patched to show this, instead of being a hardcoded value from PC.
