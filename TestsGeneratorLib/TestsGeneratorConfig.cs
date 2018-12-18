namespace TestsGeneratorLib
{
    public class TestsGeneratorConfig
    {
        public int MaxReadTasksCount { get; }
        public int MaxProcessingTasksCount { get; }
        public int MaxWriteTasksCount { get; }

        public TestsGeneratorConfig(int maxReadTasksCount,int maxProcessingTasksCount,int maxWriteTasksCount)
        {
            MaxReadTasksCount = maxReadTasksCount;
            MaxProcessingTasksCount = maxProcessingTasksCount;
            MaxWriteTasksCount = maxWriteTasksCount;
        }
    }
}
