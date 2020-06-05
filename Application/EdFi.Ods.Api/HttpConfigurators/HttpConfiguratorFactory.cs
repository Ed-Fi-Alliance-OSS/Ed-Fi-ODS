// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Web.Http;
using System.Web.Http.Dependencies;
using EdFi.Ods.Api.Architecture;

namespace EdFi.Ods.Api.HttpConfigurators
{
    public class HttpConfiguratorFactory : IHttpConfiguratorFactory
    {
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IHttpConfigurator[] _httpConfigurators;

        public HttpConfiguratorFactory(IDependencyResolver dependencyResolver, IHttpConfigurator[] httpConfigurators)
        {
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
            _httpConfigurators = httpConfigurators ?? throw new ArgumentNullException(nameof(httpConfigurators));
        }

        public HttpConfiguration Configure()
        {
            var httpConfig = new HttpConfiguration
                             {
                                 DependencyResolver = _dependencyResolver
                             };

            foreach (var httpConfigurator in _httpConfigurators)
            {
                httpConfigurator.Configure(httpConfig);
            }

            httpConfig.EnsureInitialized();

            return httpConfig;
        }
    }
}
