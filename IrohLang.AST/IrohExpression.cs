using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohExpression : IIrohExpression
    {
        public IEnumerable<IIrohExpression> SubExpressions { get; set; }

        public IrohExpression(IEnumerable<IIrohExpression> subExpressions)
        {
            SubExpressions = subExpressions;
        }
    }
}
