using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser.Grammar
{
    public static class GrammarDefinitions
    {
        public static readonly IrohToken[] TopLevelOnly = new[]
        {
            IrohToken.Const,
            IrohToken.Fn,
            IrohToken.Namespace,
            IrohToken.Module,
            IrohToken.Struct
        };

        public static readonly IrohToken[] Literals = new[]
        {
            IrohToken.String,
            IrohToken.Integer,
            IrohToken.Decimal,
            IrohToken.DateTime
        };

        public static readonly IrohToken[] Operators = new[]
        {
            IrohToken.NotEqual,
            IrohToken.Equals,
            IrohToken.GreaterThan,
            IrohToken.LessThan,
            IrohToken.And,
            IrohToken.Or,
            
            IrohToken.Pipeline,

            IrohToken.Minus,
            IrohToken.Plus,
            IrohToken.Division,
            IrohToken.Multiply,

            IrohToken.BitwiseAnd,
            IrohToken.BitwiseLeftShift,
            IrohToken.BitwiseOr,
            IrohToken.BitwiseRightShift,
            IrohToken.BitwiseXor
        };
    }
}
