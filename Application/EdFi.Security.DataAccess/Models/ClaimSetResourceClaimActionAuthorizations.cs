// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Security.DataAccess.Models
{
    public class ClaimSetResourceClaimActionAuthorizations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimSetResourceClaimActionAuthorizationId { get; set; }

        [Required]
        public Action Action { get; set; }

        [Required]
        public ClaimSet ClaimSet { get; set; }

        [Required]
        public ResourceClaim ResourceClaim { get; set; }

        public List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides> ClaimSetResourceClaimActionAuthorizationStrategyOverrides { get; set; }

        [StringLength(255)]
        public string ValidationRuleSetNameOverride { get; set; }
    }
}
