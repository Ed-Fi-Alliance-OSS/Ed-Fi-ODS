// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    /// <summary>
    /// Defines a method for obtaining Person identifiers for cache warming purposes.
    /// </summary>
    public interface IPersonIdentifiersProvider
    {
        /// <summary>
        /// Gets the identifier values available for all members of the specified Person type as a streaming enumerable.
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested (e.g. Student, Staff or Parent).</param>
        /// <returns>An enumerable collection of <see cref="PersonIdentifiersValueMap"/> instances containing the available identifiers 
        /// for UniqueId and the corresponding Id and/or USI values (depending on the implementation).</returns>
        /// <remarks>Consumers should read all the data immediately because implementations should "stream" the 
        /// data back for efficiency reasons, holding on resources such as a database connection until reading is
        /// complete.
        /// </remarks>
        Task<IEnumerable<PersonIdentifiersValueMap>> GetAllPersonIdentifiers(string personType);
    }
}
