using IrohLang.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Backend.Shared
{
    public interface IIrohCompiler
    {
        byte[] EmitExecutable(IIrohAST input);
        byte[] EmitLibrary(IIrohAST input);
    }
}
