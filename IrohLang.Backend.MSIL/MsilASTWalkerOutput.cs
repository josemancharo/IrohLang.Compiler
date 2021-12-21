using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Backend.MSIL
{
    internal class MsilWalkerOutput
    {
        public MsilWalkerOutput(string assemblyName)
        {
            AssemblyName = assemblyName;
            AssemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new(assemblyName), AssemblyBuilderAccess.RunAndCollect);
        }
        public AssemblyBuilder AssemblyBuilder { get; }
        public string AssemblyName { get; set; }
    }
}
