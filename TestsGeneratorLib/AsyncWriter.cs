using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using TestsGeneratorLib.DataStructures;

namespace TestsGeneratorLib
{
    public static class AsyncWriter
    {
        public static async Task Write(string destination,List<GeneratedTest> generatedTests)
        {
            string path;

            if (!Directory.Exists(destination))
            {
                Directory.CreateDirectory(destination);
            }

            foreach (GeneratedTest generatedTest in generatedTests)
            {
                path = destination+"\\" + generatedTest.Name;
                using (StreamWriter writer = new StreamWriter(path))
                {
                    await writer.WriteAsync(generatedTest.Content);
                }
            }
        }
    }
}
