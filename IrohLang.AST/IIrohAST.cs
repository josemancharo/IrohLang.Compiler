

namespace IrohLang.AST
{
    public interface IIrohAST
    {
        public string TypeName { get; }
        public ParserPosition? Position { get; init; }
    }

    public interface IIrohFunction : IIrohAST
    {
        IEnumerable<IIrohExpression>? Body { get; init; }
    }

    public interface IIrohTypeDefinition : IIrohAST
    {

    }

    public interface IIrohExpression : IIrohAST
    {

    }
}

