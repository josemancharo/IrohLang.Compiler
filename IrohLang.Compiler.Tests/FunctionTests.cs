using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IrohLang.Parser;
using IrohLang.Parser.Grammar;
using IrohLang.Parser.AST;
using IrohLang.AST;

namespace IrohLang.Parser.Tests
{
    public class FunctionTests
    {
        [Test]
        public void Test_TrivialFunctionParse()
        {
            const string TRIVIAL_FUNCTION = @"
fn function1(str arg0):
end
";
            var tokens = IrohTokenizer.Tokenizer.Tokenize(TRIVIAL_FUNCTION);
            var AST = IrohParser.Function(tokens);
            Assert.That(AST.HasValue, () => AST.ToString());
            var function = AST.Value;
            Assert.That(function.Name == "function1", () => "function name is not correct");
            Assert.That(function.Arguments != null && function.Arguments!.ContainsKey("arg0"), () => "function does not contain expected arguments");
            Assert.That(function.Arguments!["arg0"] is { Name: "str" }, () => "arg0 is not of type str");
        }

        [Test]
        public void Test_TrivialFunctionWithBodyParse()
        {
            const string TRIVIAL_FUNCTION = @"
fn function1(str arg0):
    println(arg0); 
end
";
            var tokens = IrohTokenizer.Tokenizer.Tokenize(TRIVIAL_FUNCTION);
            var AST = IrohParser.Function(tokens);
            Assert.That(AST.HasValue, () => AST.ToString());
        }


        [Test]
        public void Test_FunctionInvocation()
        {
            const string FUNCTION_INVOCATION = @"function1('Bob')";

            var tokens = IrohTokenizer.Tokenizer.Tokenize(FUNCTION_INVOCATION);
            var AST = IrohParser.FunctionInvocation(tokens);
            Assert.That(AST.HasValue, () => "AST has no value");

            var function = AST.Value;
            Assert.That(function.GetType() == typeof(IrohFunctionInvocation), () => "function.GetType() did not return IrohFunctionInvocation");

            var functionUnboxed = (IrohFunctionInvocation)function;
            Assert.That(functionUnboxed.Name == "function1", () => "Name is not equal to 'function1'");
            Assert.That(functionUnboxed.Arguments != null, () => "Arguments are null");

            var stringPrimitiveArguments = functionUnboxed.Arguments!
                .Where(x => x.GetType() == typeof(IrohExpression));
            var argument1 = stringPrimitiveArguments.Select(x => (IrohExpression)x).First();
            var expectedParameters = argument1.SubExpressions
                .Where(x => x.GetType() == typeof(IrohStringPrimitive))
                .Where(x => (IrohStringPrimitive)x is { Value: "Bob" });

            Assert.That(expectedParameters.Any(), 
                () => "Parameter Value is not 'Bob'");
        }
    }
}
