using IrohLang.AST;
using IrohLang.AST.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Backend.Shared
{
    public interface IIrohCompileEmitter<TOutput> where TOutput : class
    {
        public TOutput Emit(IrohProgram input);   
    }
}
