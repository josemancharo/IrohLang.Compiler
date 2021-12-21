using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrohLang.Parser.Tests
{
    internal class FileTests
    {
        [Test]
        public void Test_ModuleDefinition()
        {
            const string FILE = @"mod MyModule;";
            var ast = IrohParser.File(IrohTokenizer.Tokenizer.Tokenize(FILE));
            Assert.That(ast.HasValue, () => ast.ToString());
            Assert.That(ast.Value.Module is { Name: "MyModule" });
            Assert.That(ast.Value.Namespace == IrohNamespace.Default);
        }
    }
}
