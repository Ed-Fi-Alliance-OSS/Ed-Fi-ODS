// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Common.Caching
{
	public class TokenInfoData
	{
		public TokenInfoData(int claimEducationOrganizationId, string claimNameOfInstitution, string claimDiscriminator, string discriminator, int educationOrganizationId)
		{
			ClaimEducationOrganizationId = claimEducationOrganizationId;
			ClaimNameOfInstitution = claimNameOfInstitution;
			ClaimDiscriminator = claimDiscriminator;
			Discriminator = discriminator;
			EducationOrganizationId = educationOrganizationId;
		}

		public TokenInfoData() { }
		
		public int ClaimEducationOrganizationId { get; set; }
		public string ClaimNameOfInstitution { get; set; }
		public string ClaimDiscriminator { get; set; }
		public string Discriminator { get; set; }
		public int EducationOrganizationId { get; set; }
	}
}
