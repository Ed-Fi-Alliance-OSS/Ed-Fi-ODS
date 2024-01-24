// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    public sealed class VendorNamespacePrefix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VendorNamespacePrefixId { get; set; }

        [Required]
        public Vendor Vendor { get; set; }

        [Required]
        [StringLength(255)]
        public string NamespacePrefix { get; set; }
    }
}
