using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohStringPrimitive : IIrohExpression
    {
        public string Value { get; set; }

        public IrohStringPrimitive(string value)
        {
            Value = value[1..^1];
        }
    }
}
