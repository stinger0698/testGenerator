namespace TestsGeneratorLib.DataStructures
{
    public class MethodInfo
    {
        private string _name;

        public string Name
        {
            get { return _name; }
        }

        public MethodInfo(string methodName)
        {
            _name = methodName;
        }
    }
}
