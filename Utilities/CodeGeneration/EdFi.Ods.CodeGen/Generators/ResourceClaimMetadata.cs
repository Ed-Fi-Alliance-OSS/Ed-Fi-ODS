// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.Linq;
using EdFi.Ods.Common.Extensions;
using EdFi.Ods.Common.Models.Domain;
using EdFi.Ods.Common.Specifications;

namespace EdFi.Ods.CodeGen.Generators
{
    public class ResourceClaimMetadata : GeneratorBase
    {
        protected override object Build()
        {
            var domainModel = TemplateContext.DomainModelProvider.GetDomainModel();

            var orderedAggregates = domainModel
                .Entities
                .Where(x => x.IsAggregateRoot && !x.IsAbstract)
                .OrderBy(x => x.FullName.Name)
                .Select(
                    x => new
                    {
                        DisplayName = x.Name.ToCamelCase(),
                        ResourceName = x.Name.ToCamelCase(),
                        ParentResourceName = GetParentResource(x),
                        HasParent = GetParentResource(x) != null
                    })
                .ToList();

            return new {Aggregates = orderedAggregates};
        }

        private string GetParentResource(Entity entity)
        {
            var resourceName = entity.Name;

            if (resourceName.EndsWith("type", StringComparison.InvariantCultureIgnoreCase))
            {
                return "types";
            }

            if (DescriptorEntitySpecification.IsEdFiDescriptorEntity(resourceName))
            {
                return ManagedDescriptorSpecification.IsEdFiManagedDescriptor(resourceName)
                    ? "managedDescriptors"
                    : "systemDescriptors";
            }

            if (EducationOrganizationEntitySpecification.IsEducationOrganizationEntity(resourceName))
            {
                return "educationOrganizations";
            }

            if (PersonEntitySpecification.IsPersonEntity(resourceName))
            {
                return "people";
            }

            if (AssessmentSpecification.IsAssessmentEntity(resourceName))
            {
                return "assessmentMetadata";
            }

            if (resourceName.Equals("educationContent", StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            if (EducationStandardSpecification.IsEducationStandardEntity(resourceName))
            {
                return "educationStandards";
            }

            if (PrimaryRelationshipEntitySpecification.IsPrimaryRelationshipEntity(resourceName))
            {
                return "primaryRelationships";
            }

            if (SurveySpecification.IsSurveyEntity(resourceName))
            {
                return "surveyDomain";
            }

            return "relationshipBasedData";
        }
    }
}
