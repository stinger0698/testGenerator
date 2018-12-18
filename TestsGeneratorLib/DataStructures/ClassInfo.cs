using System.Collections.Generic;

namespace TestsGeneratorLib.DataStructures
{
    public class ClassInfo
    {
        private string _name;
        private string _namespaceName;

        public List<MethodInfo> Methods { get; }

        public string Name
        {
            get { return _name; }
        }

        public string NamespaceName
        {
            get { return _name; }
        }

        public ClassInfo(string className,string namespaceName, List<MethodInfo> methods)
        {
            _name = className;
            _namespaceName = namespaceName;
            this.Methods = methods;
        }
    }
}
