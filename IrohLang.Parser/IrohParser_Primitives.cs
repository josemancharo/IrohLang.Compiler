using IrohLang.AST.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser;
public static partial class IrohParser
{
    public static readonly TokenListParser<IrohToken, IIrohExpression> StringPrimitive =
      Token.EqualTo(IrohToken.String).Select(x => (IIrohExpression)new IrohStringPrimitive(x.ToStringValue()));

    public static readonly TokenListParser<IrohToken, IIrohExpression> IntegerPrimtive =
        Token.EqualTo(IrohToken.Integer).Select(x =>
        {
            int.TryParse(x.ToStringValue(), out var y);
            return y;
        })
        .Select(x => (IIrohExpression)new IrohIntegerPrimtive(x));

}
