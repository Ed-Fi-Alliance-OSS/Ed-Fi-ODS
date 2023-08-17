// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    [Table("OdsInstanceDerivative")]
    public class OdsInstanceDerivative
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OdsInstanceDerivativeId { get; set; }

        [Required]
        public int OdsInstanceId { get; set; }
        public virtual OdsInstance OdsInstance {get; set; }

        /// <summary>
        /// The type of derivative (e.g. "Snapshot")
        /// </summary>
        [Required]
        [StringLength(50)]
        public string DerivativeType { get; set; }

        /// <summary>
        /// The database connection string for the derivative
        /// </summary>
        [Required]
        [StringLength(500)]
        public string ConnectionString { get; set; }
    }
}
