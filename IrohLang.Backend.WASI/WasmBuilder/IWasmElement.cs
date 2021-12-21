using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Backend.WASI.WasmBuilder
{
    internal interface IWasmElement<TInput>
    {
        void AddStart(TInput input, StringBuilder builder);
        void AddEnd(TInput input, StringBuilder builder);
    }
}
