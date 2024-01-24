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
    public class Profile
    {
        public Profile()
        {
            Applications = new Collection<Application>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProfileId { get; set; }

        [Required]
        public string ProfileName { get; set; }

        public virtual ICollection<Application> Applications { get; set; }
    }
}
