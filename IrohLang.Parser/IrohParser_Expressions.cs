namespace IrohLang.Parser;

public static partial class IrohParser
{
    public static readonly TokenListParser<IrohToken, IIrohExpression> FunctionInvocation =
        from access in Parse.Ref(() => ItemAccess!)
        from args in Parse.Ref(() => Parameters!)
        select (IIrohExpression)new IrohFunctionInvocation(access.Select(x => x.ToStringValue()).ToArray())
        {
            FullyQualifiedIdentifier = access.Select(x => x.ToStringValue()).ToArray(),
            Arguments = args,
        };

    public static readonly TokenListParser<IrohToken, Token<IrohToken>[]> ItemAccess =
        Token.EqualTo(IrohToken.Identifier)
            .AtLeastOnceDelimitedBy(
                Token.EqualTo(IrohToken.StaticAccess)
                .Or(Token.EqualTo(IrohToken.Dot)
                ));

    public static readonly TokenListParser<IrohToken, IIrohExpression> PropertyReference =
        from @ref in Parse.Ref(() => Token.EqualTo(IrohToken.Reference)).Optional()
        from deref in Parse.Ref(() => Token.EqualTo(IrohToken.Deref)).Optional()
        from item in Parse.Ref(() => ItemAccess!)
        select (IIrohExpression)new IrohPropertyReference(item.Select(x => x.ToStringValue()).ToArray())
        {
            PropertyReferenceFlag = (@ref, deref) switch
            {
                (not null, null) => PropertyReferenceFlag.Ref,
                (null, not null) => PropertyReferenceFlag.Deref,
                _ => PropertyReferenceFlag.None
            }
        };

    public static readonly TokenListParser<IrohToken, IIrohExpression> Expression =
        from item in Parse.Ref(() => SubExpression!)
            .AtLeastOnceDelimitedBy(Token.EqualTo(IrohToken.Plus))
        select (IIrohExpression)new IrohExpression(item);

    public static readonly TokenListParser<IrohToken, IIrohExpression> SubExpression =
                Parse.OneOf(
                    Parse.Ref(() => StringPrimitive!).Try()
                    , Parse.Ref(() => FunctionInvocation!).Try()
                    , Parse.Ref(() => PropertyReference!).Try()
                );

}
