// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Web;
using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.Context
{
    /// <summary>
    /// Provides an <see cref="IContextStorage"/> implementation that is backed by <see cref="HttpContext"/>.
    /// </summary>
    public class HttpContextStorage : IContextStorage
    {
        private readonly IContextStorage _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpContextStorage"/> class with a secondary 
        /// <see cref="IContextStorage"/> implementation to use in scenarios where <see cref="HttpContext.Current"/>
        /// is null (such as in background Tasks).
        /// </summary>
        /// <param name="next">The secondary context storage to use when <see cref="HttpContext.Current"/> is null.</param>
        public HttpContextStorage(IContextStorage next)
        {
            _next = next;
        }

        /// <summary>
        /// Saves a value using into context using the specified key.
        /// </summary>
        /// <param name="key">The key to use when storing/retrieving the value.</param>
        /// <param name="value">The value to be stored.</param>
        public void SetValue(string key, object value)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Items[key] = value;
            }
            else
            {
                if (_next != null)
                {
                    // Pass call through to the secondary context storage
                    _next.SetValue(key, value);
                }
                else
                {
                    throw new NullReferenceException(
                        "HttpContext.Current is null and no secondary IContextStorage was provided (useful in situations where context needs to be passed from HttpContext to worker threads in an ASP.NET application).");
                }
            }
        }

        /// <summary>
        /// Gets a value by key from context converted to the type specified by "T", or the default value for the type if not present.
        /// </summary>
        /// <typeparam name="T">The data type to which the value should be converted.</typeparam>
        /// <param name="key">The key associated with the value to return.</param>
        /// <returns>The value from context if present; otherwise the default value for the type.</returns>
        public T GetValue<T>(string key)
        {
            if (HttpContext.Current != null)
            {
                if (!HttpContext.Current.Items.Contains(key))
                {
                    return default(T);
                }

                return (T) HttpContext.Current.Items[key];
            }

            // No HttpContext
            if (_next != null)
            {
                return _next.GetValue<T>(key);
            }

            // No HttpContext, no secondary context - throw a meaningful exception
            throw new NullReferenceException(
                "HttpContext.Current is null and no secondary IContextStorage was provided (required in situations where context needs to be passed from HttpContext to worker threads in an ASP.NET application).");
        }
    }
}
