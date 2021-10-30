using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohModule : IIrohTopLevelElement
    {
        public const string DEFAULT_NAME = "main";
        public string Name { get; set; } = DEFAULT_NAME;
        public IEnumerable<IIrohAST>? Body { get; set; }
    }
}
