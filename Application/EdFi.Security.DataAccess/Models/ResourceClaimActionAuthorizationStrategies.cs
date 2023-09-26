// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Security.DataAccess.Models
{
    public class ResourceClaimActionAuthorizationStrategies
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceClaimActionAuthorizationStrategyId { get; set; }

        public int ResourceClaimActionId { get; set; }

        [Required]
        [ForeignKey("ResourceClaimActionId")]
        public ResourceClaimAction ResourceClaimAction { get; set; }

        public int AuthorizationStrategyId { get; set; }

        [Required]
        [ForeignKey("AuthorizationStrategyId")]
        public AuthorizationStrategy AuthorizationStrategy { get; set; }
    }
}
