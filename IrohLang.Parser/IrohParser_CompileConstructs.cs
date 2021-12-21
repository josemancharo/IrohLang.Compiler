using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser;
public static partial class IrohParser
{
    public static readonly TokenListParser<IrohToken, IIrohExpression[]> Block =
        Parse.Ref(() => Expression!)
        .ManyDelimitedBy(Token.EqualTo(IrohToken.Semicolon), 
            end: Token.EqualTo(IrohToken.Semicolon).OptionalOrDefault())
        .Between(Token.EqualTo(IrohToken.LCurly), Token.EqualTo(IrohToken.RCurly));

    private static readonly TokenListParser<IrohToken, ParsedFunctionArgument> ArgumentDefinition =
        from type in Parse.Ref(() => ItemAccess!)
        from name in Token.EqualTo(IrohToken.Identifier)
        select new ParsedFunctionArgument(type, name);

    private static readonly TokenListParser<IrohToken, ParsedFunctionArgument[]> ArgumentDefinitions =
        Parse.Ref(() => ArgumentDefinition!)
        .ManyDelimitedBy(Token.EqualTo(IrohToken.Comma))
        .Between(Token.EqualTo(IrohToken.LParen), Token.EqualTo(IrohToken.RParen));

    public static readonly TokenListParser<IrohToken, IIrohExpression[]> Parameters =
        Parse.Ref(() => Expression!)
        .ManyDelimitedBy(Token.EqualTo(IrohToken.Comma))
        .Between(Token.EqualTo(IrohToken.LParen), Token.EqualTo(IrohToken.RParen));

    private record ParsedFunctionArgument(Token<IrohToken>[] TypeName, Token<IrohToken> Name);
}

