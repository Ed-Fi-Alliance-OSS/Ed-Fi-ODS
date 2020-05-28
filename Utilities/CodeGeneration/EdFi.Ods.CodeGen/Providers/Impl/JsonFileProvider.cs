// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.IO;
using Castle.Core.Logging;
using Newtonsoft.Json;

namespace EdFi.Ods.CodeGen.Providers.Impl
{
    public class JsonFileProvider : IJsonFileProvider
    {
        public ILogger Logger { get; set; } = NullLogger.Instance;

        public T Load<T>(string fileFullName)
        {
            if (!File.Exists(fileFullName))
            {
                throw new FileNotFoundException($"Non-existent file path provided. Expected location {fileFullName}.");
            }

            Logger.Debug($"Deserializing object type {typeof(T)} from file {fileFullName}.");

            using (StreamReader file = File.OpenText(fileFullName))
            {
                JsonSerializer serializer = new JsonSerializer();
                return (T) serializer.Deserialize(file, typeof(T));
            }
        }
    }
}
