using System;
using System.Collections.Generic;
using System.Linq;
using AsmResolver.DotNet;
using AsmResolver.DotNet.Code.Cil;
using AsmResolver.PE.DotNet.Cil;
using BeatSaberQuestPatch.Patches.Trampoline;
using Accord.ILTrampoline.Attributes;
using Accord.ILTrampoline.Interfaces;

namespace BeatSaberQuestPatch.Build;

[AccordTrampolineBuild(typeof(BeatSaberInit), "get_settingsApplicator", [], typeof(BeatSaberInitTrampoline))]
public class BeatSaberInitTrampolineBuild : IAccordTrampolineBuild
{
    public IEnumerable<Func<CilInstruction, CilMatch>> MatchInstructions()
    {
        yield return (instruction => instruction.OpCode == CilOpCodes.Ldarg_0 ? CilMatch.Start : CilMatch.None);
        yield return (instruction => instruction.OpCode == CilOpCodes.Ldfld ? CilMatch.End : CilMatch.None);
    }
    
    public IEnumerable<CilInstruction> PatchTrampoline(IEnumerable<CilInstruction> instructions,
        TypeDefinition definition, CilLocalVariable instance, ReferenceImporter importer)
    {
        yield return new CilInstruction(CilOpCodes.Ldloc, instance);
        yield return new CilInstruction(CilOpCodes.Ldarg_0);
        yield return new CilInstruction(CilOpCodes.Call, importer.ImportMethod(definition.Methods.FirstOrDefault(it => it.Name == nameof(BeatSaberInitTrampoline.PatchApplicator))));
    }
}