// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.LoadTools.Engine.Mapping
{
    public class PremappedLookupMetadataMapper : PremappedMetadataMapper
    {
        protected override PrematchedMapping[] GetPrematchedMappings()
        {
            return new PrematchedMapping[]
            {
                new PrematchedMapping<CopySimplePropertyMappingStrategy>(
                    "AssessmentFamilyLookupType",
                    "getAssessmentFamiliesByExample",
                    new PropertyMap("AssessmentFamilyTitle", "title"),
                    new PropertyMap("AssessmentCategory/CodeValue", "assessmentCategoryDescriptor"),
                    new PropertyMap("AssessmentCategory/Namespace", "namespace")),
                new PrematchedMapping<CopySimplePropertyMappingStrategy>(
                    "AssessmentIdentityType",
                    "assessment",
                    new PropertyMap("AssessmentTitle", "title"))
            };
        }
    }
}
