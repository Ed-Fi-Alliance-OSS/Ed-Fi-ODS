// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Common;
using EdFi.Ods.Common.Caching;
using EdFi.Ods.Common.Exceptions;
using log4net;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace EdFi.Ods.Features.ExternalCache
{
    public class ExternalCacheProvider : IExternalCacheProvider
    {
        private const string GuidPrefix = "(Guid)";
        private const string IntPrefix = "(int)";
        private const string DefaultExceptionMessage = "Unable to access distributed cache.";

        private readonly IDistributedCache _distributedCache;
        private readonly TimeSpan _absoluteExpiration;
        private readonly TimeSpan _slidingExpiration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(ExternalCacheProvider));

        private static readonly JsonSerializerSettings _nonGenericSerializerSettings =
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        private static readonly JsonSerializerSettings _customContractSerializerSettings =
            new JsonSerializerSettings { ContractResolver = new CustomContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public ExternalCacheProvider(IDistributedCache distributedCache, TimeSpan slidingExpiration, TimeSpan absoluteExpiration)
        {
            _distributedCache = distributedCache;
            _slidingExpiration = slidingExpiration;
            _absoluteExpiration = absoluteExpiration;
        }
        bool ICacheProvider.TryGetCachedObject(string key, out object value)
        {
            try
            {
                var cachedValue = _distributedCache.GetString(key);

                if (!string.IsNullOrEmpty(cachedValue))
                {
                    value = Deserialize(cachedValue);
                    return true;
                }

                value = null;
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException(DefaultExceptionMessage, ex);
            }
        }

        void ICacheProvider.SetCachedObject(string keyName, object obj)
        {
            try
            {
                _distributedCache.SetString(keyName, Serialize(obj), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = _absoluteExpiration.TotalSeconds > 0 ? _absoluteExpiration : null,
                    SlidingExpiration = _slidingExpiration.TotalSeconds > 0 ? _slidingExpiration : null
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException(DefaultExceptionMessage, ex);
            }
        }

        void ICacheProvider.Insert(string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            try
            {
                _distributedCache.SetString(key, Serialize(value), new DistributedCacheEntryOptions()
                {
                    AbsoluteExpiration = absoluteExpiration < DateTime.MaxValue ? absoluteExpiration : null,
                    SlidingExpiration = slidingExpiration.TotalSeconds > 0 ? slidingExpiration : null
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException(DefaultExceptionMessage, ex);
            }
        }

        bool IExternalCacheProvider.KeyExists(string key)
        {
            try
            {
                return _distributedCache.Get(key).Any();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException(DefaultExceptionMessage, ex);
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

            return JsonConvert.SerializeObject(@object, _nonGenericSerializerSettings);
        }

        bool IExternalCacheProvider.TryGetCachedObject<T>(string key, out T value)
        {
            try
            {
                var cachedValue = _distributedCache.GetString(key);

                if (!string.IsNullOrEmpty(cachedValue))
                {
                    try
                    {
                        value = JsonConvert.DeserializeObject<T>(cachedValue, _customContractSerializerSettings);
                        return true;
                    }
                    catch (JsonException e)
                    {
                        _logger.Warn($"Exception during deserialization of the string \"{cachedValue}\". Message: \"{e.Message}\"");
                    }
                }

                value = default;
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw new DistributedCacheException(DefaultExceptionMessage, ex);
            }
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
                return JsonConvert.DeserializeObject(@string, _nonGenericSerializerSettings);
            }
            catch (JsonException e)
            {
                _logger.Warn($"Exception during deserialization of the string \"{@string}\". Message: \"{e.Message}\"");
                return null;
            }
        }

        private static TimeSpan DetermineEarlier(DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            TimeSpan timeUntilAbsolute = absoluteExpiration.Subtract(DateTime.Now);

            if (slidingExpiration <= TimeSpan.Zero)
            {
                return timeUntilAbsolute;
            }

            return timeUntilAbsolute < slidingExpiration
                ? timeUntilAbsolute
                : slidingExpiration;
        }

        /// <summary>
        /// A contract resolver implementation that prefers the most specific constructor for a class being
        /// deserialized.
        /// </summary>
        /// <remarks>
        /// Source from: https://stackoverflow.com/questions/23017716/json-net-how-to-deserialize-without-using-the-default-constructor
        /// </remarks>
        private class CustomContractResolver : DefaultContractResolver
        {
            protected override JsonObjectContract CreateObjectContract(Type objectType)
            {
                var c = base.CreateObjectContract(objectType);

                if (!IsCustomClass(objectType))
                {
                    return c;
                }

                IList<ConstructorInfo> constructors = objectType
                    .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .OrderBy(e => e.GetParameters().Length).ToList();

                var mostSpecificConstructor = constructors.LastOrDefault();

                if (mostSpecificConstructor != null)
                {
                    c.OverrideCreator = CreateParameterizedConstructor(mostSpecificConstructor);

                    foreach (JsonProperty constructorParameter in CreateConstructorParameters(
                        mostSpecificConstructor, c.Properties))
                    {
                        c.CreatorParameters.Add(constructorParameter);
                    }
                }

                return c;
            }

            private static bool IsCustomClass(Type objectType)
                => !objectType.IsPrimitive &&
                   !objectType.IsEnum &&
                   !string.IsNullOrEmpty(objectType.Namespace) &&
                   !objectType.Namespace.StartsWith("System.");

            private static ObjectConstructor<object> CreateParameterizedConstructor(MethodBase method)
            {
                Preconditions.ThrowIfNull(method, nameof(method));

                var c = method as ConstructorInfo;

                if (c != null)
                {
                    return a => c.Invoke(a);
                }

                return a => method.Invoke(null, a);
            }
        }
    }
}
