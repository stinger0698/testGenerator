using System.Collections.Generic;

namespace TestsGeneratorLib.DataStructures
{    
    public class ParsingResultStructure
    {
        public List<ClassInfo> Classes { get; }

        public ParsingResultStructure(List<ClassInfo> classes)
        {
            this.Classes = classes;
        }
    }
}
