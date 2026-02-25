using System;
using System.Reflection;
using CrossAccord.Common.Attributes;

namespace BeatSaberQuestPatch.Patches
{
    [AccordPatch(typeof(MainMenuViewController), "DidActivate")]
    [AccordPostfix]
    public partial class DisableEditorButton : IDisposable
    {

        public DisableEditorButton()
        {
            Patch();
        }
        
        public MethodInfo Method { get; } = typeof(MainMenuViewController).GetMethod("DidActivate", (global::System.Reflection.BindingFlags)~0)!;
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
