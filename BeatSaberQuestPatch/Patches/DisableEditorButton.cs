using System;
using CrossPatcher.Attributes;
using CrossPatcher.Interfaces;

namespace BeatSaberQuestPatch.Patches
{
    public class DisableEditorButton : ICrossPatch
    {  
        [CrossPostfix]
        [CrossPatch(typeof(MainMenuViewController), "DidActivate")]
        public static void DisableButton(MainMenuViewController _instance)
        {
            if (_instance._beatmapEditorButton == null) return;
            var instance = _instance._beatmapEditorButton.gameObject;
            instance.SetActive(false);
        }
    }
}
