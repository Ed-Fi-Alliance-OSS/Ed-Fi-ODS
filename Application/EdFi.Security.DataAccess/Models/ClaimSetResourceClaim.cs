// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Security.DataAccess.Models
{
    public class ClaimSetResourceClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimSetResourceClaimId { get; set; }

        [Column("Action_ActionId")]
        public int ActionId { get; set; }

        [Required]
        [ForeignKey("ActionId")]
        public Action Action { get; set; }

        [Column("ClaimSet_ClaimSetId")]
        public int ClaimSetId { get; set; }

        [Required]
        [ForeignKey("ClaimSetId")]
        public ClaimSet ClaimSet { get; set; }

        [Column("ResourceClaim_ResourceClaimId")]
        public int ResourceClaimId { get; set; }

        [Required]
        [ForeignKey("ResourceClaimId")]
        public ResourceClaim ResourceClaim { get; set; }

        [Column("AuthorizationStrategyOverride_AuthorizationStrategyId")]
        public int? AuthorizationStrategyId { get; set; }

        public AuthorizationStrategy AuthorizationStrategyOverride { get; set; }

        [StringLength(255)]
        public string ValidationRuleSetNameOverride { get; set; }
    }
}
