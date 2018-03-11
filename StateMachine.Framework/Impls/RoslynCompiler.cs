using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using StateMachine.Framework.Interfaces;

namespace StateMachine.Framework.Impls
{
    public class RoslynCompiler : IRoslynCompiler
    {
        public bool Check(string condition)
        {
            string code = @"
            namespace RoslynCompiler
            {
                public class Compiler
                {
                    public bool Check(string condition)
                    {
                        return condition == ""deneme"";
                    }
                }
            }";

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(code);

            string assemblyName = Assembly.GetExecutingAssembly().FullName;
            MetadataReference[] references = new MetadataReference[]
            {
                MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location)
            };

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] {syntaxTree},
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            using (var ms = new MemoryStream())
            {
                EmitResult emitResult = compilation.Emit(ms);

                if (!emitResult.Success)
                {
//                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
//                        diagnostic.IsWarningAsError ||
//                        diagnostic.Severity == DiagnosticSeverity.Error);
//
//                    foreach (Diagnostic diagnostic in failures)
//                    {
//                        Console.Error.WriteLine("\t{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
//                    }

                    return false;
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);

                    Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
                    var type = assembly.GetType("RoslynCompileSample.Writer");
                    var instance = assembly.CreateInstance("RoslynCompileSample.Writer");

                    var method = type.GetMember("Check").First() as MethodInfo;

                    var result = method != null && (bool) method.Invoke(instance, new[] {condition});

                    return result;
                }
            }
        }
    }
}