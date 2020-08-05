// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Text.RegularExpressions;
using EdFi.Ods.Common.Caching;

namespace EdFi.Ods.WebService.Tests.Profiles
{
    public class FakePersonUniqueIdToUsiCache : IPersonUniqueIdToUsiCache
    {
        /// <summary>
        /// Gets the externally defined UniqueId for the specified type of person and the ODS-specific surrogate identifier.
        /// </summary>
        /// <param name="personType">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="usi">The integer-based identifier for the specified representation of the person, 
        /// specific to a particular ODS database instance.</param>
        /// <returns>The UniqueId value assigned to the person if found; otherwise <b>null</b>.</returns>
        public string GetUniqueId(string personType, int usi)
        {
            string uniqueId = "S" + usi; // Guid.NewGuid().ToString("n");
            return uniqueId;
        }

        /// <summary>
        /// Gets the ODS-specific integer identifier for the specified type of person and their UniqueId value.
        /// </summary>
        /// <param name="personType">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="uniqueId">The UniqueId value associated with the person.</param>
        /// <returns>The ODS-specific integer identifier for the specified type of representation of 
        /// the person if found; otherwise 0.</returns>
        public int GetUsi(string personType, string uniqueId)
        {
            if (!Regex.IsMatch(uniqueId, "^S[0-9]+$"))
            {
                throw new InvalidOperationException("UniqueId value for test did not follow prescribe format of 'S' followed by numeric value.");
            }

            int usi = int.Parse(uniqueId.Substring(1));

            return usi;
        }

        /// <summary>
        /// Gets the ODS-specific integer identifier for the specified type of person and their UniqueId value.
        /// </summary>
        /// <param name="personTypeName">The type of the person (e.g. Staff, Student, Parent).</param>
        /// <param name="uniqueId">The UniqueId value associated with the person.</param>
        /// <returns>The ODS-specific integer identifier for the specified type of representation of 
        /// the person if found; otherwise <b>null</b>.</returns>
        public int? GetUsiNullable(string personTypeName, string uniqueId)
        {
            throw new NotImplementedException();
        }
    }
}
