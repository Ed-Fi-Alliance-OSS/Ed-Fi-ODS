// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using EdFi.Ods.Common.Context;
using Microsoft.AspNetCore.Http;

namespace EdFi.Ods.Api.NetCore.Infrastructure.Context
{
    public class HttpContextStorage : IContextStorage
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IContextStorage _next;

        public HttpContextStorage(IContextStorage next, IHttpContextAccessor httpContextAccessor)
        {
            _next = next;
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetValue(string key, object value)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Items[key] = value;
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
                        "HttpContext is null and no secondary IContextStorage was provided (useful in situations where context needs to be passed from HttpContext to worker threads in an ASP.NET application).");
                }
            }
        }

        public T GetValue<T>(string key)
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                if (!_httpContextAccessor.HttpContext.Items.ContainsKey(key))
                {
                    return default(T);
                }

                return (T) _httpContextAccessor.HttpContext.Items[key];
            }

            // No HttpContext
            if (_next != null)
            {
                return _next.GetValue<T>(key);
            }

            // No HttpContext, no secondary context - throw a meaningful exception
            throw new NullReferenceException(
                "HttpContext is null and no secondary IContextStorage was provided (required in situations where context needs to be passed from HttpContext to worker threads in an ASP.NET application).");
        }
    }
}
