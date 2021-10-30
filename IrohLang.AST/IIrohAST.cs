using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public interface IIrohAST
    {

    }

    public interface IIrohTopLevelElement : IIrohAST
    {
        IEnumerable<IIrohAST>? Body { get; set; }
    }

    public interface IIrohExpression : IIrohAST
    {

    }
}

