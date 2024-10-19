// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.IO.Compression;
using EdFi.Ods.Common.Constants;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public class JsonHelper
{
    public static byte[] SerializeAndCompressResourceData(object entity, JsonSerializerSettings jsonSerializerSettings)
    {
        // Produce the JSON
        if (ResourceEntityTypeMap.TryGetResourceType(entity.GetType(), out var resourceType))
        {
            object resource = Activator.CreateInstance(resourceType);

            var originalAction = GeneratedArtifactStaticDependencies.AuthorizationContextProvider.GetAction();

            try
            {
                // Set the action in context so we map the reference data
                GeneratedArtifactStaticDependencies.AuthorizationContextProvider.SetAction(RequestActions.ReadActionUri);
                (entity as IMappable).Map(resource);
            }
            finally
            {
                GeneratedArtifactStaticDependencies.AuthorizationContextProvider.SetAction(originalAction);
            }

            var serializer = JsonSerializer.Create(jsonSerializerSettings);

            // Serialize the object directly to a MemoryStream
            byte[] byteArray;

            using (var memoryStream = new MemoryStream())
            {
                // Write the LastModifiedDate value at the head of the stream so we can detect if the JSON has changed and is invalid without deserializing it
                byte[] lastModifiedDateBytes = BitConverter.GetBytes((entity as IDateVersionedEntity)!.LastModifiedDate.ToBinary());
                memoryStream.Write(lastModifiedDateBytes);

                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    // using (var streamWriter = new StreamWriter(memoryStream))
                    using (var streamWriter = new StreamWriter(gzipStream))
                    {
                        using (var jsonWriter = new JsonTextWriter(streamWriter))
                        {
                            serializer.Serialize(jsonWriter, resource);
                            streamWriter.Flush(); // Ensure all data is written to the stream
                            byteArray = memoryStream.ToArray();
                        }
                    }
                }
            }

            return byteArray;
        }

        return null;
    }
}
