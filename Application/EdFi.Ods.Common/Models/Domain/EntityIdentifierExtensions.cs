// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;

namespace EdFi.Ods.Common.Models.Domain
{
    public static class EntityIdentifierExtensions
    {
        /// <summary>
        /// Indicates whether the <see cref="EntityIdentifier" /> is the identifier is the alternate identifier added
        /// for the boilerplate "Id" property.  
        /// </summary>
        /// <param name="entityIdentifier">The identifier to be evaluated.</param>
        /// <returns><b>true</b> if the identifier is the alternate identifier added for the boilerplate "Id" property; otherwise <b>false</b>.</returns>
        /// <remarks>This method was added to allow the "Id" identifier to be easily excluded from the <see cref="Entity.AlternateIdentifiers" /> collection.</remarks>
        public static bool IsResourceIdentifier(this EntityIdentifier entityIdentifier)
        {
            return entityIdentifier.Properties.Count == 1 && entityIdentifier.Properties.Any(p => p.PropertyName == "Id");
        }

        /// <summary>
        /// Indicates whether the <see cref="EntityIdentifier" /> is semantically a surrogate identifier, but does not necessarily
        /// indicate this is where the value is physically assigned by the server (surrogate identifier values are assigned
        /// only in the base type's identifier).
        /// </summary>
        /// <param name="entityIdentifier">The <see cref="EntityIdentifier" /> to be evaluated.</param>
        /// <returns><b>true</b> if the identifier is a surrogate identifier; otherwise <b>false</b>.</returns>
        /// <seealso cref="IsSurrogateIdentifierDefinition" />
        /// <remarks>A surrogate identifier is a single-column primary key whose value is server-assigned (e.g. defined as an
        /// IDENTITY column in SQL Server, or an integer column whose value is initialized using a SEQUENCE object). Such an
        /// identifier is still considered a surrogate identifier when it appears on derived entities, however the surrogate
        /// definition will be found on the base entity. 
        /// </remarks>
        public static bool IsSurrogateIdentifier(this EntityIdentifier entityIdentifier)
        {
            return entityIdentifier.IsPrimary
                && entityIdentifier.Properties.Count == 1
                && entityIdentifier.Properties.First().IsServerAssigned;
        }
        
        /// <summary>
        /// Indicates whether the <see cref="EntityIdentifier" /> represents the root <i>definition</i> of a surrogate identifier
        /// (as opposed to the identifier that appears on a derived entity of such a type). 
        /// </summary>
        /// <param name="entityIdentifier">The <see cref="EntityIdentifier" /> to be evaluated.</param>
        /// <returns><b>true</b> if the identifier is the definition of a surrogate identifier; otherwise <b>false</b>.</returns>
        /// <seealso cref="IsSurrogateIdentifier" />
        /// <remarks>A surrogate identifier is a single-column primary key whose value is server-assigned (e.g. defined as an
        /// IDENTITY column in SQL Server, or an integer column whose value is initialized using a SEQUENCE object). Such an
        /// identifier is still considered a surrogate identifier when it appears on derived entities, however the surrogate
        /// definition will be found on the base entity. 
        /// </remarks>
        public static bool IsSurrogateIdentifierDefinition(this EntityIdentifier entityIdentifier)
        {
            return entityIdentifier.IsSurrogateIdentifier() && !entityIdentifier.Entity.IsDerived;
        }
    }
}
