using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser.Grammar
{
    public enum IrohToken
    {
        [Token(Category = "keyword", Example = "fn")]
        Fn,
        [Token(Category = "keyword", Example = "end")]
        End,
        [Token(Category = "syntax", Example = "(")]
        LParen,
        [Token(Category = "syntax", Example = ")")]
        RParen,
        [Token(Category = "literal", Example = "0")]
        Integer,
        [Token(Category = "literal", Example = "\"...\"")]
        String,
        [Token(Category = "literal", Example = "! Comment goes here")]
        Comment,
        [Token(Category = "identifier", Example = "my_identifier")]
        Identifier,
        [Token(Category = "syntax", Example = "::")]
        StaticAccess,
        [Token(Category = "keyword", Example = "const")]
        Const,
        [Token(Category = "keyword", Example = "val")]
        Val,
        [Token(Category = "syntax", Example = ";")]
        Semicolon,
        [Token(Category = "keyword", Example = "mut")]
        Mutable,
        Struct,
        Pipeline,
        Reference,
        Deref,
        Decimal,
        HexDigits,
        If,
        Else,
        Then,
        LSquare,
        RSquare,
        Plus,
        Mutation,
        Switch,
        LambdaArrow,
        On,
        For,
        LCurly,
        RCurly,
        Minus,
        Division,
        Multiply,
        Dot,
        Equals,
        NotEqual,
        LessThan,
        GreaterThan,
        LessThanOrEqualTo,
        GreaterThanOrEqualTo,
        Modulus,
        Module,
        Using,
        As,
        CharLiteral,
        Colon,
        BitwiseOr,
        BitwiseAnd,
        BitwiseXor,
        BitwiseRightShift,
        BitwiseLeftShift,
        Namespace,
        Enum,
        Comma,
        DateTime,
        TypedIdentifier,
        Assignment,
        Ever,
        True,
        False,
        And,
        Or,
        Public,
        Private,
        Internal,
        Protected
    }
}
