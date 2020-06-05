// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using System.Web.Http.Dispatcher;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Metadata;

namespace EdFi.Ods.Api.HttpConfigurators
{
    public class HttpRouteConfigurator : IHttpConfigurator
    {
        private readonly IRouteConfiguration[] _routeConfigurations;
        private readonly bool _useSchoolYear;
        private readonly IProfileResourceNamesProvider _profileResourceNamesProvider;
        private readonly ISchemaNameMapProvider _schemaNameMapProvider;

        public HttpRouteConfigurator(IRouteConfiguration[] routeConfigurations,
            IProfileResourceNamesProvider profileResourceNamesProvider,
            ISchemaNameMapProvider schemaNameMapProvider, bool useSchoolYear = false)
        {
            _routeConfigurations = Preconditions.ThrowIfNull(routeConfigurations, nameof(routeConfigurations));

            _profileResourceNamesProvider = Preconditions.ThrowIfNull(
                profileResourceNamesProvider, nameof(profileResourceNamesProvider));

            _schemaNameMapProvider = Preconditions.ThrowIfNull(schemaNameMapProvider, nameof(schemaNameMapProvider));

            _useSchoolYear = useSchoolYear;
        }

        public void Configure(HttpConfiguration config)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            // Map all attribute routes (Web 2.0 feature)
            // Note - MapHttpAttributeRoutes only maps attribute base routes in the current assembly;
            // In order to register attribute base routes in other assemblies we have to call MapHttpAttributeRoutes in that specific assembly
            config.MapHttpAttributeRoutes();

            foreach (IRouteConfiguration routeConfiguration in _routeConfigurations)
            {
                routeConfiguration.ConfigureRoutes(config, _useSchoolYear);
            }

            // Replace the default controller selector with one based on the final namespace segment (to enable support of Profiles)
            // NOTE WELL: this also impacts routing when extensions create controllers with the same name as a standard
            // resource, and thus cannot be moved to the Profiles-specific configurator.
            config.Services.Replace(
                typeof(IHttpControllerSelector),
                new ProfilesAwareHttpControllerSelector(config, _profileResourceNamesProvider, _schemaNameMapProvider));
        }
    }
}
