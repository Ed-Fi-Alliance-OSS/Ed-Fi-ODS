// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Linq;
using EdFi.Common.Extensions;
using EdFi.Ods.Common.Models.Resource;

namespace EdFi.Ods.Common.Extensions
{
    public static class ResourcePropertyExtensions
    {
        /// <summary>
        /// Check if property is identifying and has incoming associations
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool IsIdentifyingAndHasAssociations(this ResourceProperty property)
        {
            if (!property.IsIdentifying || property.EntityProperty == null)
            {
                return false;
            }

            return property.HasAssociations();
        }

        /// <summary>
        /// Check property has any associations (this could be a reference and/or unified key)
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public static bool HasAssociations(this ResourceProperty property)
        {
            return property.EntityProperty.IncomingAssociations.Any();
        }

        /// <summary>
        /// Returns ProperCaseSchemaName of the underlying entity.
        /// </summary>
        /// <param name="resourceProperty"></param>
        /// <returns></returns>
        public static string ProperCaseSchemaName(this ResourceProperty resourceProperty)
        {
            return resourceProperty.EntityProperty.Entity.DomainModel.SchemaNameMapProvider
                                   .GetSchemaMapByPhysicalName(resourceProperty.EntityProperty.Entity.Schema)
                                   .ProperCaseName;
        }

        /// <summary>
        /// Indicates whether or not the property is the resource identifier (i.e. Id) property.
        /// </summary>
        /// <param name="resourceProperty">The property to be evaluated.</param>
        /// <returns><b>true</b> if the property's name is "Id"; otherwise <b>false</b>.</returns>
        public static bool IsResourceIdentifier(this ResourceProperty resourceProperty)
        {
            return resourceProperty.PropertyName.EqualsIgnoreCase("Id");
        }
    }
}
