// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;

namespace EdFi.Admin.DataAccess.Models
{
    public class OAuthTokenClient
    {
        public string Key { get; set; }

        public bool UseSandbox { get; set; }

        public string StudentIdentificationSystemDescriptor { get; set; }

        public long? EducationOrganizationId { get; set; }

        public string ClaimSetName { get; set; }

        public string NamespacePrefix { get; set; }

        public string ProfileName { get; set; }

        public short? CreatorOwnershipTokenId { get; set; }

        public short? OwnershipTokenId { get; set; }
        
        public DateTime Expiration { get; set; }

        public int ApiClientId { get; set; }
    }
}
