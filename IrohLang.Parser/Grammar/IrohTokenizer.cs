using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace IrohLang.Parser.Grammar
{
    public static class IrohTokenizer
    {
        public static readonly Tokenizer<IrohToken> Tokenizer = new TokenizerBuilder<IrohToken>()          
            .Match(Comment.ToEndOfLine(Span.EqualTo("!")), IrohToken.Comment) // v0.0.1

            .Match(QuotedString.SqlStyle, IrohToken.String) // v0.0.1
            .Match(Span.Regex(@"\\.", RegexOptions.Compiled), IrohToken.CharLiteral, true)
            
            .Ignore(Span.WhiteSpace) // v0.0.1

            .Match(Span.EqualTo("mod"), IrohToken.Module, true)
            .Match(Span.EqualTo("namespace"), IrohToken.Namespace, true)
            .Match(Span.EqualTo("use"), IrohToken.Using, true)
            .Match(Span.EqualTo("as"), IrohToken.As, true)
            .Match(Span.EqualTo("public"), IrohToken.Public, true)
            .Match(Span.EqualTo("private"), IrohToken.Private, true)
            .Match(Span.EqualTo("internal"), IrohToken.Internal, true)
            .Match(Span.EqualTo("protected"), IrohToken.Protected, true)

            .Match(Span.EqualTo("fn"), IrohToken.Fn, true) // v0.0.1
            .Match(Span.EqualTo("end"), IrohToken.End, true) // v0.0.1
            .Match(Span.EqualTo("val"), IrohToken.Val, true)
            .Match(Span.EqualTo("mut"), IrohToken.Mutable, true)
            .Match(Span.EqualTo("const"), IrohToken.Const, true)
            .Match(Span.EqualTo("struct"), IrohToken.Struct, true)
            .Match(Span.EqualTo("enum"), IrohToken.Enum, true)

            .Match(Span.EqualTo("if"), IrohToken.If, true)
            .Match(Span.EqualTo("then"), IrohToken.Then, true)
            .Match(Span.EqualTo("else"), IrohToken.Else, true)
            .Match(Span.EqualTo("switch"), IrohToken.Switch, true)
            .Match(Span.EqualTo("on"), IrohToken.On, true)
            .Match(Span.EqualTo("for"), IrohToken.For, true)
            
            .Match(Character.EqualTo('('), IrohToken.LParen) // v0.0.1
            .Match(Character.EqualTo(')'), IrohToken.RParen) // v0.0.1
            .Match(Character.EqualTo('['), IrohToken.LSquare)
            .Match(Character.EqualTo(']'), IrohToken.RSquare)
            .Match(Character.EqualTo('{'), IrohToken.LCurly)
            .Match(Character.EqualTo('}'), IrohToken.RCurly)

            .Match(Numerics.Decimal, IrohToken.Decimal, true)
            .Match(Numerics.Integer, IrohToken.Integer, true)
            .Match(Span.EqualTo("true"), IrohToken.True, true)
            .Match(Span.EqualTo("false"), IrohToken.False, true)
            .Match(Instant.Iso8601DateTime
                .Between(Span.EqualTo("d'"), Span.EqualTo("'")), 
                IrohToken.DateTime, true)

            .Match(Span.EqualTo("::"), IrohToken.StaticAccess)
            .Match(Character.EqualTo(';'), IrohToken.Semicolon)
            .Match(Span.EqualTo("|>"), IrohToken.Pipeline)
            .Match(Character.EqualTo('$'), IrohToken.Reference)
            .Match(Character.EqualTo('~'), IrohToken.Deref)
            .Match(Span.EqualTo("<-"), IrohToken.Mutation)
            .Match(Span.EqualTo("=>"), IrohToken.LambdaArrow)
            .Match(Character.EqualTo('.'), IrohToken.Dot)
            .Match(Character.EqualTo(','), IrohToken.Comma)
            .Match(Character.EqualTo(':'), IrohToken.Colon)
            .Match(Character.EqualTo('='), IrohToken.Assignment)

            .Match(Character.EqualTo('+'), IrohToken.Plus)
            .Match(Character.EqualTo('-'), IrohToken.Minus)
            .Match(Character.EqualTo('/'), IrohToken.Division)
            .Match(Character.EqualTo('%'), IrohToken.Modulus)
            .Match(Character.EqualTo('*'), IrohToken.Multiply)

            .Match(Span.EqualTo("=="), IrohToken.Equals)
            .Match(Span.EqualTo("<>"), IrohToken.NotEqual)
            .Match(Span.EqualTo("<"), IrohToken.LessThan)
            .Match(Span.EqualTo(">"), IrohToken.GreaterThan)
            .Match(Span.EqualTo("<="), IrohToken.LessThanOrEqualTo)
            .Match(Span.EqualTo(">="), IrohToken.GreaterThanOrEqualTo)
            .Match(Span.EqualTo("and"), IrohToken.And, true)
            .Match(Span.EqualTo("or"), IrohToken.Or, true)

            .Match(Character.EqualTo('|'), IrohToken.BitwiseOr)
            .Match(Character.EqualTo('&'), IrohToken.BitwiseAnd)
            .Match(Character.EqualTo('^'), IrohToken.BitwiseXor)
            .Match(Span.EqualTo(">>"), IrohToken.BitwiseRightShift)
            .Match(Span.EqualTo("<<"), IrohToken.BitwiseLeftShift)

            .Match(Identifier.CStyle, IrohToken.Identifier, true) // v0.0.1

            .Build();
    }
}
