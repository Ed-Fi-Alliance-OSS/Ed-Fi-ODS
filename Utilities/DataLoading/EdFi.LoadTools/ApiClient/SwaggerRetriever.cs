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
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using Newtonsoft.Json;

namespace EdFi.LoadTools.ApiClient
{
    public class SwaggerRetriever : ISwaggerRetriever
    {
        private readonly IApiMetadataConfiguration _configuration;

        public SwaggerRetriever(IApiMetadataConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IDictionary<string, OpenApiDocument>> LoadMetadata()
        {
            var log = LogManager.GetLogger(GetType().Name);
            var result = new ConcurrentDictionary<string, OpenApiDocument>();

            using (ThreadContext.Stacks["NDC"].Push(_configuration.Url))
            {
                log.Info($"Loading API metadata from '{_configuration.Url}'");
                var metadataBlock = new BufferBlock<Metadata>();

                var resourcesBlock = new TransformBlock<Metadata, OpenApiDocument>(
                    async metadata =>
                    {
                        var openApiDocument = await LoadOpenApiDocument(metadata.EndpointUri);

                        result[metadata.Name] = openApiDocument;
                        return openApiDocument;
                    });

                var operationsBlack = new TransformManyBlock<OpenApiDocument, OperationRef>(
                    doc =>
                    {
                        return doc.Paths
                                  .SelectMany(p => p.Value.Operations)
                                  .Where(o =>
                                    o.Key == OperationType.Get ||
                                    o.Key == OperationType.Delete ||
                                    o.Key == OperationType.Post ||
                                    o.Key == OperationType.Put
                                    )
                                  .Select(
                                       o => new OperationRef
                                       {
                                           Operation = o.Value,
                                           References = doc.Components.Parameters
                                       });
                    });

                var referencesBlock = new ActionBlock<OperationRef>(
                    or =>
                    {
                        for (var i = 0; i < or.Operation.Parameters?.Count; i++)
                        {
                            var parameter = or.Operation.Parameters[i];

                            if (!string.IsNullOrEmpty(parameter.Reference?.ReferenceV3))
                            {
                                or.Operation.Parameters[i] =
                                    or.References.First(r => r.Key == parameter.Reference.ReferenceV3.Split('/').Last()).Value;
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
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using var client = new HttpClient(handler)
            {
                Timeout = new TimeSpan(0, 0, 5, 0)
            };

            var response = await client.GetAsync(
                    string.IsNullOrEmpty(localUrl)
                        ? _configuration.Url
                        : localUrl)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        }

        private static async Task<OpenApiDocument> LoadOpenApiDocument(string endpointUri)
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            using var client = new HttpClient(handler)
            {
                Timeout = new TimeSpan(0, 0, 5, 0)
            };

            var stream = await client.GetStreamAsync(endpointUri);
            var openApiDocument = new OpenApiStreamReader().Read(stream, out var diagnostic);

            return openApiDocument;
        }

        private class OperationRef
        {
            public OpenApiOperation Operation { get; set; }

            public IDictionary<string, OpenApiParameter> References { get; set; }
        }
    }
}
