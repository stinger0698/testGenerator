using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TestsGeneratorLib.DataStructures
{
    public class ParsingResultBuilder
    {
        public ParsingResultStructure GetResult(string sourceCode)
        {
            SyntaxTree codeTree = CSharpSyntaxTree.ParseText(sourceCode);
            CompilationUnitSyntax root = codeTree.GetCompilationUnitRoot();

            return new ParsingResultStructure(GetClasses(root));
        }

        private List<ClassInfo> GetClasses(CompilationUnitSyntax root)
        {
            string className,namespaceName;
            List<ClassInfo> classes = new List<ClassInfo>();

            foreach (ClassDeclarationSyntax classDeclaration in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                namespaceName = ((NamespaceDeclarationSyntax)classDeclaration.Parent).Name.ToString();//namespace
                className = classDeclaration.Identifier.ValueText;//имя класса

                classes.Add(new ClassInfo(className,namespaceName,GetMethods(classDeclaration)));
            }
            return classes;
        }

        private List<MethodInfo> GetMethods(ClassDeclarationSyntax classDeclaration)
        {
            string methodName;
            List<MethodInfo> methods = new List<MethodInfo>();

            //только public методы
            foreach (MethodDeclarationSyntax methodDeclaration in classDeclaration.DescendantNodes().OfType<MethodDeclarationSyntax>()
                .Where((methodDeclaration) => methodDeclaration.Modifiers.Any((modifier) => modifier.IsKind(SyntaxKind.PublicKeyword))))
            {
                methodName = methodDeclaration.Identifier.ValueText;//имя метода
                methods.Add(new MethodInfo(methodName));
            }
            return methods;
        }

    }
}
