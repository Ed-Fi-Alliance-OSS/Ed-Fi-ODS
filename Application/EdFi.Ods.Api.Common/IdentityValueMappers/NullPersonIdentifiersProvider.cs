// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Threading.Tasks;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.Api.Common.IdentityValueMappers
{
    /// <summary>
    /// Implements a version of the <see cref="IPersonIdentifiersProvider"/> that effectively disables the 
    /// cache warming behavior of the <see cref="EdFi.Ods.Common.Caching.IPersonUniqueIdToUsiCache"/>.
    /// </summary>
    public class NullPersonIdentifiersProvider : IPersonIdentifiersProvider
    {
        /// <summary>
        /// Returns an empty enumerable.
        /// </summary>
        /// <param name="personType">The type of person whose UniqueId is being requested (e.g. Student, Staff or Parent).</param>
        /// <returns>An empty enumerable.</returns>
        public async Task<IEnumerable<PersonIdentifiersValueMap>> GetAllPersonIdentifiers(string personType)
        {
            return await Task.Run(
                () => new PersonIdentifiersValueMap[]
                      { });
        }
    }
}
