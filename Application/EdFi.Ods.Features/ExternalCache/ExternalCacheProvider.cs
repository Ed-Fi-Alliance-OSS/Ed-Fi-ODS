// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Globalization;
using EdFi.Common.Security;
using EdFi.Ods.Common.Descriptors;
using EdFi.Ods.Common.Exceptions;
using log4net;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace EdFi.Ods.Features.ExternalCache
{
    /// <summary>
    /// Implements a cache provider for use with external caches that only supports serialization/deserialization of values of
    /// the following types: <see cref="PersonUniqueIdToUsiCache.IdentityValueMaps" />, <see cref="ApiClientDetails" />,
    /// <see cref="Guid" />, <see cref="Int32" />, and <see cref="DescriptorMaps" />.
    /// </summary>
    /// <typeparam name="TKey">The type to be used as the key for entries stored in the cache from the perspective of the API.</typeparam>
    public class ExternalCacheProvider<TKey> : IExternalCacheProvider<TKey>
    {
        private const string GuidPrefix = "(Guid)";
        private const string IntPrefix = "(int)";
        private const string DefaultExceptionMessage = "Unable to access distributed cache.";

        private readonly IDistributedCache _distributedCache;
        private readonly TimeSpan _absoluteExpiration;
        private readonly TimeSpan _slidingExpiration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExternalCacheProvider<TKey>));

        // TypeNameHandling.None for https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca2326
        private static readonly JsonSerializerSettings _defaultSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.None,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public ExternalCacheProvider(IDistributedCache distributedCache, TimeSpan slidingExpiration, TimeSpan absoluteExpiration)
        {
            _distributedCache = distributedCache;
            _slidingExpiration = slidingExpiration;
            _absoluteExpiration = absoluteExpiration;
        }
        
        public bool TryGetCachedObject(TKey key, out object value)
        {
            try
            {
                var keyAsString = key.ToString();
                
                var cachedValue = _distributedCache.GetString(keyAsString);

                if (!string.IsNullOrEmpty(cachedValue))
                {
                    // NOTE: This code doesn't follow SOLID principles. If this logic ever needs to change again, should introduce
                    // an interface (e.g. IDistributeCacheDeserializationHandler) with a method signature as follows:
                    //    bool TryHandle(string key, string cachedValue, out object deserializedValue)
                    // Implementations should return true if it handled the deserialization.
                    //
                    // Inject an array of handlers into the constructor and iterate through them and if deserialization is not
                    // handled, then just deserialize using JsonConvert.DeserializeObject method as is done at the end of the
                    // Deserialize method below.
                    //
                    // Suggested handler implementations: 
                    //   - PersonIdentityValueMapDistributeCacheDeserializationHandler
                    //   - ApiClientDetailsDistributeCacheDeserializationHandler
                    //   - GuidDistributeCacheDeserializationHandler
                    //   - IntDistributeCacheDeserializationHandler
                    //   - DescriptorMapsDistributeCacheDeserializationHandler
                    //
                    // A similar approach is recommended for serialization, though implementations are only needed for int/guid.
                    if (keyAsString.StartsWith(ApiClientDetailsCacheKeyProvider.CacheKeyPrefix))
                    {
                        value = JsonConvert.DeserializeObject<ApiClientDetails>(cachedValue);
                    }
                    else
                    {
                        // Simple cache like Guid and Int32 can be deserialized without explicit type names
                        // For descriptors, the DescriptorMaps type will be used
                        value = Deserialize(cachedValue);
                    }

                    return true;
                }

                value = null;
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException("scenario33.", ex);
            }
        }

        public void SetCachedObject(TKey key, object obj)
        {
            try
            {
                _distributedCache.SetString(key.ToString(), Serialize(obj), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = _absoluteExpiration.TotalSeconds > 0 ? _absoluteExpiration : null,
                    SlidingExpiration = _slidingExpiration.TotalSeconds > 0 ? _slidingExpiration : null
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException("scenario34.", ex);
            }
        }

        public void Insert(TKey key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            try
            {
                _distributedCache.SetString(key.ToString(), Serialize(value), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = absoluteExpiration < DateTime.MaxValue ? absoluteExpiration : null,
                    SlidingExpiration = slidingExpiration.TotalSeconds > 0 ? slidingExpiration : null
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException("scenario35.", ex);
            }
        }

        private static string Serialize(object @object)
        {
            if (@object is Guid guid)
            {
                return $"{GuidPrefix}{guid.ToString("N", CultureInfo.InvariantCulture)}";
            }

            if (@object is int @int)
            {
                return $"{IntPrefix}{@int.ToString(CultureInfo.InvariantCulture)}";
            }

            return JsonConvert.SerializeObject(@object, _defaultSerializerSettings);
        }

        private object Deserialize(string @string)
        {
            if (@string.StartsWith(GuidPrefix, StringComparison.InvariantCulture) &&
                Guid.TryParse(@string[GuidPrefix.Length..], out Guid guid))
            {
                return guid;
            }

            if (@string.StartsWith(IntPrefix, StringComparison.InvariantCulture) &&
                int.TryParse(@string[IntPrefix.Length..], out int @int))
            {
                return @int;
            }

            try
            {
                // JsonConvert.DeserializeObject without a Type, returns a JObject, that will fail to be casted to a DescriptorMaps object
                return JsonConvert.DeserializeObject<DescriptorMaps>(@string, _defaultSerializerSettings);
            }
            catch (JsonException e)
            {
                _logger.Warn($"Exception during deserialization of the string \"{@string}\". Message: \"{e.Message}\"");
                return null;
            }
        }
    }
}
