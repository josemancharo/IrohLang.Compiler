using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST.Organization
{
    public record IrohModule(string[] FullyQualifiedName) : IIrohTypeDefinition
    {
        public ParserPosition? Position { get; init; }
        private const string DEFAULT_NAME = "Main";
        public string Name => FullyQualifiedName.Last();
        public string TypeName => nameof(IrohModule);

        public readonly static IrohModule Default = new(new[] { DEFAULT_NAME });
        public IEnumerable<IIrohAST>? Elements { get; init; }
    }
}
