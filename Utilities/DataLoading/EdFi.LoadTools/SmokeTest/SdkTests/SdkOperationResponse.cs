// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;

namespace EdFi.LoadTools.SmokeTest.SdkTests
{
    /// <summary>
    ///     Shape-agnostic view over an SDK operation result. New-generator SDKs return a response
    ///     object (Client.IApiResponse + Client.IOk&lt;T&gt;) exposing HttpStatusCode StatusCode,
    ///     RawContent, HttpResponseHeaders Headers and a public T Ok() method. Old-generator SDKs,
    ///     invoked through their *WithHttpInfoAsync companions, return ApiResponse&lt;T&gt; with an int
    ///     (or HttpStatusCode) StatusCode, a Data property, a Multimap/dictionary Headers and an
    ///     optional RawContent. This type normalizes both via reflection so a missing member is a
    ///     controlled case rather than a runtime binder crash.
    /// </summary>
    internal sealed class SdkOperationResponse
    {
        private const BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;

        private readonly object _raw;
        private readonly object _statusCodeValue; // null when the raw result carries no StatusCode

        public SdkOperationResponse(object rawResult)
        {
            _raw = rawResult;
            _statusCodeValue = _raw?.GetType().GetProperty("StatusCode", PublicInstance)?.GetValue(_raw);
        }

        /// <summary>The raw SDK result. Diagnostics only.</summary>
        public object RawResult => _raw;

        /// <summary>True when the raw result actually carried a StatusCode (i.e. it is a response wrapper).</summary>
        public bool HasStatusCode => _statusCodeValue != null;

        /// <summary>
        ///     Status normalized to HttpStatusCode. Accepts HttpStatusCode and int (old-generator).
        ///     Defaults to 200 OK when the raw result has no StatusCode (a bare payload): correct for
        ///     GET reads, while POST/PUT/DELETE - which require 201/204 - still fail because 200 never
        ///     satisfies their checks.
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get
            {
                switch (_statusCodeValue)
                {
                    case null:
                        return HttpStatusCode.OK;
                    case HttpStatusCode httpStatusCode:
                        return httpStatusCode;
                    default:
                        return (HttpStatusCode) Convert.ToInt32(_statusCodeValue);
                }
            }
        }

        /// <summary>
        ///     The response payload: new-generator Ok(), else old-generator Data, else the raw result
        ///     itself (a bare payload). Computed on access so Ok() is only invoked when a consumer asks.
        /// </summary>
        public object Payload
        {
            get
            {
                if (_raw == null)
                {
                    return null;
                }

                var type = _raw.GetType();

                var okMethod = type.GetMethod("Ok", PublicInstance, null, Type.EmptyTypes, null);
                if (okMethod != null)
                {
                    return okMethod.Invoke(_raw, null);
                }

                var dataProperty = type.GetProperty("Data", PublicInstance);
                if (dataProperty != null)
                {
                    return dataProperty.GetValue(_raw);
                }

                return _raw;
            }
        }

        /// <summary>The raw response body when present (new-generator and some old-generator), else null.</summary>
        public string RawContent =>
            _raw?.GetType().GetProperty("RawContent", PublicInstance)?.GetValue(_raw) as string;

        /// <summary>
        ///     Case-insensitive header lookup that works across new-generator HttpResponseHeaders
        ///     (TryGetValues) and old-generator Multimap / IDictionary header collections.
        /// </summary>
        public bool TryGetHeader(string name, out IEnumerable<string> values)
        {
            values = Enumerable.Empty<string>();

            var headers = _raw?.GetType().GetProperty("Headers", PublicInstance)?.GetValue(_raw);
            if (headers == null)
            {
                return false;
            }

            // New-generator HttpResponseHeaders (and anything else exposing the same method).
            var tryGetValues = headers.GetType().GetMethod(
                "TryGetValues",
                PublicInstance,
                null,
                new[] { typeof(string), typeof(IEnumerable<string>).MakeByRefType() },
                null);

            if (tryGetValues != null)
            {
                var args = new object[] { name, null };
                if (tryGetValues.Invoke(headers, args) is true && args[1] is IEnumerable<string> headerValues)
                {
                    values = headerValues.ToList();
                    return true;
                }

                return false;
            }

            // Old-generator dictionary/multimap headers: enumerate key/value pairs reflectively.
            if (headers is IEnumerable entries)
            {
                foreach (var entry in entries)
                {
                    if (entry == null)
                    {
                        continue;
                    }

                    var entryType = entry.GetType();
                    if (entryType.GetProperty("Key")?.GetValue(entry) is not string key
                        || !string.Equals(key, name, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    values = CoerceToStrings(entryType.GetProperty("Value")?.GetValue(entry));
                    return true;
                }
            }

            return false;
        }

        private static IEnumerable<string> CoerceToStrings(object value)
        {
            switch (value)
            {
                case null:
                    return Enumerable.Empty<string>();
                case string single:
                    return new[] { single };
                case IEnumerable<string> many:
                    return many.ToList();
                case IEnumerable enumerable:
                    return enumerable.Cast<object>().Select(o => o?.ToString()).ToList();
                default:
                    return new[] { value.ToString() };
            }
        }
    }
}
