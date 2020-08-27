// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace EdFi.LoadTools
{
    public class DataFlowPipeline<T>
    {
        public DataFlowPipeline(ITargetBlock<T> startBlock, Task completionTask)
        {
            StartBlock = startBlock;
            Completion = completionTask;
        }

        public ITargetBlock<T> StartBlock { get; }

        public Task Completion { get; }
    }
}
