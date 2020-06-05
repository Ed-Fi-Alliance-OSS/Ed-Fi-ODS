// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Api.NetCore.Infrastructure.Context
{
    /// <summary>
    /// Transfers required context from <see cref="HttpContext"/> to <see cref="CallContext"/>.
    /// </summary>
    public class HttpContextStorageTransfer : IHttpContextStorageTransfer
    {
        private readonly CallContextStorage _callContextStorage;
        private readonly IContextStorage _httpContextStorage;
        private readonly IHttpContextStorageTransferKeys[] _httpContextStorageTransferKeys;

        public HttpContextStorageTransfer(
            IContextStorage httpContextStorage,
            CallContextStorage callContextStorage,
            IHttpContextStorageTransferKeys[] httpContextStorageTransferKeys)
        {
            _httpContextStorage = httpContextStorage;
            _callContextStorage = callContextStorage;
            _httpContextStorageTransferKeys = httpContextStorageTransferKeys;
        }

        /// <summary>
        /// Transfers necessary context from <see cref="HttpContext"/> to the injected underlying context provider (e.g. <see cref="CallContext"/>, for running background worker threads in ASP.NET applications).
        /// </summary>
        public void TransferContext()
        {
            // Iterate through all context storage keys providers
            foreach (var keys in _httpContextStorageTransferKeys)
            {
                // Add each key/value pair to the call context
                foreach (string key in keys.GetKeys())
                {
                    _callContextStorage.SetValue(key, _httpContextStorage.GetValue<object>(key));
                }
            }
        }
    }
}
