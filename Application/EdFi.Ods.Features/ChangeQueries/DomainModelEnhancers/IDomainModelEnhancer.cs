// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Features.ChangeQueries.DomainModelEnhancers
{
    /// <summary>
    /// Defines a method for enhancing the constructed domain model with additional dynamic properties for use by other
    /// components in the system.
    /// </summary>
    public interface IDomainModelEnhancer
    {
        /// <summary>
        /// Enhances the supplied DomainModel with dynamic properties.
        /// </summary>
        /// <param name="domainModel">The DomainModel to be enhanced.</param>
        void Enhance(DomainModel domainModel);
    }
}
