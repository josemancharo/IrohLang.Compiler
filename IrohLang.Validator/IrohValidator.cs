using IrohLang.AST;
using System.Collections.Generic;

namespace IrohLang.Validator;

public class IrohValidator
{
    public IEnumerable<ValidationMessage>? ValidationMessages { get; private set; }
    
    public void ValidateProgram(IrohProgram program)
    {

    }
}
