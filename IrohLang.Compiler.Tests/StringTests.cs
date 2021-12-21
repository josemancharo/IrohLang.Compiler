using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IrohLang.Parser;
using IrohLang.Parser.Grammar;
using IrohLang.AST;
using IrohLang.AST.Primitives;

namespace IrohLang.Parser.Tests
{
    public class StringTests
    {
        [Test]
        public void Test_StringParsing()
        {
            const string TEST_STRING = "'Hello World!'";
            var tokens = IrohTokenizer.Tokenizer.Tokenize(TEST_STRING);
            var astNode = IrohParser.StringPrimitive(tokens);
            Assert.That(astNode.HasValue);
            Assert.That(astNode.Value != null);
            Assert.That(((IrohStringPrimitive)astNode.Value!).Value == "Hello World!");
        }
    }
}
