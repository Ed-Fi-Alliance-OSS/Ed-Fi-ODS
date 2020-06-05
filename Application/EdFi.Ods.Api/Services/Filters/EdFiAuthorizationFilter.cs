// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using EdFi.Ods.Api.Common.ExceptionHandling;
using EdFi.Ods.Api.Services.CustomActionResults;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Security.Claims;
using EdFi.Security.DataAccess.Repositories;

namespace EdFi.Ods.Api.Services.Filters
{
    [AttributeUsage(AttributeTargets.All)]
    public class EdFiAuthorizationAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the name of the resource being authorized.
        /// </summary>
        public string Resource { get; set; }
    }

    /// <summary>
    /// This class is intended for use only with the EdFi.Identity.IdentitiesController
    /// For Identity we don't need to populate an EdFiAuthorizationContextData object and can use the Principal set on the rquest context.
    /// Use of this filter with EdFi.ODS.Api.Controllers will not work with current implementation.
    /// </summary>
    public class EdFiAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IEdFiAuthorizationProvider _authorizationProvider;
        private readonly IRESTErrorProvider _restErrorProvider;
        private readonly ISecurityRepository _securityRepository;

        public EdFiAuthorizationFilter(
            IEdFiAuthorizationProvider authorizationProvider,
            ISecurityRepository securityRepository,
            IRESTErrorProvider restErrorProvider)
        {
            _authorizationProvider = authorizationProvider;
            _securityRepository = securityRepository;
            _restErrorProvider = restErrorProvider;
        }

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            var actionAttribute = actionContext.ActionDescriptor.GetCustomAttributes<EdFiAuthorizationAttribute>()
                                               .SingleOrDefault();

            var controllerAttribute = actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<EdFiAuthorizationAttribute>()
                                                   .SingleOrDefault();

            var authorizationAttribute = actionAttribute ?? controllerAttribute;

            if (authorizationAttribute == null)
            {
                return await continuation();
            }

            try
            {
                await _authorizationProvider.AuthorizeSingleItemAsync(
                    CreateAuthorizationContext(actionContext, authorizationAttribute),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                var restError = _restErrorProvider.GetRestErrorFromException(ex);

                var result = string.IsNullOrWhiteSpace(restError.Message)
                    ? new StatusCodeResult((HttpStatusCode) restError.Code, actionContext.Request)
                    : new StatusCodeResult((HttpStatusCode) restError.Code, actionContext.Request).WithError(restError.Message);

                return await result.ExecuteAsync(cancellationToken);
            }

            return await continuation();
        }

        public bool AllowMultiple
        {
            get { return false; }
        }

        private EdFiAuthorizationContext CreateAuthorizationContext(
            HttpActionContext actionContext,
            EdFiAuthorizationAttribute authorizationAttribute)
        {
            return new EdFiAuthorizationContext(
                (ClaimsPrincipal) actionContext.RequestContext.Principal,
                EdFiConventions.GetApiResourceClaimUris(authorizationAttribute.Resource),
                _securityRepository.GetActionByHttpVerb(actionContext.Request.Method.Method)
                                   .ActionUri,
                null as object);
        }
    }
}
