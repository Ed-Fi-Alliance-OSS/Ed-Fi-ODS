// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EdFi.LoadTools.Engine;
using log4net;
using Newtonsoft.Json;
using Swashbuckle.Swagger;

namespace EdFi.LoadTools.ApiClient
{
    public class SwaggerRetriever
    {
        private readonly IApiMetadataConfiguration _configuration;

        public SwaggerRetriever(IApiMetadataConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDictionary<string, SwaggerDocument>> LoadMetadata()
        {
            var log = LogManager.GetLogger(GetType().Name);
            var result = new ConcurrentDictionary<string, SwaggerDocument>();

            using (ThreadContext.Stacks["NDC"].Push(_configuration.Url))
            {
                log.Info("Loading API Meta-data");
                var metadataBlock = new BufferBlock<Metadata>();

                var resourcesBlock = new TransformBlock<Metadata, SwaggerDocument>(
                    async metadata =>
                    {
                        var j = await LoadJsonString(metadata.EndpointUri).ConfigureAwait(false);

                        var doc = JsonConvert.DeserializeObject<SwaggerDocument>(
                            j,
                            new JsonSerializerSettings
                            {
                                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                                MetadataPropertyHandling = MetadataPropertyHandling.Ignore
                            });

                        result[metadata.Name] = doc;
                        return doc;
                    });

                var operationsBlack = new TransformManyBlock<SwaggerDocument, OperationRef>(
                    doc =>
                    {
                        return doc.paths
                                  .SelectMany(
                                       p => new[]
                                            {
                                                p.Value.get, p.Value.delete, p.Value.post, p.Value.put
                                            })
                                  .Where(o => o != null)
                                  .Select(
                                       o => new OperationRef
                                            {
                                                Operation = o, References = doc.parameters
                                            });
                    });

                var referencesBlock = new ActionBlock<OperationRef>(
                    or =>
                    {
                        for (var i = 0; i < or.Operation.parameters.Count; i++)
                        {
                            var parameter = or.Operation.parameters[i];

                            if (!string.IsNullOrEmpty(parameter.@ref))
                            {
                                or.Operation.parameters[i] =
                                    or.References.First(r => r.Key == parameter.@ref.Split('/').Last()).Value;
                            }
                        }
                    });

                //link blocks
                metadataBlock.LinkTo(
                    resourcesBlock, new DataflowLinkOptions
                                    {
                                        PropagateCompletion = true
                                    });

                resourcesBlock.LinkTo(
                    operationsBlack, new DataflowLinkOptions
                                     {
                                         PropagateCompletion = true
                                     });

                operationsBlack.LinkTo(
                    referencesBlock, new DataflowLinkOptions
                                     {
                                         PropagateCompletion = true
                                     });

                //prime the pipeline
                var json = await LoadJsonString(string.Empty).ConfigureAwait(false);
                var metadatas = JsonConvert.DeserializeObject<Metadata[]>(json);

                foreach (var metadata in metadatas.Where(m => string.IsNullOrEmpty(m.Prefix)))
                {
                    await metadataBlock.SendAsync(metadata);
                }

                metadataBlock.Complete();

                await resourcesBlock.Completion;
                return result;
            }
        }

        private async Task<string> LoadJsonString(string localUrl)
        {
            using (var client = new HttpClient
                                {
                                    Timeout = new TimeSpan(0, 0, 5, 0)
                                })
            {
                var response = await client.GetAsync(
                                                string.IsNullOrEmpty(localUrl)
                                                    ? _configuration.Url
                                                    : localUrl)
                                           .ConfigureAwait(false);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        private class OperationRef
        {
            public Operation Operation { get; set; }

            public IDictionary<string, Parameter> References { get; set; }
        }
    }
}
