// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Security.Claims;
using System.Threading;

namespace EdFi.Ods.Common.Security.Claims
{
    /// <summary>
    /// Provides a method that can be used as the delegate for the <see cref="ClaimsPrincipal.ClaimsPrincipalSelector"/> method
    /// static delegate.
    /// </summary>
    public static class EdFiClaimsPrincipalSelector
    {
        /// <summary>
        /// Implements the signature needed by the <see cref="ClaimsPrincipal.ClaimsPrincipalSelector"/> static delegate for 
        /// obtaining <see cref="ClaimsPrincipal"/> instances.
        /// </summary>
        /// <returns>The <see cref="ClaimsPrincipal"/> that can be used to make authorization decisions.</returns>
        public static ClaimsPrincipal GetClaimsPrincipal(IClaimsIdentityProvider identityProvider)
        {
            // If we've already establish the OAuth-based claims principal on this thread, return it.
            if (Thread.CurrentPrincipal.Identity.AuthenticationType == EdFiAuthenticationTypes.OAuth)
            {
                return Thread.CurrentPrincipal as ClaimsPrincipal;
            }

            // Establish the ClaimsPrincipal based on the current context
            var claimsIdentity = identityProvider.GetClaimsIdentity();

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
