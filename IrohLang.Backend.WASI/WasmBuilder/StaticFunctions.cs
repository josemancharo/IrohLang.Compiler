using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Backend.WASI.WasmBuilder
{
    internal static class StaticFunctions
    {
        public static string MangleName(string[] fullyQualifiedName)
        {
            return string.Join('_', fullyQualifiedName);
        }
    }
}
