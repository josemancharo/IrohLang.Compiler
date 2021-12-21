using IrohLang.AST.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static IrohLang.Backend.WASI.WasmBuilder.StaticFunctions;

namespace IrohLang.Backend.WASI.WasmBuilder
{
    internal class WasmModule : IWasmElement<IrohModule>
    {
        public void AddEnd(IrohModule input, StringBuilder builder)
        {
            builder.Append(')');
        }

        public void AddStart(IrohModule input, StringBuilder builder)
        {
            builder.Append($"(module ${MangleName(input.FullyQualifiedName)}");
        }
    }
}
