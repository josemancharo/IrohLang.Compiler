using IrohLang.AST.Models;
using System;

namespace IrohLang.Validator;

public record ValidationMessage(string ErrorMessage, Type? NodeType = null, ParserPosition? Position = null);
public record ValidationStatus(bool IsOk, ValidationMessage Message);

