using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST.Primitives
{
    public record IrohStringPrimitive : IrohPrimitive<string>
    {
        public IrohStringPrimitive(string value) : base(value)
        {
            Value = value[1..^1];
        }

        public override string TypeName => nameof(IrohStringPrimitive);
    }
}
