// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;

namespace EdFi.Ods.Common.Compression;

public static class CompressionHelper
{
    public static byte[] CompressString(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text));
        }

        byte[] stringBytes = Encoding.UTF8.GetBytes(text);

        using var memoryStream = new MemoryStream();

        using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
        {
            gzipStream.Write(stringBytes, 0, stringBytes.Length);
        }

        return memoryStream.ToArray();
    }

    public static string DecompressByteArray(byte[] compressedData)
    {
        if (compressedData == null || compressedData.Length == 0)
        {
            throw new ArgumentNullException(nameof(compressedData));
        }

        using var memoryStream = new MemoryStream(compressedData);

        return DecompressStream(memoryStream);
    }

    public static string DecompressStream(Stream sourceStream)
    {
        using var gzipStream = new GZipStream(sourceStream, CompressionMode.Decompress);

        using var resultStream = new MemoryStream();

        gzipStream.CopyTo(resultStream);
        byte[] decompressedBytes = resultStream.ToArray();

        return Encoding.UTF8.GetString(decompressedBytes);
    }

    public static TResource DecompressAndDeserialize<TResource>(byte[] compressedData, JsonSerializerSettings serializerSettings)
    {
        if (compressedData == null || compressedData.Length == 0)
        {
            throw new ArgumentNullException(nameof(compressedData));
        }

        using var memoryStream = new MemoryStream(compressedData);

        // Consume the long value off containing the LastModifiedDate off the head of the stream
        for (int i = 0; i < 8; i++)
        {
            memoryStream.ReadByte();
        }

        using var gzipStream = new GZipStream(memoryStream, CompressionMode.Decompress);

        using var resultStream = new MemoryStream();

        // Decompress the bytes into a stream for deserialization
        gzipStream.CopyTo(resultStream);
        gzipStream.Flush();

        // Reset position on memory stream to the beginning
        resultStream.Position = 0;

        // Deserialize the resource
        using var streamReader = new StreamReader(resultStream);
        var serializer = JsonSerializer.Create(serializerSettings);
        var deserializedObj = serializer.Deserialize<TResource>(new JsonTextReader(streamReader));

        return deserializedObj;
    }
}
