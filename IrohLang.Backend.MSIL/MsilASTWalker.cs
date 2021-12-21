using IrohLang.Backend.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;
using IrohLang.AST;
using IrohLang.AST.Organization;
using IrohLang.Parser.AST.Enums;

namespace IrohLang.Backend.MSIL;
internal class IrohMSILEmitter : IIrohCompileEmitter<MsilWalkerOutput>
{
    public MsilWalkerOutput Emit(IrohProgram input)
    {
        var output = new MsilWalkerOutput(input.ProgramName!);
        if (input.Namespaces == null)
        {
            foreach (var ns in input.Namespaces!)
            {
                AddNamespace(ns, output.AssemblyBuilder);
            }
        }
        return output;
    }

    private static void AddNamespace(IrohNamespace ns, AssemblyBuilder asmb)
    {
        var @namespace = asmb.DefineDynamicModule(ns.NameAsString);
        if (ns.Modules != null)
        {
            foreach (var mod in ns.Modules)
            {
                AddModule(mod, @namespace);
            }
        }
    }

    private static void AddModule(IrohModule mod, ModuleBuilder cn)
    {
        var module = cn.DefineType(mod.Name,
                TypeAttributes.Class
                | TypeAttributes.Abstract
                | TypeAttributes.Sealed
                | TypeAttributes.BeforeFieldInit
                | TypeAttributes.AnsiClass);

        if (mod.Elements != null)
        {
            foreach (var elem in mod.Elements)
            {
                switch (elem)
                {
                    case IrohFunction fn:
                        AddFunction(fn, module);
                        break;
                    default:
                        break;
                }
            }
        }

    }

    private static void AddFunction(IrohFunction fn, TypeBuilder tb)
    {
        var methodProperties =
            MethodAttributes.HideBySig
            | MethodAttributes.Final
            | MethodAttributes.Static
            | fn.AccessModifier switch
            {
                AccessModifier.Public => MethodAttributes.Public,
                AccessModifier.Private => MethodAttributes.Private,
                AccessModifier.Protected => MethodAttributes.FamORAssem,
                AccessModifier.ProtectedInternal => MethodAttributes.FamANDAssem,
                _ => MethodAttributes.Assembly,
            };
        var methodBuilder = tb.DefineMethod(fn.Name, methodProperties);

        var args = fn.Arguments?.ToList();
        if (args != null)
        {
            var parameterTypes = new Type[args.Count];
            for (int i = 0; i < args.Count; i++)
            {
                methodBuilder.DefineParameter(i, ParameterAttributes.None, args[i].Key);
                parameterTypes[i] = Type.GetType(args[i].Value.Name) ?? typeof(object);
            }
            methodBuilder.SetReturnType(Type.GetType(fn.TypeName));
            methodBuilder.SetParameters(parameterTypes);
        }
        if (fn.Body != null)
        {
            foreach (var ast in fn.Body)
            {
                AddExpression(ast, methodBuilder);
            }
        }
    }

    private static void AddExpression(IIrohExpression line, MethodBuilder builder)
    {
        var generator = builder.GetILGenerator();

        switch (line)
        {
            case IrohFunctionInvocation func:
                AddFunctionInvocation(func, generator);
                break;
        }
    }

    private static void AddFunctionInvocation(IrohFunctionInvocation func, ILGenerator generator)
    {
        var qualifier = string.Join("", func.FullyQualifiedIdentifier[..^1]);
        generator.EmitCall(OpCodes.Call, new MethodInfo())
    }
}
