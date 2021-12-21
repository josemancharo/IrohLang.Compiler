using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST
{
    public record IrohPropertyReference(string[] FullyQualifiedIdentifier) : IIrohExpression
    {
        public string TypeName => nameof(IrohPropertyReference);
        public ParserPosition? Position { get; init; }
        public PropertyReferenceFlag PropertyReferenceFlag { get; init; } = PropertyReferenceFlag.None;
        public string Name => FullyQualifiedIdentifier[^1];
    }

    public enum PropertyReferenceFlag
    {
        Ref,
        Deref,
        None,
    }
}
