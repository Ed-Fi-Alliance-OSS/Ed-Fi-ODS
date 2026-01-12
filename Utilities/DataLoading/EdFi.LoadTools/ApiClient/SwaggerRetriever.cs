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
using Microsoft.OpenApi;
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
                                    o.Key == HttpMethod.Get ||
                                    o.Key == HttpMethod.Delete ||
                                    o.Key == HttpMethod.Post ||
                                    o.Key == HttpMethod.Put
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
                        if (or.Operation.Parameters == null) return;

                        for (var i = 0; i < or.Operation.Parameters.Count; i++)
                        {
                            var parameter = or.Operation.Parameters[i];

                            // Check if parameter is a reference type
                            if (parameter is OpenApiParameterReference paramRef)
                            {
                                var referenceId = paramRef.Reference?.Id;
                                if (!string.IsNullOrEmpty(referenceId) && or.References != null && or.References.ContainsKey(referenceId))
                                {
                                    or.Operation.Parameters[i] = or.References[referenceId];
                                }
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

            // In Microsoft.OpenApi v2.x, use OpenApiDocument.LoadAsync
            var (document, diagnostic) = await OpenApiDocument.LoadAsync(stream);

            return document;
        }

        private class OperationRef
        {
            public OpenApiOperation Operation { get; set; }

            public IDictionary<string, IOpenApiParameter> References { get; set; }
        }
    }
}
