// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    public class OdsInstance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OdsInstanceId { get; set; }

        /// <summary>
        /// Friendly name for the ODS Instance, to be displayed / set by the end-user
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Type of ODS instance this identifies (e.g. "Enterprise" or "Cloud")
        /// </summary>
        [Required]
        [StringLength(100)]
        public string InstanceType { get; set; }

        /// <summary>
        /// The connection string for the ODS database
        /// </summary>
        [Required]
        public string ConnectionString { get; set; }
    }
}
