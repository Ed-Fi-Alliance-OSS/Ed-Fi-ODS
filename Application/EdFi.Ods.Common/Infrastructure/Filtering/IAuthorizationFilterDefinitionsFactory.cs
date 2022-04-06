// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;

namespace EdFi.Ods.Common.Infrastructure.Filtering
{
    /// <summary>
    /// Defines a method for creating named filters for use in authorization.
    /// </summary>
    public interface IAuthorizationFilterDefinitionsFactory
    {
        /// <summary>
        /// Gets the NHibernate filter definitions and a functional delegate for determining when to apply them.
        /// </summary>
        /// <returns>A read-only list of filter application details to be applied to the NHibernate configuration and entity mappings.</returns>
        IReadOnlyList<AuthorizationFilterDefinition> CreateAuthorizationFilterDefinitions();
    }
}
