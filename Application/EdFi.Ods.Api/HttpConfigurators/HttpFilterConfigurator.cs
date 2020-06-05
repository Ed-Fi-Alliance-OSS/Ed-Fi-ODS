// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Web.Http;
using EdFi.Ods.Api.Architecture;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Services.ActionFilters;
using EdFi.Ods.Api.Services.Filters;
using EdFi.Ods.Common;
using EdFi.Ods.Common.Context;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.HttpConfigurators
{
    public class HttpFilterConfigurator : IHttpConfigurator
    {
        private readonly ISchoolYearContextProvider _schoolYearContextProvider;
        private readonly IEdFiAuthorizationProvider _edFiAuthorizationProvider;
        private readonly ISecurityRepository _securityRepository;
        private readonly IRESTErrorProvider _restErrorProvider;

        public HttpFilterConfigurator(ISchoolYearContextProvider schoolYearContextProvider, 
                                      IEdFiAuthorizationProvider edFiAuthorizationProvider,
                                      ISecurityRepository securityRepository,
                                      IRESTErrorProvider restErrorProvider)
        {
            _schoolYearContextProvider = Preconditions.ThrowIfNull(schoolYearContextProvider, nameof(schoolYearContextProvider));
            _edFiAuthorizationProvider = Preconditions.ThrowIfNull(edFiAuthorizationProvider, nameof(edFiAuthorizationProvider));
            _securityRepository = Preconditions.ThrowIfNull(securityRepository, nameof(securityRepository));
            _restErrorProvider = Preconditions.ThrowIfNull(restErrorProvider, nameof(restErrorProvider));
        }

        public void Configure(HttpConfiguration config)
        {
            Preconditions.ThrowIfNull(config, nameof(config));

            var showErrors = config.IncludeErrorDetailPolicy != IncludeErrorDetailPolicy.Never;

            config.Filters.Add(new ExceptionHandlingFilter(showErrors));
            config.Filters.Add(new SchoolYearContextFilter(_schoolYearContextProvider));
            config.Filters.Add(new EdFiAuthorizationFilter(_edFiAuthorizationProvider, _securityRepository, _restErrorProvider));
        }
    }
}
