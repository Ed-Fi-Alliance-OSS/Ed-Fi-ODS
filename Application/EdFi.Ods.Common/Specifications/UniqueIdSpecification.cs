// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Common.Specifications
{
    public static class UniqueIdSpecification
    {
        private const string USI = "USI";
        private const string UniqueId = "UniqueId";

        public static string GetUniqueIdPersonType(string propertyName)
        {
            string personType = PersonEntitySpecification
                               .ValidPersonTypes
                               .FirstOrDefault(pt => propertyName.EndsWith(pt + UniqueId));

            return personType;
        }

        /// <summary>
        /// Attempt to determine the type of person for a supplied UniqueId property name.
        /// </summary>
        /// <param name="propertyName">The name of the UniqueId property.</param>
        /// <param name="personType">The type of person identified, based on the property name.</param>
        /// <returns><b>true</b> if the person type could be determined; otherwise <b>false</b>.</returns>
        public static bool TryGetUniqueIdPersonType(string propertyName, out string personType)
        {
            personType = GetUniqueIdPersonType(propertyName);

            return personType != null;
        }

        public static string GetUSIPersonType(string propertyName)
        {
            string personType = PersonEntitySpecification
                               .ValidPersonTypes
                               .FirstOrDefault(pt => propertyName.EndsWithIgnoreCase(pt + USI));

            return personType;
        }

        public static bool TryGetUSIPersonType(string propertyName, out string personType)
        {
            personType = GetUSIPersonType(propertyName);

            return personType != null;
        }

        public static bool TryGetUSIPersonTypeAndRoleName(string propertyName, out string personType, out string roleName)
        {
            roleName = null;

            personType = PersonEntitySpecification
                        .ValidPersonTypes
                        .FirstOrDefault(pt => propertyName.EndsWithIgnoreCase(pt + USI));

            if (personType == null)
            {
                return false;
            }

            int personStartPos;

            // Extract role name applied as a prefix
            if ((personStartPos = propertyName.IndexOf(personType)) >= 0)
            {
                roleName = propertyName.Substring(0, personStartPos);
            }

            return true;
        }

        public static bool IsUSI(string propertyName)
        {
            return propertyName.EndsWithIgnoreCase(USI);
        }

        public static string RemoveUsiSuffix(string propertyName)
        {
            return propertyName.ReplaceSuffix(USI, string.Empty);
        }

        public static string GetUsiPropertyName(string uniqueIdColumnName)
        {
            return uniqueIdColumnName.ReplaceSuffix(UniqueId, USI);
        }

        /// <summary>
        /// Indicates whether the property name is an USI for a known Ed-Fi core
        /// person entity type (i.e. Student, Staff, or Parent).
        /// </summary>
        /// <param name="propertyName">The name of the property to evaluate.</param>
        /// <returns><b>true</b> if the USI is a known core person entity; otherwise <b>false</b>.</returns>
        /// <remarks>This method was added to accommodate logic that was explicitly checking for specific
        /// person entity types.  The logic in this regard may need to be revisisted, but is left intact
        /// due to the impact of the code generation process in the event USIs are used on an Ed-Fi extension.</remarks>
        public static bool IsCoreUSI(string propertyName)
        {
            return propertyName.EndsWithIgnoreCase("StudentUSI")
                   || propertyName.EndsWithIgnoreCase("StaffUSI")
                   || propertyName.EndsWithIgnoreCase("ParentUSI");
        }

        public static bool IsUniqueId(string propertyName)
        {
            return propertyName.EndsWithIgnoreCase(UniqueId);
        }

        public static string RemoveUniqueIdSuffix(string propertyName)
        {
            return propertyName.ReplaceSuffix(UniqueId, string.Empty);
        }

        public static string GetUniqueIdPropertyName(string usiPropertyName)
        {
            return usiPropertyName.ReplaceSuffix(USI, UniqueId);
        }
    }
}
