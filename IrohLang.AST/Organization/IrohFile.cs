using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST.Organization
{
    public record IrohFile : IIrohAST
    {
        public string TypeName => nameof(IrohFile);
        public ParserPosition? Position { get; init; }
        public IrohNamespace Namespace { get; init; } = IrohNamespace.Default;
        public IrohModule Module { get; init; } = IrohModule.Default;
        public string? FileName { get; set; }
        public IEnumerable<IIrohAST> TopLevelElements { get; set; }

        public IrohFile(IEnumerable<IIrohAST> topLevelElements)
        {
            TopLevelElements = topLevelElements;
        }
    }
}
