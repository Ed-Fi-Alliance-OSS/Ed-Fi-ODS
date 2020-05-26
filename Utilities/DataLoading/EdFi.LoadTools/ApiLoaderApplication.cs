// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EdFi.LoadTools.ApiClient;
using EdFi.LoadTools.Engine;
using EdFi.LoadTools.Engine.InterchangePipeline;
using EdFi.LoadTools.Engine.ResourcePipeline;
using log4net;

namespace EdFi.LoadTools
{
    public class ApiLoaderApplication
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(ApiLoaderApplication));

        private readonly IApiConfiguration _apiConfiguration;
        private readonly InterchangePipeline _interchangePipeline;
        private readonly ResourcePipeline _resourcePipeline;
        private readonly SubmitResource _submitResourcesProcessor;
        private readonly IXmlReferenceCacheFactory _xmlReferenceCacheFactory;
        private readonly IResourceHashCache _xmlResourceHashCache;
        private readonly DependenciesRetriever _dependenciesRetriever;
        private readonly ResourceToInterchangeMapProvider _resourceToInterchangeMapProvider;

        public ApiLoaderApplication(
            InterchangePipeline interchangePipeline,
            ResourcePipeline resourcePipeline,
            SubmitResource submitResourcesProcessor,
            IResourceHashCache xmlResourceHashCache,
            IXmlReferenceCacheFactory xmlReferenceCacheFactory,
            IApiConfiguration apiConfiguration,
            DependenciesRetriever dependenciesRetriever,
            ResourceToInterchangeMapProvider resourceToInterchangeMapProvider)
        {
            _interchangePipeline = interchangePipeline;
            _resourcePipeline = resourcePipeline;
            _submitResourcesProcessor = submitResourcesProcessor;
            _xmlResourceHashCache = xmlResourceHashCache;
            _xmlReferenceCacheFactory = xmlReferenceCacheFactory;
            _apiConfiguration = apiConfiguration;
            _dependenciesRetriever = dependenciesRetriever;
            _resourceToInterchangeMapProvider = resourceToInterchangeMapProvider;
        }

        public async Task<int> Run()
        {
            _xmlResourceHashCache.Load();

            var foundFilesToUpload = false;

            var dependencyLevelGroups = await _dependenciesRetriever.GetDependencyLevelGroupsAsync().ConfigureAwait(false);

            foreach (var dependencyLevelGroup in dependencyLevelGroups)
            {
                var retryQueue = new ConcurrentQueue<ApiLoaderWorkItem>();
                var resourcePipeline = CreateResourcePipeline(retryQueue);

                var resources = dependencyLevelGroup.Select(s => s.Resource).ToList();
                var dependency = dependencyLevelGroup.First();

                foreach (var resource in _interchangePipeline.RetrieveResourcesFromInterchange(resources, dependency.Order))
                {
                    await resourcePipeline.StartBlock.SendAsync(resource).ConfigureAwait(false);
                    foundFilesToUpload = true;
                }

                resourcePipeline.StartBlock.Complete();
                await resourcePipeline.Completion.ConfigureAwait(false);
                
                if (retryQueue.Count > 0)
                {
                    var retryPipeline = CreateRetryPipeline(retryQueue.Count);

                    foreach (var retryResource in retryQueue)
                    {
                        await retryPipeline.StartBlock.SendAsync(retryResource);
                    }

                    await retryPipeline.Completion;
                }

                // Cleanup reference caches
                _xmlReferenceCacheFactory.Cleanup();
            }

            if (!foundFilesToUpload)
            {
               _log.Warn("No interchange files found for import");
            }

            return 0;
        }

        private DataFlowPipeline<ApiLoaderWorkItem> CreateResourcePipeline(ConcurrentQueue<ApiLoaderWorkItem> retryQueue)
        {
            // Create blocks
            var resourcePipelineBlock = _resourcePipeline.CreatePipelineBlock();

            var postingBlock = new TransformBlock<ApiLoaderWorkItem, ApiLoaderWorkItem>(
                x => _submitResourcesProcessor.ProcessAsync(x)
              , new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = _apiConfiguration.MaxSimultaneousRequests, MaxDegreeOfParallelism = Environment.ProcessorCount
                });

            var successBlock = new ActionBlock<ApiLoaderWorkItem>(
                x => _xmlResourceHashCache.Add(x.Hash)
            );

            var noPostBlock = new ActionBlock<ApiLoaderWorkItem>(
                x =>
                {
                    //string contextPrefix = LogContext.BuildContextPrefix(x);
                    _log.Debug("Found in cache - Not Submitted");
                });

            var retryQueueBlock = new ActionBlock<ApiLoaderWorkItem>(
                x =>
                {
                    if (_apiConfiguration.Retries > 0)
                    {
                        retryQueue.Enqueue(x);
                    }
                    else
                    {
                        var contextPrefix = LogContext.BuildContextPrefix(x);

                        _log.Error(
                            $"{contextPrefix} {x.Responses.Last().StatusCode} - {x.Responses.Last().Content}{Environment.NewLine}{x.XElement}{Environment.NewLine}{x.Json} - Level: {x.Level}");
                    }
                },
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = _apiConfiguration.TaskCapacity, MaxDegreeOfParallelism = Environment.ProcessorCount
                });

            // Link blocks

            resourcePipelineBlock.LinkTo(
                postingBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                },
                x => x != null);

            resourcePipelineBlock.LinkTo(
                noPostBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                },
                x => x == null);

            postingBlock.LinkTo(
                successBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                },
                x => x.Responses.Any(y => y.IsSuccess));

            postingBlock.LinkTo(
                retryQueueBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                });

            return new DataFlowPipeline<ApiLoaderWorkItem>(
                resourcePipelineBlock,
                Task.WhenAll(noPostBlock.Completion, retryQueueBlock.Completion, successBlock.Completion));
        }

        private DataFlowPipeline<ApiLoaderWorkItem> CreateRetryPipeline(int numResourcesToRetry)
        {
            var totalResources = numResourcesToRetry;
            var retryBufferBlock = new BufferBlock<ApiLoaderWorkItem>();

            var retryBlock = new TransformBlock<ApiLoaderWorkItem, ApiLoaderWorkItem>(
                x => _submitResourcesProcessor.ProcessAsync(x),
                new ExecutionDataflowBlockOptions
                {
                    BoundedCapacity = _apiConfiguration.TaskCapacity, MaxDegreeOfParallelism = _apiConfiguration.MaxSimultaneousRequests
                });

            var successBlock = new TransformBlock<ApiLoaderWorkItem, ApiLoaderWorkItem>(
                delegate(ApiLoaderWorkItem resource)
                {
                    _xmlResourceHashCache.Add(resource.Hash);
                    return resource;
                });

            var errorBlock = new TransformBlock<ApiLoaderWorkItem, ApiLoaderWorkItem>(
                delegate(ApiLoaderWorkItem resource)
                {
                    var contextPrefix = LogContext.BuildContextPrefix(resource);

                    _log.Error(
                        $"{contextPrefix} {resource.Responses.Last().StatusCode} - {resource.Responses.Last().Content}{Environment.NewLine}{resource.XElement}{Environment.NewLine}{resource.Json}");

                    return resource;
                });

            var completionCheckBlock = new ActionBlock<ApiLoaderWorkItem>(
                delegate
                {
                    totalResources--;

                    if (totalResources == 0)
                    {
                        retryBufferBlock.Complete();
                    }
                },
                new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = 1
                });

            retryBufferBlock.LinkTo(
                retryBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                }
            );

            retryBlock.LinkTo(
                retryBufferBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                },
                x => x.Responses.Count < _apiConfiguration.Retries && !x.Responses.Any(y => y.IsSuccess));

            retryBlock.LinkTo(
                successBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                },
                x => x.Responses.Any(y => y.IsSuccess));

            retryBlock.LinkTo(
                errorBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                });

            successBlock.LinkTo(
                completionCheckBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                });

            errorBlock.LinkTo(
                completionCheckBlock,
                new DataflowLinkOptions
                {
                    PropagateCompletion = true
                });

            return new DataFlowPipeline<ApiLoaderWorkItem>(retryBufferBlock, completionCheckBlock.Completion);
        }

        private class DataFlowPipeline<T>
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
}
