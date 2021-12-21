using IrohLang.AST.Organization;

namespace IrohLang.AST;
public class IrohProgram
{
    public string? ProgramName { get; set; }
    public IEnumerable<IrohNamespace>? Namespaces { get; set; }

    public IrohProgram(IEnumerable<IrohFile> files)
    {
        Namespaces = files
            .Select(x => x.Namespace with 
            { 
                Modules = x.Namespace.Modules ?? new List<IrohModule>() 
            })
            .GroupBy(x => x.NameAsString)
            .Select(x => x.First());

        var nsWithModules = from ns in Namespaces
                            join file in files
                                on ns.NameAsString equals file.Namespace.NameAsString
                            select ns with { 
                                Modules = ns.Modules?.Append(file.Module with { Elements = file.TopLevelElements }) 
                            };
    }
}

