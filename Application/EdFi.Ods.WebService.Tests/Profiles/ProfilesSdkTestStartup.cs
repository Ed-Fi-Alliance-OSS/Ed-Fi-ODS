// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Threading.Tasks;
using EdFi.Ods.Common.Utils.Profiles;
using Microsoft.Owin;
using Owin;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    // TODO: JSM - these test may go away in swagger 3.0. If they do we can delete this code, otherwise it will need to be addressed at that time.
    public class ProfilesSdkTestStartup : ProfilesTestStartup
    {
        public override void Configuration(IAppBuilder appBuilder)
        {
            base.Configuration(appBuilder);

            //Call custom OWIN component
            appBuilder.Use(typeof(ProfilesSdkCustomMiddleware));
        }

        private class ProfilesSdkCustomMiddleware : OwinMiddleware
        {
            private readonly OwinMiddleware _next;

            public ProfilesSdkCustomMiddleware(OwinMiddleware next)
                : base(next)
            {
                _next = next;
            }

            public override async Task Invoke(IOwinContext context)
            {
                var request = context.Request;
                var response = context.Response;

                var requestAcceptExists = request.Accept != null;

                var isApiResourceRequest = requestAcceptExists
                                           && request.Accept.IsEdFiContentType()
                                           && request.Method == "GET";

                var originalRequestedContentType = string.Empty;

                if (isApiResourceRequest)
                {
                    originalRequestedContentType = request.Accept;
                    request.Accept = "application/json";
                }

                response.OnSendingHeaders(
                    state =>
                    {
                        var owinResponseState = (OwinResponse) state;

                        if (isApiResourceRequest
                            && owinResponseState.StatusCode == 200)
                        {
                            owinResponseState.Headers.Set("Content-Type", originalRequestedContentType);
                        }
                    },
                    response);

                await _next.Invoke(context);
            }
        }
    }
}
