// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.IO;
using EdFi.Ods.Common.Models.Domain;
using MessagePack;

namespace EdFi.Ods.Common.Infrastructure.Listeners;

public class MessagePackHelper
{
    private static readonly MessagePackSerializerOptions _lz4Options =
        MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray);

    public static byte[] SerializeAndCompressAggregateData(AggregateRootWithCompositeKey entity)
    {
        var aggregateRootType = entity.GetType();

        // Serialize the object directly to a MemoryStream
        using var memoryStream = new MemoryStream();

        // Write the LastModifiedDate value at the head of the stream so we can detect if the JSON has changed and is invalid without deserializing it
        byte[] lastModifiedDateBytes = BitConverter.GetBytes(entity.LastModifiedDate.ToBinary());
        memoryStream.Write(lastModifiedDateBytes);

        MessagePackSerializer.Serialize(aggregateRootType, memoryStream, entity, _lz4Options);

        byte[] byteArray = memoryStream.ToArray();

        return byteArray;
    }

    public static TResource DecompressAndDeserializeAggregate<TResource>(byte[] compressedData)
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

        return MessagePackSerializer.Deserialize<TResource>(memoryStream, _lz4Options);
    }
}
