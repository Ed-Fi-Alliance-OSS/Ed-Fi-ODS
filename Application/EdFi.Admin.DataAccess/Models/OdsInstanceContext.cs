// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    [Table("OdsInstanceContext")]
    public class OdsInstanceContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OdsInstanceContextId { get; set; }

        [Required]
        public int OdsInstanceId { get; set; }
        public virtual OdsInstance OdsInstance { get; set; }

        /// <summary>
        /// The Key for the ODSInstanceContext (e.g. "SchoolYear")
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ContextKey { get; set; }

        /// <summary>
        /// The Value for the ODSInstanceContext (e.g. "2023")
        /// </summary>
        [Required]
        [StringLength(50)]
        public string ContextValue { get; set; }
    }
}
