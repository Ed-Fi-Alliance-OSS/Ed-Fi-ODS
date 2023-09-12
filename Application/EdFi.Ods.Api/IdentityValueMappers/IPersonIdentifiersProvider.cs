// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.IdentityValueMappers
{
    /// <summary>
    /// Defines methods for obtaining Person identifiers for cache warming or batch resolution purposes.
    /// </summary>
    public interface IPersonIdentifiersProvider
    {
        /// <summary>
        /// Gets the identifier values available for all members of the specified Person type.
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested (e.g. Student, Staff or Parent/Contact).</param>
        /// <returns>An enumerable collection of <see cref="PersonIdentifiersValueMap"/> instances containing the available identifiers 
        /// for UniqueId and the corresponding Id and/or USI values (depending on the implementation).</returns>
        /// <remarks>Consumers should read all the data immediately because implementations may "stream" the 
        /// data back for efficiency reasons, holding onto resources such as a database connection until reading is
        /// complete.
        /// </remarks>
        Task<IEnumerable<PersonIdentifiersValueMap>> GetAllPersonIdentifiers(string personType);

        /// <summary>
        /// Gets the identifier values available for all members of the specified Person type matching the supplied array of USI values.
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested (e.g. Student, Staff or Parent/Contact).</param>
        /// <returns>An enumerable collection of <see cref="PersonIdentifiersValueMap"/> instances containing the available identifiers 
        /// for UniqueId and the corresponding Id and/or USI values (depending on the implementation).</returns>
        /// <remarks>Consumers should read all the data immediately because implementations may "stream" the 
        /// data back for efficiency reasons, holding onto resources such as a database connection until reading is
        /// complete.
        /// </remarks>
        Task<IEnumerable<PersonIdentifiersValueMap>> GetPersonUniqueIds(string personType, int[] usis);
        
        /// <summary>
        /// Gets the identifier values available for all members of the specified Person type matching the supplied array of UniqueId values.
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested (e.g. Student, Staff or Parent/Contact).</param>
        /// <returns>An enumerable collection of <see cref="PersonIdentifiersValueMap"/> instances containing the available identifiers 
        /// for UniqueId and the corresponding Id and/or USI values (depending on the implementation).</returns>
        /// <remarks>Consumers should read all the data immediately because implementations may "stream" the 
        /// data back for efficiency reasons, holding onto resources such as a database connection until reading is
        /// complete.
        /// </remarks>
        Task<IEnumerable<PersonIdentifiersValueMap>> GetPersonUsis(string personType, string[] uniqueIds);
    }
}
