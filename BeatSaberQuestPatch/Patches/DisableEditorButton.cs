using System;
using Accord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches
{
    [AccordPatch(
        typeof(MainMenuViewController), 
        "DidActivate", 
        [typeof(bool), typeof(bool), typeof(bool)]
    )]
    [AccordPostfix]
    public partial class DisableEditorButton : IDisposable
    {

        public DisableEditorButton()
        {
            Patch();
        }
        
        public void Postfix(MainMenuViewController instance, ref bool arg1, ref bool arg2, ref bool arg3)
        {
            if (instance._beatmapEditorButton == null) return;
            var button = instance._beatmapEditorButton.gameObject;
            button.SetActive(false);
        }

        public void Dispose()
        {
            Unpatch();
        }
    }
}
