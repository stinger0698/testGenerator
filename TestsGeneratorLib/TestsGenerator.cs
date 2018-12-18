using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using TestsGeneratorLib.DataStructures;

namespace TestsGeneratorLib
{
    public class TestsGenerator
    {
        private TestsGeneratorConfig _config;

        public TestsGenerator(TestsGeneratorConfig config)
        {
            _config = config;
        }

        public async Task Generate(List<string> pathes, string destination)
        {
            DataflowLinkOptions linkOptions = new DataflowLinkOptions { PropagateCompletion = true };//цель получает уведомление о завершении/сбое
            ExecutionDataflowBlockOptions readBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config.MaxReadTasksCount
            };
            ExecutionDataflowBlockOptions processBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config.MaxProcessingTasksCount
            };
            ExecutionDataflowBlockOptions writeBlockOptions = new ExecutionDataflowBlockOptions
            {
                MaxDegreeOfParallelism = _config.MaxWriteTasksCount
            };

            TransformBlock<string, string> readBlock = new TransformBlock<string, string>(fileName => AsyncReader.Read(fileName), readBlockOptions);
            TransformBlock<string, List<GeneratedTest>> processBlock = new TransformBlock<string, List<GeneratedTest>>(sourceCode => GenerateTestClasses(sourceCode), processBlockOptions);
            ActionBlock<List<GeneratedTest>> writeBlock = new ActionBlock<List<GeneratedTest>>((generatedClasses => AsyncWriter.Write(destination, generatedClasses)), writeBlockOptions);

            readBlock.LinkTo(processBlock, linkOptions);
            processBlock.LinkTo(writeBlock, linkOptions);

            foreach (string path in pathes)
            {
                await readBlock.SendAsync(path);
            }
            readBlock.Complete();

            await writeBlock.Completion;
        }

        private List<GeneratedTest> GenerateTestClasses(string sourceCode)
        {
            ParsingResultBuilder builder = new ParsingResultBuilder();
            ParsingResultStructure result = builder.GetResult(sourceCode);
            //here we can genearte test class with result
            TestTemplateGenerator generator = new TestTemplateGenerator();
            List<GeneratedTest> generatedTests = generator.GetTestTemplates(result);

            return generatedTests;
        }

    }
}
