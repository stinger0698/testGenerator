namespace TestsGeneratorLib.DataStructures
{
    public class GeneratedTest
    {
        private string _content;

        public string Name { get; }

        public string Content
        {
            get { return _content; }
        }

        public GeneratedTest(string name,string content)
        {
            Name = name;
            _content = content;
        }
    }
}
