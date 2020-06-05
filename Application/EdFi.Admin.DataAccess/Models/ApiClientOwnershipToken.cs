// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    /// <summary>
    /// Class representing the assignment of one or more ownership tokens to an API client.
    /// A API Client has a list of Ownership tokens.
    /// </summary>
    public class ApiClientOwnershipToken
    {
        /// <summary>
        /// Numeric Identifier which is an Identity column which distinguish the uniques combination of ApiClient and Ownership Token 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApiClientOwnershipTokenId { get; set; }

        [Required]
        [Index(IsUnique = true, Order = 2)]
        public OwnershipToken OwnershipToken { get; set; }

        [Required]
        [Index(IsUnique = true, Order = 1)]
        public ApiClient ApiClient { get; set; }
    }
}
