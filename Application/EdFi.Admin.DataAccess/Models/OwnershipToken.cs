// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace EdFi.Admin.DataAccess.Models
{
    /// <summary>
    /// Class representing the Ownership tokens with descriptive name.
    /// </summary>
    public class OwnershipToken
    {
        public OwnershipToken()
        {
            Clients = new Collection<ApiClient>();
        }
        /// <summary>
        /// Ownership token for API clients
        /// </summary>
        [Key]
        public short OwnershipTokenId { get; set; }
        
        /// <summary>
        /// Descriptive name for the token string length is 50 char
        /// </summary>
        [StringLength(50)]
        public string Description { get; set; }

        public ICollection<ApiClient> Clients { get; set; }
    }
}
