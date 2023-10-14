// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    public static class PersonEntitySpecification
    {
        public const string Staff = "Staff";
        public const string Student = "Student";
        public const string Parent = "Parent";
        
        public static string[] ValidPersonTypes { get; } =
            {
                Staff, Student, Parent
            };

        private static readonly string[] _suffixes = { UniqueIdSpecification.USI, UniqueIdSpecification.UniqueId };

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
            return ValidPersonTypes.Contains(typeName, StringComparer.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// Indicates whether the specified property name is an identifier for the specified person type.
        /// </summary>
        /// <param name="propertyName">The name of the property to be evaluated.</param>
        /// <param name="personType">A specific type of person; or <b>null</b> for any type.</param>
        /// <returns><b>true</b> if the property is an identifier for the specified type of person; otherwise <b>false</b>.</returns>
        public static bool IsPersonIdentifier(string propertyName, string personType = null)
        {
            if (personType != null && !ValidPersonTypes.Any(pt => pt.EqualsIgnoreCase(personType)))
            {
                throw new ArgumentException("'{0}' is not a supported person type.");
            }

            // TODO: Embedded convention (Person identifiers can end with "USI" or "UniqueId")
            return _suffixes.Any(
                s => propertyName.EndsWith(s) 
                    && ValidPersonTypes.Any(
                        pt => 
                            // Person type was either not specified, or current person type matches what was specified
                            (personType == null || personType == pt) 
                            && PersonTypeAppearsImmediatelyBeforeSuffix(pt, s)));

            bool PersonTypeAppearsImmediatelyBeforeSuffix(string pt, string suffix)
            {
                int lastIndexOfPersonType = propertyName.LastIndexOf(pt, StringComparison.Ordinal);

                if (lastIndexOfPersonType < 0)
                {
                    // Person type is not in the property name
                    return false;
                }
                
                // Identify expected location of the person type in the property name
                int expectedLastIndexOfPersonType = propertyName.Length - (pt.Length + suffix.Length);

                return lastIndexOfPersonType == expectedLastIndexOfPersonType;
            }
        }
    }
}
