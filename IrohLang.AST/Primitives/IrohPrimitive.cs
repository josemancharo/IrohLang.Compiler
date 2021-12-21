using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST.Primitives
{
    public abstract record IrohPrimitive<T> : IIrohExpression
    {
        public ParserPosition? Position { get; init; }
        public abstract string TypeName { get; }
        public T Value { get; set; }

        public IrohPrimitive(T value)
        {
            Value = value;
        }
    }
}
