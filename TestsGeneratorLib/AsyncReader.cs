using System.IO;
using System.Threading.Tasks;

namespace TestsGeneratorLib
{
    public static class AsyncReader
    {
        public static async Task<string> Read(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
