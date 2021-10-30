using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohPropertyReference : IIrohExpression
    {
        public IrohPropertyReference(string name)
        {
            Name = name;
        }
        public string[]? FullyQualifiedIdentifier { get; set; }
        public string Name { get; set; }
    }
}
