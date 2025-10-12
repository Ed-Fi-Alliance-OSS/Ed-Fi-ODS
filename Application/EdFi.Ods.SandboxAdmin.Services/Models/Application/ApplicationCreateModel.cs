// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

namespace EdFi.Ods.SandboxAdmin.Services.Models.Application
{
    public class ApplicationCreateModel
    {
        public string ApplicationName { get; set; }
        
        public string EducationOrganizationIdsString { get; set; }
        public long[] EducationOrganizationIds { 
            get
            {
                if (string.IsNullOrWhiteSpace(EducationOrganizationIdsString))
                {
                    return [];
                }

                try
                {
                    // Split the string by comma, trim each value, and parse to long
                    return EducationOrganizationIdsString?.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => long.Parse(x.Trim())).ToArray();
                }catch (FormatException)
                {
                    throw new FormatException("The provided EducationOrganizationIds contains a value which is not a valid integer.");
                }
            }
        }
        public int VendorId { get; set; }
    }
}