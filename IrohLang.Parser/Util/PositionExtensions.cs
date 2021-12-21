using IrohLang.AST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser.Util
{
    internal static class PositionExtensions
    {
        public static ParserPosition AsParserPosition(this Position position, string? fileName = null)
        {
            return new ParserPosition(position.Line, position.Column, fileName);
        }
    }
}
