// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EdFi.Admin.DataAccess.Models
{
    [PrimaryKey("ApiClientId", "ApplicationEducationOrganizationId")]
    [Index("ApiClientId")]
    [Index("ApplicationEducationOrganizationId")]
    public class ApiClientApplicationEducationOrganization
    {
        [Column("ApiClient_ApiClientId")]
        public int ApiClientId { get; set; }
        
        [Column("ApplicationEducationOrganization_ApplicationEducationOrganizationId")]
        public int ApplicationEducationOrganizationId { get; set; }
    }
}
