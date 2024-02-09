// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.Features.IdentityManagement.Models
{
    public class IdentityResponse
    {
        public string UniqueId { get; set; }

        public decimal Score { get; set; }

        public string LastSurname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string GenerationCodeSuffix { get; set; }

        public string SexType { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? BirthOrder { get; set; }

        public Location BirthLocation { get; set; }
    }
}
