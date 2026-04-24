using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Transpiler.Attributes;
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using BeatSaberQuestPatch.Patches.Trampoline;
using Accord.Transpiler.Interfaces;

namespace BeatSaberQuestPatch.Build;

[AccordTranspiler(typeof(BeatSaberInit), "get_settingsApplicator", [], typeof(BeatSaberInitTranspilerInstance))]
public class BeatSaberInitTrampolineBuild : IAccordTranspilerInstance
{
    public IAccordTranspiler[] TranspilerList { get; } = [new ReplaceSettingsApplicator()];

    public class ReplaceSettingsApplicator : IAccordTranspiler
    {
        public IEnumerable<Func<CilInstruction, CilMatch>> Match()
        {
            yield return (instruction => instruction.OpCode == CilOpCodes.Ldarg_0 ? CilMatch.Start : CilMatch.None);
            yield return (instruction => instruction.OpCode == CilOpCodes.Ldfld ? CilMatch.End : CilMatch.None);
        }

        public IEnumerable<CilInstruction> Modify(IEnumerable<CilInstruction> instructions, TypeDefinition definition, IMethodDefOrRef getInstance,
            ReferenceImporter importer)
        {
            yield return new CilInstruction(CilOpCodes.Call, getInstance);
            yield return new CilInstruction(CilOpCodes.Ldarg_0);
            yield return new CilInstruction(CilOpCodes.Call, importer.ImportMethod(definition.Methods.FirstOrDefault(it => it.Name == nameof(BeatSaberInitTranspilerInstance.PatchApplicator))));
        }
    }

}