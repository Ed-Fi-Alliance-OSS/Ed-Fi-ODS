// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Api.NHibernate.Architecture
{
    /// <summary>
    /// Defines a method for evicting a cache entry based on an entity's identifier value that been determined to be obsolete.
    /// </summary>
    public interface ICachedEntityIdentifierEvictor
    {
        /// <summary>
        /// Attempts to remove a cache entry based on an entity's identifier.
        /// </summary>
        /// <param name="entity">The entity instance whose identifier has been determined to be obsolete.</param>
        /// <param name="identifierValue">The identifier value that has been determined to be obsolete.</param>
        /// <returns><b>true</b> if an associated entry was evicted; otherwise <b>false</b>.</returns>
        bool TryEvictIdentifier(object entity, object identifierValue);
    }
}
