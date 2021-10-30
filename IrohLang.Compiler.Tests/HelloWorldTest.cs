using IrohLang.AST;
using IrohLang.Parser;
using IrohLang.Parser.AST;
using IrohLang.Parser.Grammar;
using NUnit.Framework;
using Superpower.Parsers;
using System.Linq;

namespace IrohLang.Parser.Tests
{
    public class HelloWorldTests
    {
        private const string HELLO_WORLD_SIMPLE = @"
fn main():
   println('Hello World!');
end
";
        private static string HELLO_WORLD_COMPLEX = @"
mod main;

use os;

fn main(string[] args):
    ! Comments start with an exclamation point
    
    val message = 
        if (args.len > 0)
        then 'Hello @(args[0])!'
        else 'Hello World!';

    message |> stdout::write;
end
";


        [Test]
        public void Test_Tokenize_HELLO_WORLD_SIMPLE()
        {
            var tokens = IrohTokenizer.Tokenizer.TryTokenize(HELLO_WORLD_SIMPLE);
            Assert.That(tokens.HasValue);
            Assert.That(!tokens.Value.IsAtEnd);
        }

        [Test]
        public void Test_Tokenize_HELLO_WORLD_COMPLEX()
        {
            var tokens = IrohTokenizer.Tokenizer.TryTokenize(HELLO_WORLD_COMPLEX);
            Assert.That(tokens.HasValue);
            Assert.That(!tokens.Value.IsAtEnd);
        }

        [Test]
        public void Test_Parse_HELLO_WORLD_SIMPLE()
        {
            var tokens = IrohTokenizer.Tokenizer.Tokenize(HELLO_WORLD_SIMPLE);
            var AST = IrohParser.TopLevelAST(tokens);

            Assert.That(AST.HasValue, () => AST.ToString());
            Assert.That(AST.Value.TopLevelElements.Count() == 1, () => "There exists more or less than one top level element(s)");
            var function = (IrohFunction)AST.Value.TopLevelElements.First();
            Assert.That(function.Body!.Count() == 1, () => "Function body should have one item");
            var firstItem = (IrohExpression)function.Body!.First();
            var println = (IrohFunctionInvocation)firstItem.SubExpressions.First();
            var helloWorld = (IrohExpression)println.Arguments!.First();
            Assert.That(((IrohStringPrimitive)helloWorld.SubExpressions.First()).Value == "Hello World!");
        }
    }
}