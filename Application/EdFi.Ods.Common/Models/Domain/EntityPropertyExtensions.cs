// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Models.Domain
{
    public static class EntityPropertyExtensions
    {
        /// <summary>
        /// Indicates whether the <see cref="EntityProperty" /> is semantically a surrogate identifier, but does not necessarily
        /// indicate this is where the value is physically assigned by the server (surrogate identifier values are assigned
        /// only in the base type's identifier).
        /// </summary>
        /// <param name="entityProperty">The <see cref="EntityProperty" /> to be evaluated.</param>
        /// <returns><b>true</b> if the property is a surrogate identifier; otherwise <b>false</b>.</returns>
        /// <seealso cref="IsSurrogateIdentifierDefinition" />
        /// <remarks>A surrogate identifier is a single-column primary key whose value is server-assigned (e.g. defined as an
        /// IDENTITY column in SQL Server, or an integer column whose value is initialized using a SEQUENCE object). Such an
        /// identifier is still considered a surrogate identifier when it appears on derived entities, however the surrogate
        /// definition will be found on the base entity. 
        /// </remarks>
        public static bool IsSurrogateIdentifier(this EntityProperty entityProperty)
        {
            return entityProperty.IsIdentifying && entityProperty.Entity.Identifier.IsSurrogateIdentifier();
        }
        
        /// <summary>
        /// Indicates whether the <see cref="EntityProperty" /> represents the root <i>definition</i> of a surrogate identifier
        /// (as opposed to the identifier that appears on a derived entity of such a type). 
        /// </summary>
        /// <param name="entityProperty">The <see cref="EntityProperty" /> to be evaluated.</param>
        /// <returns><b>true</b> if the property is the definition of a surrogate identifier; otherwise <b>false</b>.</returns>
        /// <seealso cref="IsSurrogateIdentifier" />
        /// <remarks>A surrogate identifier is a single-column primary key whose value is server-assigned (e.g. defined as an
        /// IDENTITY column in SQL Server, or an integer column whose value is initialized using a SEQUENCE object). Such an
        /// identifier is still considered a surrogate identifier when it appears on derived entities, however the surrogate
        /// definition will be found on the base entity. 
        /// </remarks>
        public static bool IsSurrogateIdentifierDefinition(this EntityProperty entityProperty)
        {
            return (entityProperty.IsIdentifying && entityProperty.Entity.Identifier.IsSurrogateIdentifierDefinition());
        }

        /// <summary>
        /// Indicates whether the <see cref="EntityProperty" /> represents a <i>usage</i> of a surrogate identifier of another
        /// entity.
        /// </summary>
        /// <param name="entityProperty">The property to be evaluated.</param>
        /// <returns><b>true</b> if the property represents the usage of a surrogate identifier of another entity; otherwise <b>false</b>.</returns>
        public static bool IsSurrogateIdentifierUsage(this EntityProperty entityProperty)
        {
            return entityProperty.DefiningProperty.IsSurrogateIdentifierDefinition()
                && !entityProperty.IsSurrogateIdentifier();
        }
    }
}
