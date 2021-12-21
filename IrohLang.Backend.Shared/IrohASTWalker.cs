using IrohLang.AST;
using IrohLang.AST.Organization;

namespace IrohLang.Backend.Shared
{
    public class IrohASTWalker<TWalker, TOutput> where TWalker : IIrohCompileEmitter<TOutput>, new() where TOutput : class, new()
    {
        private readonly TWalker _walker = new();
        private TOutput? _output;
        public TOutput WalkAST(IrohProgram ast)
        {
            _output = new();
            

            return _output;
        }
    }
}
