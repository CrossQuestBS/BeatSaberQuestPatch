using System.Threading.Tasks;
using Accord.Common.Attributes;
using OculusStudios.Platform.Oculus;

namespace BeatSaberQuestPatch.Patches;

[AccordPatch(typeof(PlatformUser), "InternalGetAccessTokenAsync", [])]
[AccordPrefix]
public partial class StopTryingGettingToken
{
    public StopTryingGettingToken()
    {
        Patch();
    }

    public bool Prefix(PlatformUser instance, ref Task returnValue)
    {
        returnValue = Task.CompletedTask;
        return false;
    }
}