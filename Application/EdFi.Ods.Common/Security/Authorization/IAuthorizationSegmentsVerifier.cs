// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.
 
using System.Threading;
using System.Threading.Tasks;

namespace EdFi.Ods.Common.Security.Authorization
{
    /// <summary>
    /// Defines a method for executing authorization segments with concrete values are present 
    /// in the ODS database as the final step of authorization of a single-item request.
    /// </summary>
    public interface IAuthorizationSegmentsVerifier
    {
        /// <summary>
        /// Verifies the specified segments exist in the ODS data.
        /// </summary>
        /// <param name="authorizationSegments">The authorization segments to be verified.</param>
        Task VerifyAsync(AuthorizationSegmentCollection authorizationSegments, CancellationToken cancellationToken);
    }
}
