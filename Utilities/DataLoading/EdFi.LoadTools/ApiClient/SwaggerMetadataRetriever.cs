// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using EdFi.LoadTools.Engine;
using log4net;
using Newtonsoft.Json;
using Swashbuckle.Swagger;

namespace EdFi.LoadTools.ApiClient
{
    public class SwaggerMetadataRetriever
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(SwaggerMetadataRetriever).Name);

        private readonly IApiMetadataConfiguration _configuration;

        private readonly List<string> _schemaNames;
        private readonly SwaggerRetriever _swaggerRetriever;

        public SwaggerMetadataRetriever(IApiMetadataConfiguration configuration, SwaggerRetriever swaggerRetriever,
                                        List<string> schemaNames)
        {
            _configuration = configuration;
            _swaggerRetriever = swaggerRetriever;
            _schemaNames = schemaNames;
        }

        private string Filename => Path.Combine(_configuration.Folder, "metadata.json");

        private bool MetadataExists => File.Exists(Filename);

        public async Task<IEnumerable<JsonModelMetadata>> GetMetadata()
        {
            if (!MetadataExists || _configuration.Force)
            {
                await LoadMetadata().ConfigureAwait(false);
            }

            return await ReadMetadata();
        }

        private async Task<IEnumerable<JsonModelMetadata>> ReadMetadata()
        {
            var result = new List<JsonModelMetadata>();

            if (!MetadataExists)
            {
                return result;
            }

            using (var reader = new StreamReader(Filename))
            {
                while (!reader.EndOfStream)
                {
                    var obj = await reader.ReadLineAsync()
                                          .ConfigureAwait(false);

                    var info = JsonConvert.DeserializeObject<JsonModelMetadata>(obj);

                    if (info.Schema != null && !_schemaNames.Contains(info.Schema))
                    {
                        _schemaNames.Add(info.Schema);
                    }

                    result.Add(info);
                }

                reader.Close();
            }

            return result;
        }

        private async Task LoadMetadata()
        {
            using (LogicalThreadContext.Stacks["NDC"].Push(_configuration.Url))
            {
                File.Delete(Filename);

                Log.Info("Loading API Metadata");

                using (var writer = new StreamWriter(Filename))
                {
                    var metadataBlock = new BufferBlock<KeyValuePair<string, SwaggerDocument>>();

                    var documentsBlock =
                        new TransformManyBlock<KeyValuePair<string, SwaggerDocument>, JsonModelMetadata>(
                            x =>
                            {
                                var jsonModelMetadatas = new List<JsonModelMetadata>();

                                foreach (var definition in x.Value.definitions)
                                {
                                    var schema = definition.Value;

                                    if (schema == null)
                                    {
                                        continue;
                                    }

                                    var modelPath = GetPathForModel(x.Value, definition.Key);

                                    var properties = GetProperties(
                                        schema, x.Key, definition.Key,
                                        PathToSchema(modelPath));

                                    jsonModelMetadatas.AddRange(properties);
                                }

                                return jsonModelMetadatas;
                            });

                    var outputBlock = new ActionBlock<JsonModelMetadata>(
                        async x =>
                            await writer.WriteLineAsync(JsonConvert.SerializeObject(x, Formatting.None))
                                        .ConfigureAwait(false));

                    // link blocks
                    metadataBlock.LinkTo(
                        documentsBlock, new DataflowLinkOptions
                                        {
                                            PropagateCompletion = true
                                        });

                    documentsBlock.LinkTo(
                        outputBlock, new DataflowLinkOptions
                                     {
                                         PropagateCompletion = true
                                     });

                    // prime the pipeline
                    var metadata = await _swaggerRetriever.LoadMetadata();

                    foreach (var m in metadata)
                    {
                        await metadataBlock.SendAsync(m);
                    }

                    metadataBlock.Complete();

                    await outputBlock.Completion;
                    writer.Close();
                }
            }
        }

        private IEnumerable<JsonModelMetadata> GetProperties(Schema schema, string category, string model,
                                                             string modelSchema)
        {
            return schema.properties
                         .Select(
                              p => new JsonModelMetadata
                                   {
                                       Category = category, Resource = p.Value?.@ref, Model = model, Property = p.Key, Type = GetTypeName(p),
                                       Format = p.Value?.format, IsArray = p.Value?.type == "array",
                                       IsRequired = schema.required?.Any(x => x.Equals(p.Key)) ?? false, Description = p.Value?.description,
                                       Schema = modelSchema
                                   });
        }

        private string GetPathForModel(SwaggerDocument swaggerDocument, string modelName)
        {
            return swaggerDocument.paths.FirstOrDefault(
                                       p => p.Value?.post?.parameters.FirstOrDefault()
                                            ?.schema.@ref == $"#/definitions/{modelName}")
                                  .Key;
        }

        private string PathToSchema(string path)
        {
            return path?.Split('/')
                        .Skip(1)
                        .FirstOrDefault();
        }

        private static string GetTypeName(KeyValuePair<string, Schema> parameterInfo)
        {
            var referenceType = string.Empty;
            var parameter = parameterInfo.Value;

            if (parameter?.type == "array")
            {
                referenceType = parameter.items.@ref;
            }

            if (string.IsNullOrEmpty(parameter?.type) && !string.IsNullOrEmpty(parameter?.@ref))
            {
                referenceType = parameter.@ref;
            }

            var parameterType = !string.IsNullOrEmpty(referenceType)
                ? referenceType.Split('/').Last()
                : string.Empty;

            return !string.IsNullOrEmpty(parameterType)
                ? parameterType
                : parameter?.type;
        }
    }
}
