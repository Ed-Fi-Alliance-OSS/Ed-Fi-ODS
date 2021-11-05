// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.TokenInfo
{
    public class TokenInfoEducationOrganizationData
    {
        public TokenInfoEducationOrganizationData() { }

        public TokenInfoEducationOrganizationData(int educationOrganizationId, string nameOfInstitution, string discriminator, string ancestorDiscriminator, int ancestorEducationOrganizationId)
        {
            EducationOrganizationId = educationOrganizationId;
            NameOfInstitution = nameOfInstitution;
            Discriminator = discriminator;
            AncestorDiscriminator = ancestorDiscriminator;
            AncestorEducationOrganizationId = ancestorEducationOrganizationId;
        }

        public int EducationOrganizationId { get; set; }
        public string NameOfInstitution { get; set; }
        public string Discriminator { get; set; }
        public string AncestorDiscriminator { get; set; }
        public int AncestorEducationOrganizationId { get; set; }
    }
}
