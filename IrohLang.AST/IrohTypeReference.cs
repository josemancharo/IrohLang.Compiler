using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohTypeReference(string[] FullyQualifiedName) : IIrohAST
    {
        public string TypeName => nameof(IrohTypeReference);
        public ParserPosition? Position { get; init; }

        public string Name => FullyQualifiedName.Last();
    }
}
