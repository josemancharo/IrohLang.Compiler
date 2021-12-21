using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.AST.Organization;
public record IrohNamespace(string[] FullyQualifiedName) 
{
    private const string DEFAULT_NAME = "Project";

    public static readonly IrohNamespace Default = new(new[] { DEFAULT_NAME });
    public ParserPosition? Position { get; init; }
    public string TypeName => nameof(IrohNamespace);
    public IEnumerable<IrohModule>? Modules { get; set; }

    public string NameAsString => string.Join("", FullyQualifiedName);
}
