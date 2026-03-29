using System;
using System.Collections.Generic;
using System.Linq;
using BeatSaberQuestPatch.Patches.Trampoline;
using CrossAccord.ILTrampoline.Attributes;
using CrossAccord.ILTrampoline.Interfaces;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace BeatSaberQuestPatch.Build;

[AccordTrampolineBuild(typeof(BeatSaberInit), "get_settingsApplicator", typeof(BeatSaberInitTrampoline))]
public class BeatSaberInitTrampolineBuild : IAccordTrampolineBuild
{
    /*
     *    // [56 59 - 56 93]
        IL_0000: ldarg.0      // this
        IL_0001: ldfld        class [Main]SettingsApplicatorSO BeatSaberInit::_standaloneSettingsApplicator
        IL_0006: ret
     */
    
    public bool StartOffset(Instruction instructions)
    {
        return instructions.OpCode == OpCodes.Ldarg_0;
    }

    public bool EndOffset(Instruction instructions)
    {
        if (instructions.Operand is not FieldReference fieldRef)
            return false;
        
        return instructions.OpCode == OpCodes.Ldfld && fieldRef.Name.Contains("_standaloneSettingsApplicator");
    }

    public IEnumerable<Instruction> PatchTrampoline(IEnumerable<Instruction> instructions, TypeDefinition definition, VariableDefinition instance)
    {
        var typeDef = instance.VariableType.Resolve();
        foreach (var method in typeDef.Methods)
        {
            Console.WriteLine(method.Name);
        }
        var methodToCall = typeDef.Methods.First(it => it.Name.Contains("PatchApplicator"));
        var methodToCallRef = definition.Module.ImportReference(methodToCall);
        foreach (var instruction in instructions)
        {
            if (instruction.OpCode == OpCodes.Ldarg_0)
            {
                yield return Instruction.Create(OpCodes.Ldloc, instance);
                yield return instruction;
            }
            else if (instruction.OpCode == OpCodes.Ldfld)
            {
                yield return Instruction.Create(OpCodes.Call, methodToCallRef);
            }
        }
    }

    public int Matches => 1;
}