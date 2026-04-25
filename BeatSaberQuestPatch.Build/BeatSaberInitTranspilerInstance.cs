using System;
using System.Collections.Generic;
using System.Linq;
using Accord.Transpiler.Attributes;
using AsmResolver.DotNet;
using AsmResolver.PE.DotNet.Cil;
using Accord.Transpiler.Interfaces;
using BeatSaberQuestPatch.Patches.Transpiler;
using Accord.Transpiler.Helper;

namespace BeatSaberQuestPatch.Build;

[AccordTranspiler(typeof(BeatSaberInit), "get_settingsApplicator", [], typeof(BeatSaberInitPatch))]
public class BeatSaberInitTranspilerInstance : IAccordTranspilerInstance
{
    public IAccordTranspiler[] TranspilerList { get; } = [new ReplaceSettingsApplicator()];

    public class ReplaceSettingsApplicator : IAccordTranspiler
    {
        public IEnumerable<Func<CilInstruction, CilMatch>> Match()
        {
            yield return ins => ins.MatchStart(CilOpCodes.Ldarg_0);
            yield return ins => ins.MatchEnd(CilOpCodes.Ldfld);
        }

        public IEnumerable<CilInstruction> Modify(IEnumerable<CilInstruction> instructions, TypeDefinition definition, IMethodDefOrRef getInstance,
            ReferenceImporter importer)
        {
            var PatchApplicator =
                importer.ImportMethod(definition.Methods.FirstOrDefault(it =>
                    it.Name == nameof(BeatSaberInitPatch.PatchApplicator)));
            
            yield return new CilInstruction(CilOpCodes.Call, getInstance);
            yield return new CilInstruction(CilOpCodes.Ldarg_0);
            yield return new CilInstruction(CilOpCodes.Call, PatchApplicator);
        }
    }

}