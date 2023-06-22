// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    public static class PersonEntitySpecification
    {
        /// <summary>
        /// Provides the well-known person type representing students.
        /// </summary>
        public const string Student = "Student";

        private static readonly Lazy<string[]> _validPersonTypes = new(
            () => GeneratedArtifactStaticDependencies.DomainModelProvider.GetDomainModel()
                .Aggregates.Select(a => a.AggregateRoot)
                .Where(e => e.Identifier.Properties.Count == 1 && e.Identifier.Properties[0].PropertyName.EndsWith("USI"))
                .Select(e => e.Name)
                .ToArray());

        public static string[] ValidPersonTypes
        {
            get => _validPersonTypes.Value;
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="Type"/> represents a type of person.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to be evaluated.</param>
        /// <returns><b>true</b> if the entity type represents a type of person; otherwise <b>false</b>.</returns>
        public static bool IsPersonEntity(Type type)
        {
            return IsPersonEntity(type.Name);
        }

        /// <summary>
        /// Indicates whether the specified type name represents a type of person.
        /// </summary>
        /// <param name="typeName">The <see cref="Type.Name"/> value to be evaluated.</param>
        /// <returns><b>true</b> if the entity represents a type of person; otherwise <b>false</b>.</returns>
        public static bool IsPersonEntity(string typeName)
        {
            return ValidPersonTypes.Contains(typeName, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Indicates whether the specified property name is an identifier for a person.
        /// </summary>
        /// <param name="propertyName">The name of the property to be evaluated.</param>
        /// <returns><b>true</b> if the property is an identifier for a type of person; otherwise <b>false</b>.</returns>
        public static bool IsPersonIdentifier(string propertyName)
        {
            return IsPersonIdentifier(propertyName, null);
        }

        /// <summary>
        /// Indicates whether the specified property name is an identifier for the specified person type.
        /// </summary>
        /// <param name="propertyName">The name of the property to be evaluated.</param>
        /// <param name="personType">A specific type of person.</param>
        /// <returns><b>true</b> if the property is an identifier for the specified type of person; otherwise <b>false</b>.</returns>
        public static bool IsPersonIdentifier(string propertyName, string personType)
        {
            if (personType != null && !ValidPersonTypes.Any(pt => pt.EqualsIgnoreCase(personType)))
            {
                throw new ArgumentException($"'{personType}' is not a supported person type.");
            }

            // TODO: Embedded convention (Person identifiers can end with "USI" or "UniqueId")
            if (propertyName.TryTrimSuffix("UniqueId", out string entityName)
                || propertyName.TryTrimSuffix("USI", out entityName))
            {
                return IsPersonEntity(entityName)
                       && (personType == null || entityName.EqualsIgnoreCase(personType));
            }

            return false;
        }
    }
}
