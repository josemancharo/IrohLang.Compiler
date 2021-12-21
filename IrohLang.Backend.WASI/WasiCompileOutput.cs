using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Backend.WASI
{
    public class WasiCompileOutput
    {
        public StringBuilder WAT { get; init; } = new();
    }
}
