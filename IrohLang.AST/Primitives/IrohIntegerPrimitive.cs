namespace IrohLang.AST.Primitives
{

    public record IrohIntegerPrimtive : IrohPrimitive<int>
    {
        public IrohIntegerPrimtive(int value) : base(value) {}
        public override string TypeName => nameof(IrohIntegerPrimtive);
    }
}
