using System;
using System.Collections.Generic;
using System.IO;
using TestsGeneratorLib;

namespace View
{
    class Program
    {
        static void Main(string[] args)
        {            
            int readingLimit = 3;
            int writingLimit = 3;
            int processingLimit = 8;
            string workPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\TestsFilesForTesting\\";
            List<string> pathes = new List<string>();

            pathes.Add(workPath+"BaseGenerator.cs");
            pathes.Add(workPath+"TestsGenerator.cs");

            TestsGeneratorConfig config = new TestsGeneratorConfig(readingLimit, processingLimit, writingLimit);
            TestsGenerator generator = new TestsGenerator(config);

            generator.Generate(pathes,workPath+ "GeneratedTests").Wait();
            Console.WriteLine("Complete");
        }
    }
}
