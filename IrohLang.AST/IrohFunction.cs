using IrohLang.AST.Models;
using IrohLang.Parser.AST.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohFunction : IIrohFunction
    {
        public string TypeName => nameof(IrohFunction);
        public ParserPosition? Position { get; init; }

        public IrohFunction(string name)
        {
            Name = name;
        }
        public AccessModifier AccessModifier { get; set; } = AccessModifier.Internal;
        public string Name { get; set; }
        public IEnumerable<IIrohExpression>? Body { get; init; }
        public IrohTypeReference? ReturnType { get; set; }
        public Dictionary<string, IrohTypeReference>? Arguments { get; set; }
    }

    public record IrohFunctionInvocation : IrohPropertyReference
    {
        public IrohFunctionInvocation(string[] FullyQualifiedIdentifier) : base(FullyQualifiedIdentifier) { }
        public IEnumerable<IIrohExpression>? Arguments { get; set; }
    }
}
