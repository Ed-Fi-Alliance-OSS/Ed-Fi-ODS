// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Api.Controllers.DataManagement.Authorization.Claims
{
    public interface IEducationOrganizationDiscriminatorProvider
    {
        /// <summary>
        /// Gets the discriminator value for the specified education organization as a <see cref="FullName" />.
        /// </summary>
        /// <param name="educationOrganizationId">The identifier of the education organization.</param>
        /// <returns>The <see cref="FullName" /> representation of the discriminator value.</returns>
        FullName GetDiscriminator(int educationOrganizationId);
    }
}
