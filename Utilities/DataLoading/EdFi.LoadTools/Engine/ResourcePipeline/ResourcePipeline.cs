// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks.Dataflow;
using log4net;

namespace EdFi.LoadTools.Engine.ResourcePipeline
{
    public class ResourcePipeline
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(ResourcePipeline));
        private readonly IThrottleConfiguration _configuration;
        private readonly IResourcePipelineStep[] _steps;

        public ResourcePipeline(IResourcePipelineStep[] steps, IThrottleConfiguration configuration)
        {
            _steps = steps;
            _configuration = configuration;
        }

        public IPropagatorBlock<ApiLoaderWorkItem, ApiLoaderWorkItem> CreatePipelineBlock()
        {
            var work = new TransformBlock<ApiLoaderWorkItem, ApiLoaderWorkItem>(
                item =>
                {
                    using (LogContext.SetResourceName(item.ElementName))
                    {
                        using (LogContext.SetResourceHash(Encoding.Default.GetString(item.Hash)))
                        {
                            return _steps.Any(step => !step.Process(item))
                                ? null
                                : item;
                        }
                    }
                }, new ExecutionDataflowBlockOptions
                   {
                       BoundedCapacity = _configuration.TaskCapacity, MaxDegreeOfParallelism = Environment.ProcessorCount
                   });

            return work;
        }
    }
}
