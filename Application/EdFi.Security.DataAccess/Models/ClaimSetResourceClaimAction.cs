// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Security.DataAccess.Models
{
    public class ClaimSetResourceClaimAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimSetResourceClaimActionId { get; set; }

        public int ActionId { get; set; }

        [Required]
        [ForeignKey("ActionId")]
        public Action Action { get; set; }

        public int ClaimSetId { get; set; }

        [Required]
        [ForeignKey("ClaimSetId")]
        public ClaimSet ClaimSet { get; set; }

        public int ResourceClaimId { get; set; }

        [Required]
        [ForeignKey("ResourceClaimId")]
        public ResourceClaim ResourceClaim { get; set; }

        public List<ClaimSetResourceClaimActionAuthorizationStrategyOverrides> AuthorizationStrategyOverrides { get; set; }

        [StringLength(255)]
        public string ValidationRuleSetNameOverride { get; set; }
    }
}
