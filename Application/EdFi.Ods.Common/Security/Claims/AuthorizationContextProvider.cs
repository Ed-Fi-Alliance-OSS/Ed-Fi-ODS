// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Context;

namespace EdFi.Ods.Common.Security.Claims
{
    public interface IAuthorizationContextProvider
    {
        string[] GetResourceUris();

        void SetResourceUris(string[] resourceUris);

        string GetAction();

        void SetAction(string actionUri);

        void VerifyAuthorizationContextExists();
    }

    public class AuthorizationContextProvider : IAuthorizationContextProvider
    {
        private readonly IContextStorage _contextStorage;

        public AuthorizationContextProvider(IContextStorage contextStorage)
        {
            _contextStorage = contextStorage;
        }

        public string[] GetResourceUris()
        {
            return _contextStorage.GetValue<string[]>(AuthorizationContextKeys.Resource);
        }

        public string GetAction()
        {
            return _contextStorage.GetValue<string>(AuthorizationContextKeys.Action);
        }

        public void VerifyAuthorizationContextExists()
        {
            // Verify that the authorization context has been set correctly in upstream processing
            if (string.IsNullOrWhiteSpace(GetAction()))
            {
                throw new AuthorizationContextException(
                    "Authorization cannot be performed because no action has been stored in the current context.");
            }

            string[] resourceUris = GetResourceUris();
            
            if (resourceUris == null || resourceUris.Length == 0)
            {
                throw new AuthorizationContextException(
                    "Authorization cannot be performed because no resource has been stored in the current context.");
            }
        }

        public void SetResourceUris(string[] resourceUris)
        {
            _contextStorage.SetValue(AuthorizationContextKeys.Resource, resourceUris);
        }

        public void SetAction(string actionUri)
        {
            _contextStorage.SetValue(AuthorizationContextKeys.Action, actionUri);
        }
    }
}
