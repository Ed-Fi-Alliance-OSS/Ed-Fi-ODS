// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using EdFi.Ods.Common.Compression;
using EdFi.Ods.Common.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace EdFi.Ods.Common.Repositories
{
    public class GetBySpecificationResult<TEntity>
        where TEntity : IHasIdentifier, IMappable
    {
        public IList<ResultItem<TEntity>> Results { get; set; }

        public ResultMetadata ResultMetadata { get; set; }
    }

    public class ResultMetadata
    {
        public int TotalCount { get; set; }

        public string NextPageToken { get; set; }
    }

    public class ResultItem<TEntity> : IMappable, IDeserializable
        where TEntity : IMappable
    {
        // This is copied verbatim from NewtonsoftJsonOptionConfigurator due to difficulty in getting it via DI
        private readonly JsonSerializerSettings _serializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc,
            DateParseHandling = DateParseHandling.None,
            Formatting = Formatting.Indented,
            Converters = new JsonConverter[] { new Int64Converter() },
            ContractResolver = new CamelCasePropertyNamesContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
                {
                    ProcessDictionaryKeys = true,
                    OverrideSpecifiedNames = true,
                }
            }
        };
        
        public ResultItem(TEntity entity)
        {
            Entity = entity;
        }

        public ResultItem(TEntity entity, byte[] json)
        {
            Entity = entity;
            Json = json;
        }

        public ResultItem(byte[] json)
        {
            Json = json;
        }

        public TEntity Entity { get; set; }
        public byte[] Json { get; set; }

        public void Map(object target)
        {
            Entity.Map(target);
        }

        public bool TryDeserialize<TTarget>(out TTarget deserialized)
        {
            if (Json != null)
            {
                deserialized = CompressionHelper.DecompressAndDeserialize<TTarget>(Json, _serializerSettings);
                return true;
            }

            deserialized = default;
            return false;
        }
    }
}
