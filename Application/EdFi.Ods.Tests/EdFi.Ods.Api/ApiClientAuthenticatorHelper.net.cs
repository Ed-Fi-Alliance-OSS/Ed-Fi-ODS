// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Security;
using Rhino.Mocks;

namespace EdFi.Ods.Tests.EdFi.Ods.Api
{
    internal class ApiClientAuthenticatorHelper
    {
        public IApiClientAuthenticator Mock(MockRepository mocks)
        {
            var apiClientAuthenticator = mocks.Stub<IApiClientAuthenticator>();
            ApiClientIdentity apiClientIdentity;

            apiClientAuthenticator
               .Stub(aca => aca.TryAuthenticate("good_clientId", "good_clientSecret", out apiClientIdentity))
               .IgnoreArguments()
               .Do(
                    new ApiClientAuthenticatorDelegates.TryAuthenticateDelegate(
                        (string key, string password, out ApiClientIdentity identity) =>
                        {
                            identity = new ApiClientIdentity
                                       {
                                           Key = key
                                       };

                            return true;
                        }));

            return apiClientAuthenticator;
        }

        public IApiClientAuthenticator MockFalse(MockRepository mocks)
        {
            var apiClientAuthenticator = mocks.Stub<IApiClientAuthenticator>();
            ApiClientIdentity apiClientIdentity;

            apiClientAuthenticator
               .Stub(aca => aca.TryAuthenticate("badClientId", "badClientSecret", out apiClientIdentity))
               .IgnoreArguments()
               .Do(
                    new ApiClientAuthenticatorDelegates.TryAuthenticateDelegate(
                        (string key, string password, out ApiClientIdentity identity) =>
                        {
                            identity = null;
                            return false;
                        }));

            return apiClientAuthenticator;
        }
    }
}
