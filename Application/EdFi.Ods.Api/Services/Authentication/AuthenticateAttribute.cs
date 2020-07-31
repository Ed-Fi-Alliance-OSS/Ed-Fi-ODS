// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EdFi.Ods.Api.Services.Authentication
{
    public class AuthenticateAttribute : ActionFilterAttribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var authenticationProvider = GetService<IAuthenticationProvider>(context.ActionContext);

            await authenticationProvider.Authenticate(context, cancellationToken);
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var authenticationProvider = GetService<IAuthenticationProvider>(context.ActionContext);

            await authenticationProvider.Challenge(context, cancellationToken);
        }

        public override bool AllowMultiple => false;

        // NOTE: the use of service location is by design as we cannot use dependency injection for attributes within MVC.
        // There is a path that would require more infrastructure (c.f. https://gist.github.com/kcargile/7cf2d69f97ef7b9c549c) 
        // that could be implemented for MVC but then we would be required to manage all attributes via a custom filter provider.
        private T GetService<T>(HttpActionContext actionContext)
        {
            return (T) actionContext.Request.GetDependencyScope()
                                    .GetService(typeof(T));
        }
    }
}
