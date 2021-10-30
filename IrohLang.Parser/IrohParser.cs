namespace IrohLang.Parser;

public static class IrohParser
{
    public static readonly TokenListParser<IrohToken, IIrohExpression> StringPrimitive =
        Token.EqualTo(IrohToken.String).Select(x => (IIrohExpression)new IrohStringPrimitive(x.ToStringValue()));

    public static readonly TokenListParser<IrohToken, IrohFunction> Function =
        from begin in Token.EqualTo(IrohToken.Fn)
        from name in Token.EqualTo(IrohToken.Identifier)
        from args in Parse.Ref(() => ArgumentDefinitions!)
        from body in Parse.Ref(() => FunctionBody!).Between(Token.EqualTo(IrohToken.Colon), Token.EqualTo(IrohToken.End))
        select new IrohFunction(name.ToStringValue())
        {
            Arguments = args
                .Select(x => new KeyValuePair<string, IrohTypeReference>(x[1].ToStringValue(), new(x[0].ToStringValue())))
                .ToDictionary(x => x.Key, x => x.Value),
            Body = body
        };

    private static readonly TokenListParser<IrohToken, Token<IrohToken>[][]> ArgumentDefinitions =
        Token.EqualTo(IrohToken.Identifier)
            .Repeat(2)
            .ManyDelimitedBy(Token.EqualTo(IrohToken.Comma))
            .Between(Token.EqualTo(IrohToken.LParen), Token.EqualTo(IrohToken.RParen));

    public static readonly TokenListParser<IrohToken, IIrohExpression[]> Parameters = 
            Parse.Ref(() => Expression!)
            .ManyDelimitedBy(Token.EqualTo(IrohToken.Comma))
            .Between(Token.EqualTo(IrohToken.LParen), Token.EqualTo(IrohToken.RParen));

    public static readonly TokenListParser<IrohToken, IIrohExpression> FunctionInvocation =
        from access in Parse.Ref(() => ItemAccess!)
        from args in Parameters
        select (IIrohExpression) new IrohFunctionInvocation(access.Last().ToStringValue())
        {
            FullyQualifiedIdentifier = access.Select(x => x.ToStringValue()).ToArray(),
            Arguments = args,
        };

    public static readonly TokenListParser<IrohToken, Token<IrohToken>[]> ItemAccess =
        Token.EqualTo(IrohToken.Identifier)
            .AtLeastOnceDelimitedBy(Token.EqualTo(IrohToken.StaticAccess)
            .Or(Token.EqualTo(IrohToken.Dot)));

    public static readonly TokenListParser<IrohToken, IIrohExpression> PropertyReference =
        from item in Parse.Ref(() => ItemAccess!)
        select (IIrohExpression)new IrohPropertyReference(item[^1].ToStringValue())
        {
            FullyQualifiedIdentifier = item.Select(x => x.ToStringValue()).ToArray(),
        };

    public static readonly TokenListParser<IrohToken, IIrohExpression> Expression =
        from item in Parse.Ref(() => SubExpression!)
            .AtLeastOnceDelimitedBy(Token.EqualTo(IrohToken.Plus))
        select (IIrohExpression) new IrohExpression(item);

    public static readonly TokenListParser<IrohToken, IIrohExpression> SubExpression =
                Parse.OneOf(
                    Parse.Ref(() => StringPrimitive!).Try()
                    , Parse.Ref(() => FunctionInvocation!).Try()
                    , Parse.Ref(() => PropertyReference!).Try()
                );

    public static readonly TokenListParser<IrohToken, IIrohAST[]> FunctionBody =
        from any in Parse.OneOf(
            Parse.Ref(() => Expression!)
            )
            .ManyDelimitedBy(Token.EqualTo(IrohToken.Semicolon), 
                end: Token.EqualTo(IrohToken.Semicolon).OptionalOrDefault()
            )
        select (IIrohAST[])any;


    public static readonly TokenListParser<IrohToken, IrohTopLevelAST> TopLevelAST =
        from functions in Parse.Ref(() => Function!).Many()
        select new IrohTopLevelAST(functions);

}
