// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;

namespace EdFi.Ods.Common.Serialization
{
    public static class SerializationHelper
    {
        public static T DeserializeFromCompressedBase64<T>(string base64EncodedString)
        {
            if (base64EncodedString.Contains("\n"))
            {
                base64EncodedString = string.Join(string.Empty, base64EncodedString);
            }

            var buffer = Convert.FromBase64String(base64EncodedString);
            var compressedStream = new MemoryStream(buffer);

            T model = (T) DeserializeFromStream(compressedStream, true);

            return model;
        }

        public static string SerializeToCompressedBase64<T>(T model)
        {
            var ms = new MemoryStream();
            SerializeToStream(model, ms, true);
            byte[] bytes = ms.ToArray();

            string encoded = Convert.ToBase64String(bytes);

            return encoded;
        }

        public static IEnumerable<string> SerializeToCompressedBase64<T>(T model, int maxLineLength)
        {
            string encodedString = SerializeToCompressedBase64(model);

            var encodedLines = ChunksUpTo(encodedString, 200);

            return encodedLines;
        }

        public static void SerializeToStream(object o, Stream outputStream, bool compress = false)
        {
            MemoryStream serializationStream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, o);

            // Reset position of memory stream so it can act as an input stream
            serializationStream.Seek(0, SeekOrigin.Begin);

            if (compress)
            {
                CompressStream(serializationStream, outputStream);
            }
            else
            {
                serializationStream.CopyTo(outputStream);
            }
        }

        public static object DeserializeFromStream(Stream inputStream, bool decompress = false)
        {
            Stream deserInputStream;

            if (decompress)
            {
                deserInputStream = new MemoryStream();
                DecompressStream(inputStream, deserInputStream);
                deserInputStream.Position = 0;
            }
            else
            {
                deserInputStream = inputStream;
            }

            var formatter = new BinaryFormatter();
            object o = formatter.Deserialize(deserInputStream);
            return o;
        }

        private static void CompressStream(Stream inputStream, Stream outputStream)
        {
            // Compress the stream contents
            using (var compressionStream = new GZipStream(outputStream, CompressionMode.Compress))
            {
                inputStream.CopyTo(compressionStream);
            }
        }

        private static void DecompressStream(Stream compressedStream, Stream outputStream)
        {
            // Decompress the stream contents
            using (var decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            {
                decompressionStream.CopyTo(outputStream);
            }
        }

        private static IEnumerable<string> ChunksUpTo(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
            {
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
            }
        }
    }
}
