// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace EdFi.Ods.Api.Startup
//namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Custom implementation for <see cref="IApplicationBuilder"/>.
    /// Pulled from .NET 6 release branch.
    /// </summary>
    // TODO: Remove once migration to .NET 8 is done
    public class EdFiCustomApplicationBuilder : IApplicationBuilder
    {
        private const string ServerFeaturesKey = "server.Features";
        private const string ApplicationServicesKey = "application.Services";

        private readonly List<Func<RequestDelegate, RequestDelegate>> _components = new();

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationBuilder"/>.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> for application services.</param>
        public EdFiCustomApplicationBuilder(IServiceProvider serviceProvider)
        {
            Properties = new Dictionary<string, object>(StringComparer.Ordinal);
            ApplicationServices = serviceProvider;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ApplicationBuilder"/>.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> for application services.</param>
        /// <param name="server">The server instance that hosts the application.</param>
        public EdFiCustomApplicationBuilder(IServiceProvider serviceProvider, object server)
            : this(serviceProvider)
        {
            SetProperty(ServerFeaturesKey, server);
        }

        private EdFiCustomApplicationBuilder(IApplicationBuilder builder)
        {
            Properties = new CopyOnWriteDictionary<string, object>(builder.Properties, StringComparer.Ordinal);
        }

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> for application services.
        /// </summary>
        public IServiceProvider ApplicationServices
        {
            get
            {
                return GetProperty<IServiceProvider>(ApplicationServicesKey)!;
            }
            set
            {
                SetProperty<IServiceProvider>(ApplicationServicesKey, value);
            }
        }

        /// <summary>
        /// Gets the <see cref="IFeatureCollection"/> for server features.
        /// </summary>
        public IFeatureCollection ServerFeatures
        {
            get
            {
                return GetProperty<IFeatureCollection>(ServerFeaturesKey)!;
            }
        }

        /// <summary>
        /// Gets a set of properties for <see cref="ApplicationBuilder"/>.
        /// </summary>
        public IDictionary<string, object> Properties { get; }

        private T GetProperty<T>(string key)
        {
            return Properties.TryGetValue(key, out var value) ? (T)value : default(T);
        }

        private void SetProperty<T>(string key, T value)
        {
            Properties[key] = value;
        }

        /// <summary>
        /// Adds the middleware to the application request pipeline.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <returns>An instance of <see cref="IApplicationBuilder"/> after the operation has completed.</returns>
        public IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware)
        {
            _components.Add(middleware);
            return this;
        }

        /// <summary>
        /// Creates a copy of this application builder.
        /// <para>
        /// The created clone has the same properties as the current instance, but does not copy
        /// the request pipeline.
        /// </para>
        /// </summary>
        /// <returns>The cloned instance.</returns>
        public IApplicationBuilder New()
        {
            return new EdFiCustomApplicationBuilder((IApplicationBuilder)this);
        }

        /// <summary>
        /// Produces a <see cref="RequestDelegate"/> that executes added middlewares.
        /// </summary>
        /// <returns>The <see cref="RequestDelegate"/>.</returns>
        public RequestDelegate Build()
        {
            RequestDelegate app = context =>
            {
                // If we reach the end of the pipeline, but we have an endpoint, then something unexpected has happened.
                // This could happen if user code sets an endpoint, but they forgot to add the UseEndpoint middleware.
                var endpoint = context.GetEndpoint();
                var endpointRequestDelegate = endpoint?.RequestDelegate;
                if (endpointRequestDelegate != null)
                {
                    var message =
                        $"The request reached the end of the pipeline without executing the endpoint: '{endpoint!.DisplayName}'. " +
                        $"Please register the EndpointMiddleware using '{nameof(IApplicationBuilder)}.UseEndpoints(...)' if using " +
                        $"routing.";
                    throw new InvalidOperationException(message);
                }

                // ==========================
                // NOTE: Customization BEGIN
                // --------------------------

                // Flushing the response and calling through to the next middleware in the pipeline is
                // a user error, but don't attempt to set the status code if this happens. It leads to a confusing
                // behavior where the client response looks fine, but the server side logic results in an exception.
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }

                // --------------------------
                // NOTE: Customization END
                // ==========================

                return Task.CompletedTask;
            };

            for (var c = _components.Count - 1; c >= 0; c--)
            {
                app = _components[c](app);
            }

            return app;
        }
    }

    // TODO: Remove once migration to .NET 8 is done
    internal class CopyOnWriteDictionary<TKey, TValue> : IDictionary<TKey, TValue> where TKey : notnull
    {
        private readonly IDictionary<TKey, TValue> _sourceDictionary;
        private readonly IEqualityComparer<TKey> _comparer;
        private IDictionary<TKey, TValue> _innerDictionary;

        public CopyOnWriteDictionary(
            IDictionary<TKey, TValue> sourceDictionary,
            IEqualityComparer<TKey> comparer)
        {
            ArgumentNullException.ThrowIfNull(sourceDictionary);
            ArgumentNullException.ThrowIfNull(comparer);

            _sourceDictionary = sourceDictionary;
            _comparer = comparer;
        }

        private IDictionary<TKey, TValue> ReadDictionary
        {
            get
            {
                return _innerDictionary ?? _sourceDictionary;
            }
        }

        private IDictionary<TKey, TValue> WriteDictionary
        {
            get
            {
                if (_innerDictionary == null)
                {
                    _innerDictionary = new Dictionary<TKey, TValue>(_sourceDictionary,
                                                                    _comparer);
                }

                return _innerDictionary;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return ReadDictionary.Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return ReadDictionary.Values;
            }
        }

        public int Count
        {
            get
            {
                return ReadDictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                return ReadDictionary[key];
            }
            set
            {
                WriteDictionary[key] = value;
            }
        }

        public bool ContainsKey(TKey key)
        {
            return ReadDictionary.ContainsKey(key);
        }

        public void Add(TKey key, TValue value)
        {
            WriteDictionary.Add(key, value);
        }

        public bool Remove(TKey key)
        {
            return WriteDictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            return ReadDictionary.TryGetValue(key, out value);
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            WriteDictionary.Add(item);
        }

        public void Clear()
        {
            WriteDictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ReadDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            ReadDictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return WriteDictionary.Remove(item);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return ReadDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // TODO: Remove once migration to .NET 8 is done
    public class CustomApplicationBuilderFactory : IApplicationBuilderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initialize a new factory instance with an <see cref="IServiceProvider" />.
        /// </summary>
        /// <param name="serviceProvider">The <see cref="IServiceProvider"/> used to resolve dependencies and initialize components.</param>
        public CustomApplicationBuilderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Create an <see cref="IApplicationBuilder" /> builder given a <paramref name="serverFeatures" />.
        /// </summary>
        /// <param name="serverFeatures">An <see cref="IFeatureCollection"/> of HTTP features.</param>
        /// <returns>An <see cref="IApplicationBuilder"/> configured with <paramref name="serverFeatures"/>.</returns>
        public IApplicationBuilder CreateBuilder(IFeatureCollection serverFeatures)
        {
            return new EdFiCustomApplicationBuilder(_serviceProvider, serverFeatures);
        }
    }
}