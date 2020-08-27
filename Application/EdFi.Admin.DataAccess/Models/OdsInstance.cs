// SPDX-License-Identifier: Apache-2.0
// Licensed to the Ed-Fi Alliance under one or more agreements.
// The Ed-Fi Alliance licenses this file to you under the Apache License, Version 2.0.
// See the LICENSE and NOTICES files in the project root for more information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdFi.Admin.DataAccess.Models
{
    public class OdsInstance
    {
        public OdsInstance()
        {
            OdsInstanceComponents = new Collection<OdsInstanceComponent>();
        }

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
        /// Current status of this ODS instance, for display/use by management tooling
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Status { get; set; }

        /// <summary>
        /// If set to true, signifies that this ODS installation has been extended with custom code
        /// </summary>
        public bool IsExtended { get; set; }

        /// <summary>
        /// Version number of this ODS installation
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Version { get; set; }

        public virtual ICollection<OdsInstanceComponent> OdsInstanceComponents { get; set; }
    }
}
