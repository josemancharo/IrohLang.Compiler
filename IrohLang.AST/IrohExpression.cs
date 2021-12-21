namespace IrohLang.AST
{
    public record IrohExpression(IEnumerable<IIrohExpression> SubExpressions) : IIrohExpression
    {
        public string TypeName => nameof(IrohExpression);
        public ParserPosition? Position { get; init; }

    }
}
