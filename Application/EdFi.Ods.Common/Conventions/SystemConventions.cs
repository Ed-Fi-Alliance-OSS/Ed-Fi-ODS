// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using EdFi.Ods.Common.Models.Domain;

namespace EdFi.Ods.Common.Conventions
{
    public static class SystemConventions
    {
        /// <summary>
        /// Gets the "name" assigned to the HbmBag in the dynamic NHibernate mapping created for aggregate extensions.
        /// </summary>
        /// <param name="association">The <see cref="Association"/> contained in the mapped bag.</param>
        /// <returns>The name of the bag.</returns>
        public static string GetAggregateExtensionBagName(this AssociationView association)
        {
            if (association.AssociationType != AssociationViewType.OneToMany && association.AssociationType != AssociationViewType.OneToOneOutgoing)
                throw new Exception($"For aggregate extensions, the association must be {AssociationViewType.OneToMany} or {AssociationViewType.OneToOneOutgoing}.");

            return $"{association.OtherEntity.SchemaProperCaseName()}_{association.OtherEntity.PluralName}";
        }

        /// <summary>
        /// Gets the target columns of the association based on the nHibernate order, which keeps association columns grouped together
        /// </summary>
        /// <param name="associationView"></param>
        /// <returns></returns>
        // Note this is different than alphabetical in a few edge cases, which is why this is required.
        public static IEnumerable<EntityProperty> GetOrderedAssociationTargetColumns(this AssociationView associationView)
        {
            return RecursivelyGetOrderedAssociationTargetColumns(associationView, new AssociationView[0])
               .Select(p => p);

            IEnumerable<EntityProperty> RecursivelyGetOrderedAssociationTargetColumns(
                AssociationView childAssociationView,
                IEnumerable<AssociationView> associationViews)
            {
                var orderedChildProperties = childAssociationView.PropertyMappings
                    .Where(pm => !pm.ThisProperty.IsFromParent)
                    .OrderBy(pm => pm.ThisProperty.PropertyName)
                    .Select(pm => pm.OtherProperty);

                foreach (var property in orderedChildProperties)
                {
                    var propertyToYield = property;

                    // Find the mapped original property
                    foreach (var av in associationViews)
                    {
                        propertyToYield = av.PropertyMappingByThisName[propertyToYield.PropertyName]
                            .OtherProperty;
                    }

                    yield return propertyToYield;
                }

                // Get the parent entity
                var parentEntity = childAssociationView.ThisEntity.Parent;

                if (parentEntity != null)
                {
                    var parentAssociationView = childAssociationView.ThisEntity.ParentAssociation;
                    var parentsChildAssociation = parentAssociationView.Inverse;

                    var newAssociationViews = new[]
                    {
                        childAssociationView
                    }.Concat(associationViews);

                    foreach (var property in RecursivelyGetOrderedAssociationTargetColumns(parentsChildAssociation, newAssociationViews))
                    {
                        yield return property;
                    }
                } }
        }

        public class ExtensionBagNameParts
        {
            public ExtensionBagNameParts(string schemaProperCaseName, string pluralName)
            {
                SchemaProperCaseName = schemaProperCaseName;
                PluralName = pluralName;
            }

            public string SchemaProperCaseName { get; private set; }
            public string PluralName { get; private set; }
        }

        public static ExtensionBagNameParts GetExtensionBagNameParts(string extensionBagName)
        {
            string[] parts = extensionBagName.Split('_');

            if (parts.Length != 2)
                throw new Exception($"Supplied extension bag name '{extensionBagName}' did not match the expected format.");

            return new ExtensionBagNameParts(parts[0], parts[1]);
        }

        public static string GetMappedAssociationPropertyName(this AssociationView association)
        {
            if (association.AssociationType == AssociationViewType.OneToOneOutgoing)
                return association.Name + OneToOneEntityPropertyNameSuffix;

            return association.Name;
        }

        public const string OneToOneEntityPropertyNameSuffix = "PersistentList";

        public const string AuthSchema = "auth";

        public static bool IsAuthSchema(this string schema) => schema.Equals(AuthSchema);

        public static string GetAuthorizationViewClassName(this string authorizationViewName)
        {
            return $"auth_{authorizationViewName}";
        }
    }
}
