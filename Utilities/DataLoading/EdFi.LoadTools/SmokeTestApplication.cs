// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EdFi.LoadTools.SmokeTest;

namespace EdFi.LoadTools
{
    public class SmokeTestApplication : ISmokeTestApplication
    {
        private readonly IEnumerable<ITestGenerator> _testGenerators;

        public SmokeTestApplication(IEnumerable<ITestGenerator> testGenerators)
        {
            _testGenerators = testGenerators;
        }

        public async Task<int> Run()
        {
            var pipeline = TestExecutionPipeline();

            foreach (var testGenerator in _testGenerators)
            {
                await pipeline.StartBlock.SendAsync(testGenerator).ConfigureAwait(false);
            }

            pipeline.StartBlock.Complete();
            await pipeline.Completion.ConfigureAwait(false);
            return 0;
        }

        private static DataFlowPipeline<ITestGenerator> TestExecutionPipeline()
        {
            var copyBuffer = new BufferBlock<ITestGenerator>();

            var expandBlock = new TransformManyBlock<ITestGenerator, ITest>(
                generator => generator.GenerateTests(),
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = 1
                });

            var processBlock = new ActionBlock<ITest>(
                test => test.PerformTest(),
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = 1
                });

            copyBuffer.LinkTo(
                expandBlock, new DataflowLinkOptions
                             {
                                 PropagateCompletion = true
                             });

            expandBlock.LinkTo(
                processBlock, new DataflowLinkOptions
                              {
                                  PropagateCompletion = true
                              });

            return new DataFlowPipeline<ITestGenerator>(copyBuffer, processBlock.Completion);
        }
    }
}
