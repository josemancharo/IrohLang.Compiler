using IrohLang.AST.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser;
public static partial class IrohParser
{
    public static readonly TokenListParser<IrohToken, IrohFile> File =
      from @namespace in Parse.Ref(() => ItemAccess!)
        .Between(Token.EqualTo(IrohToken.Namespace), Token.EqualTo(IrohToken.Semicolon))
        .AsNullable().OptionalOrDefault()
      from usings in Parse.Ref(() => ItemAccess!)
        .Between(Token.EqualTo(IrohToken.Using), Token.EqualTo(IrohToken.Semicolon))
        .Many()
      from module in Parse.Ref(() => ItemAccess!)
        .Between(Token.EqualTo(IrohToken.Module), Token.EqualTo(IrohToken.Semicolon))
        .AsNullable().OptionalOrDefault()
      from functions in Parse.Ref(() => Function!).Many()
      let ns = @namespace == null ? IrohNamespace.Default : new(@namespace.Select(x => x.ToStringValue()).ToArray())
      let mod = module == null ? IrohModule.Default : new(module.Select(x => x.ToStringValue()).ToArray())
      select new IrohFile(functions)
      {
          Namespace = ns,
          Module = mod,
      };

    public static readonly TokenListParser<IrohToken, IrohFunction> Function =
        from begin in Token.EqualTo(IrohToken.Fn)
        from returnType in Parse.Ref(() => ItemAccess!)
            .Between(Token.EqualTo(IrohToken.LessThan), Token.EqualTo(IrohToken.GreaterThan))
            .AsNullable().OptionalOrDefault()
        from name in Token.EqualTo(IrohToken.Identifier)
        from args in Parse.Ref(() => ArgumentDefinitions!)
        from body in Parse.Ref(() => Block!)
        let rt = returnType == null ? (IrohTypeReference?)null : new(returnType.Select(x => x.ToStringValue()).ToArray())
        select new IrohFunction(name.ToStringValue())
        {
            Arguments = args
                .Select(x => new KeyValuePair<string, IrohTypeReference> (x.Name.ToStringValue(), new(x.TypeName.Select(x => x.ToStringValue()).ToArray())))
                .ToDictionary(x => x.Key, x => x.Value),
            Body = body,
            Position = begin.Position.AsParserPosition(),
            ReturnType = rt,
        };
}
