// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Security.DataAccess.Models
{
    public class ResourceClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResourceClaimId { get; set; }

        [StringLength(255)]
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// ResourceName is actually an Uri so length needs to be around 2048
        /// </summary>
        [StringLength(2048)]
        [Required]
        public string ResourceName { get; set; }

        /// <summary>
        /// ClaimName is actually an Uri so length needs to be around 2048
        /// </summary>
        [StringLength(2048)]
        [Required]
        public string ClaimName { get; set; }

        [Required]
        public Application Application { get; set; }

        public int? ParentResourceClaimId { get; set; }

        public virtual ResourceClaim ParentResourceClaim { get; set; }
    }
}
