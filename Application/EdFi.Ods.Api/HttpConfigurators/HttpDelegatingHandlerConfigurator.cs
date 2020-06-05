// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net.Http;
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Common;

namespace EdFi.Ods.Api.HttpConfigurators
{
    public class HttpDelegatingHandlerConfigurator : IHttpConfigurator
    {
        private readonly DelegatingHandler[] _delegatingHandlers;

        public HttpDelegatingHandlerConfigurator(DelegatingHandler[] delegatingHandlers)
        {
            // note this can be null
            _delegatingHandlers = delegatingHandlers;
        }

        public void Configure(HttpConfiguration config)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            if (_delegatingHandlers == null)
            {
                return;
            }

            foreach (var delegatingHandler in _delegatingHandlers)
            {
                config.MessageHandlers.Add(delegatingHandler);
            }
        }
    }
}
