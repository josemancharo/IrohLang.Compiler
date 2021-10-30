using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohTopLevelAST : IIrohAST
    {
        public IEnumerable<IIrohTopLevelElement> TopLevelElements { get; set; }

        public IrohTopLevelAST(IEnumerable<IIrohTopLevelElement> topLevelElements)
        {
            TopLevelElements = topLevelElements;
        }
    }
}
