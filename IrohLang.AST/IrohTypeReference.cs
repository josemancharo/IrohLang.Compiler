using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohTypeReference : IIrohAST
    {
        public IrohTypeReference(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
