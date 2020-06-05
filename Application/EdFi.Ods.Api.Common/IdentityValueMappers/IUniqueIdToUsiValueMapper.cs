// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    /// <summary>
    /// Provides interfaces for mapping between a UniqueId and the USI (the ODS-specific integer-based surrogate identifier).
    /// </summary>
    /// <remarks>
    /// Implementors of this interface should return <see cref="PersonIdentifiersValueMap"/> instances containing at least the
    /// value being requested on each method.  For optimization purposes, they may also return the tertiary identification
    /// value which can then be opportunistically cached by the <see cref="EdFi.Ods.Common.Caching.IPersonUniqueIdToIdCache"/> and/or 
    /// the <see cref="EdFi.Ods.Common.Caching.IPersonUniqueIdToUsiCache"/>component (and in an ODS-specific manner for USI values).
    /// 
    /// If the requested value cannot be found, then a default instance of the <see cref="PersonIdentifiersValueMap"/> should be returned.
    /// </remarks>
    public interface IUniqueIdToUsiValueMapper
    {
        /// <summary>
        /// Gets the identifier values for a given uniqueId value (only guaranteeing the return of the USI and only if it's found).
        /// </summary>
        /// <param name="personType">The type of person whose Id is being requested.</param>
        /// <param name="uniqueId">The uniqueId of the person whose USI is being requested.</param>
        /// <returns>The <see cref="PersonIdentifiersValueMap"/> containing the requested USI (if found), and possibly the 
        /// corresponding resource Id (depending on the implementation); otherwise a <see cref="PersonIdentifiersValueMap"/> instance
        /// containing default values.</returns>
        PersonIdentifiersValueMap GetUsi(string personType, string uniqueId);

        /// <summary>
        /// Gets the identifier values for a given USI (only guaranteeing the return of the UniqueId and only if it's found).
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested.</param>
        /// <param name="usi">The USI of the person whose UniqueId is being requested.</param>
        /// <returns>The <see cref="PersonIdentifiersValueMap"/> containing the requested UniqueId (if found), and possibly the 
        /// corresponding Id (depending on the implementation); otherwise a <see cref="PersonIdentifiersValueMap"/> instance
        /// containing default values.</returns>
        PersonIdentifiersValueMap GetUniqueId(string personType, int usi);
    }
}
