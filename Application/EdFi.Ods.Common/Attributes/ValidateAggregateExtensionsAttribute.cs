// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using EdFi.Ods.Common.Conventions;
using EdFi.Ods.Common.Dependencies;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Validation;

namespace EdFi.Ods.Common.Attributes
{
    /// <summary>
    /// Validates an Ed-Fi AggregateExtensions dictionary.
    /// </summary>
    public class ValidateAggregateExtensionsAttribute : ValidationAttribute
    {
        private readonly Lazy<Entity> _parentEntity;
        
        private readonly ValidateEnumerableAttribute _validateEnumerable = new();
        private readonly RequiredCollectionAttribute _validateRequiredCollection = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateAggregateExtensionsAttribute" /> class for the specified Ed-Fi Standard entity type.
        /// </summary>
        /// <param name="edFiStandardType">The Ed-Fi Standard type on which the Extensions dictionary is being validated.</param>
        public ValidateAggregateExtensionsAttribute(Type edFiStandardType)
        {
            _parentEntity = new Lazy<Entity>(
                () =>
                {
                    string schema = edFiStandardType.GetCustomAttribute<SchemaAttribute>().Schema;
                    var parentEntityFullName = new FullName(schema, edFiStandardType.Name);

                    if (!GeneratedArtifactStaticDependencies.DomainModelProvider.GetDomainModel()
                            .EntityByFullName.TryGetValue(parentEntityFullName, out Entity parentEntity))
                    {
                        throw new Exception($"Unable to find entity '{parentEntityFullName}' in the domain model.");
                    }

                    return parentEntity;
                });
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dictionary = value as IDictionary;
            var parent = validationContext.ObjectInstance as IHasExtensions;

            if (dictionary == null)
            {
                return ValidationResult.Success;
            }

            var compositeResults = new CompositeValidationResult($"Validation of '{validationContext.DisplayName}' failed.");

            foreach (DictionaryEntry entry in dictionary)
            {
                var enumerable = (entry.Value as IList);

                if (enumerable == null)
                {
                    throw new Exception($"Unable to unwrap the extension object.");
                }

                var context = new ValidationContext(enumerable, null)
                {
                    DisplayName = GetAggregateExtensionDisplayName((string)entry.Key)
                };

                string extensionBagName = (string) entry.Key;
                var association = GetExtensionBagNameAssociation(extensionBagName);

                // Determine if we should skip validation (for unsupplied, optional extensions, with no aggregate extension
                // data present which can cause false validation failures based for "optional extension" semantics).
                if (!ShouldValidateAggregateExtension(association, enumerable, parent))
                {
                    continue;
                }

                // Are we validating a single embedded object?
                if (association.Association.Cardinality == Cardinality.OneToOne
                    || association.Association.Cardinality == Cardinality.OneToZeroOrOne)
                {
                    ValidateEmbeddedObject(association, enumerable, context, compositeResults);
                }
                else
                {
                    ValidateCollection(association, enumerable, context, compositeResults);
                }
            }

            return compositeResults.Results.Any()
                ? compositeResults
                : ValidationResult.Success;
        }

        private static bool ShouldValidateAggregateExtension(AssociationView association, IList enumerable, IHasExtensions parent)
        {
            // If the list has items, validate it
            if (enumerable.Count > 0)
            {
                return true;
            }

            // Determine if extension was supplied
            string extensionName = association.OtherEntity.SchemaProperCaseName();
            bool extensionWasSupplied = (parent.Extensions[extensionName] as IList)?.Count > 0;

            // If the extension was supplied, validate it
            if (extensionWasSupplied)
            {
                return true;
            }

            // Determine if the extension is required
            var extensionAssociation = association.ThisEntity.ExtensionAssociations
                .SingleOrDefault(a => a.OtherEntity.SchemaProperCaseName() == extensionName)
                ?.Association;

            bool extensionIsRequired =
                // Implicit extensions will not have an association, but are treated as required
                extensionAssociation == null
                // Check extension association for one-to-one cardinality 
                || extensionAssociation.Cardinality == Cardinality.OneToOneExtension;

            // If there are items in the list, or the extension was supplied, or the extension is required
            // then we need to run validation
            if (extensionIsRequired)
            {
                return true;
            }

            // Extension is optional, so don't run validation (which will fail incorrectly with the semantics
            // defined for optional extensions)
            return false;
        }

        private void ValidateCollection(
            AssociationView association,
            IList enumerable,
            ValidationContext context,
            CompositeValidationResult compositeResults)
        {
            if (IsRequiredCollection(association))
            {
                var requiredCollectionValidationResult = _validateRequiredCollection.GetValidationResult(enumerable, context);

                AppendValidationResults(compositeResults, requiredCollectionValidationResult);
            }

            var enumerableValidationResult = _validateEnumerable.GetValidationResult(enumerable, context);

            AppendValidationResults(compositeResults, enumerableValidationResult);
        }

        private void ValidateEmbeddedObject(
            AssociationView association,
            IList enumerable,
            ValidationContext context,
            CompositeValidationResult compositeResults)
        {
            // No embedded object to validate?
            if (enumerable.Count == 0)
            {
                if (IsRequiredEmbeddedObject(association))
                {
                    AppendValidationResults(
                        compositeResults,
                        new ValidationResult(
                            $"{association.Name} ({association.OtherEntity.SchemaProperCaseName()}) is required."));
                }

                return;
            }

            var embeddedObjectCompositeResults = new CompositeValidationResult($"Validation of '{context.DisplayName}' failed.");

            var embeddedObject = enumerable[0];
            var validationResults = new List<ValidationResult>();

            var newContext = new ValidationContext(embeddedObject)
            {
                DisplayName = context.DisplayName
            };

            Validator.TryValidateObject(embeddedObject, newContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                AppendValidationResults(embeddedObjectCompositeResults, validationResult);
            }

            if (embeddedObjectCompositeResults.Results.Any())
            {
                AppendValidationResults(compositeResults, embeddedObjectCompositeResults);
            }
        }

        private static void AppendValidationResults(CompositeValidationResult compositeResults, ValidationResult validationResult)
        {
            if (validationResult != ValidationResult.Success)
            {
                if (validationResult is CompositeValidationResult)
                {
                    compositeResults.AddResult(validationResult);
                }
                else
                {
                    compositeResults.AddResult(new ValidationResult($"{validationResult}"));
                }
            }
        }

        private bool IsRequiredCollection(AssociationView association)
        {
            // Determine if the aggregate extension is a required collection
            return association.Association.Cardinality == Cardinality.OneToOneOrMore;
        }

        private bool IsRequiredEmbeddedObject(AssociationView association)
        {
            // Determine if the aggregate extension is a required collection
            return association.Association.Cardinality == Cardinality.OneToOne;
        }

        private AssociationView GetExtensionBagNameAssociation(string extensionBagName)
        {
            var nameParts = SystemConventions.GetExtensionBagNameParts(extensionBagName);

            AssociationView association = _parentEntity.Value.AggregateExtensionChildren
                .Concat(_parentEntity.Value.AggregateExtensionOneToOnes)
                .SingleOrDefault(a => a.Name == nameParts.MemberName);

            if (association == null)
            {
                throw new Exception(
                    $"Unable to find aggregate extension association for member '{nameParts.MemberName}' defined by extension '{nameParts.SchemaProperCaseName}' on entity '{_parentEntity.Value.FullName}'");
            }

            return association;
        }

        private string GetAggregateExtensionDisplayName(string extensionBagName)
        {
            var bagNameParts = SystemConventions.GetExtensionBagNameParts(extensionBagName);

            return $"{bagNameParts.MemberName} ({bagNameParts.SchemaProperCaseName})";
        }
    }
}
