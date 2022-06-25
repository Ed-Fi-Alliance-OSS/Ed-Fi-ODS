// Copyright (c) 2021 Instructure Inc.

using EdFi.Common;
using EdFi.Ods.Api.Caching;
using EdFi.Ods.Common.Caching;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace EdFi.Ods.Features.Redis
{
    public class RedisCacheProvider : IRedisCacheProvider
    {
        private const string GuidPrefix = "(Guid)";
        private const string IntPrefix = "(int)";

        private readonly IConnectionMultiplexer _redis;
        private readonly TimeSpan _defaultExpiration;
        private readonly ILog _logger = LogManager.GetLogger(typeof(RedisCacheProvider));

        private static readonly JsonSerializerSettings _defaultSerializerSettings =
            new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        private static readonly JsonSerializerSettings _nonGenericSerializerSettings =
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects, ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        private static readonly JsonSerializerSettings _customContractSerializerSettings =
            new JsonSerializerSettings { ContractResolver = new CustomContractResolver(), ReferenceLoopHandling = ReferenceLoopHandling.Ignore };

        public RedisCacheProvider(IConnectionMultiplexer redis, TimeSpan defaultExpiration)
        {
            _redis = redis;
            _defaultExpiration = defaultExpiration;
        }

        bool ICacheProvider.TryGetCachedObject(string key, out object value)
        {
            var cachedValue = _redis.GetDatabase().StringGet(key);

            if (!cachedValue.IsNull)
            {
                value = Deserialize(cachedValue);
                return true;
            }

            value = null;
            return false;
        }

        void ICacheProvider.SetCachedObject(string keyName, object obj)
        {
            _redis.GetDatabase().StringSet(keyName, Serialize(obj), _defaultExpiration);
        }

        void ICacheProvider.Insert(
            string key, object value, DateTime absoluteExpiration, TimeSpan slidingExpiration)
        {
            TimeSpan? expiry = DetermineEarlier(absoluteExpiration, slidingExpiration);

            _redis.GetDatabase().StringSet(key, Serialize(value), expiry);
        }

        bool IRedisCacheProvider.TryGetCachedObjectFromHash<T>(string key, string hashField, out T value)
        {
            var cachedValue = _redis.GetDatabase().HashGet(key, hashField);

            if (!cachedValue.IsNull)
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

        void IRedisCacheProvider.InsertToHash(string key, string hashField, object value)
        {
            _redis.GetDatabase().HashSet(key, hashField, JsonConvert.SerializeObject(value));
        }

        void IRedisCacheProvider.Insert<T>(
            string key,
            IDictionary<string, T> dictionary,
            DateTime absoluteExpiration,
            TimeSpan slidingExpiration)
        {
            HashEntry[] hashFields = dictionary
                .Select(kvp => new HashEntry(kvp.Key, JsonConvert.SerializeObject(kvp.Value, _defaultSerializerSettings)))
                .ToArray();

            TimeSpan? expiry = DetermineEarlier(absoluteExpiration, slidingExpiration);

            IDatabase db = _redis.GetDatabase();
            db.HashSet(key, hashFields);
            db.KeyExpire(key, expiry);
        }

        bool IRedisCacheProvider.KeyExists(string key) => _redis.GetDatabase().KeyExists(key);

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

            if (@object is PersonUniqueIdToUsiCache.IdentityValueMaps identityValueMaps)
            {
                return identityValueMaps.Serialize();
            }

            return JsonConvert.SerializeObject(@object, _nonGenericSerializerSettings);
        }

        bool IRedisCacheProvider.TryGetCachedObject<T>(string key, out T value, int db)
        {
            var cachedValue = _redis.GetDatabase(db).StringGet(key);

            if (!cachedValue.IsNull)
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

        void IRedisCacheProvider.Insert(string key,
            object value,
            DateTime absoluteExpiration,
            TimeSpan slidingExpiration,
            int db)
        {
            TimeSpan? expiry = DetermineEarlier(absoluteExpiration, slidingExpiration);

            _redis.GetDatabase(db).StringSet(key, Serialize(value), expiry);
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
